using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using MusicBackend.Models;
using System.Web.Script.Serialization;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;

namespace MusicBackend.Controllers
{
    public class ArtistsController : Controller
    {
        private ArtistDBContext db = new ArtistDBContext();

        // GET: Artists
        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        // Get: Search Results
        public ActionResult Search(string Search_criteria, int? Page_Number, int? Page_size)
        {
            //Assign Classes
            var TheReturnData = new ReturnArtistData();
            TheReturnData.results = new List<CLSReturnArtist>();

            //Set min and max values
            if (!Page_Number.HasValue)
                Page_Number = 1;

            if (!Page_size.HasValue)
                Page_size = 25;

            if (Page_Number < 1)
                Page_Number = 1;

            if (Page_size > 25)
                Page_size = 25;

            //Create linq query to select the artists
            var artists = from m in db.Artists
                          select m;

            //Modify to filter results
            if (!string.IsNullOrEmpty(Search_criteria))
            {
                artists = artists.Where(s => s.ArtistName.Contains(Search_criteria));
            }

            //Pagination
            TheReturnData.numberOfPages = artists.Count() / Page_size.Value;
            Page_Number = Page_Number - 1;
            int NumberToSkip = Page_size.Value * Page_Number.Value;
            int NumbertoTake = Page_size.Value;
            artists = artists.OrderBy(art=>art.ArtistName).Skip(NumberToSkip).Take(NumbertoTake);
            TheReturnData.pageSize = Page_size.Value;
            TheReturnData.page = Page_Number.Value;
            TheReturnData.numberOfSearchResults = artists.Count();

            //Put data in the return data class
            foreach (var SQLData in artists)
            {
                var NewArtist = new CLSReturnArtist();
                NewArtist.alias = new List<string>();

                NewArtist.name = SQLData.ArtistName;
                NewArtist.counrty = SQLData.Counrty;

                //Get list of Aliases
                string[] split = SQLData.Aliases.Split(',');
                foreach(var SplitData in split)
                    NewArtist.alias.Add(SplitData);

                //Get Link to artist Album
                NewArtist.albumLink = "";

                //Insirt into returndata
                TheReturnData.results.Add(NewArtist);
            }

            //Return Json
            return Json(TheReturnData, JsonRequestBehavior.AllowGet);
        }

        // Get: Search Results
        public ActionResult Releases(string artist_id) //This doesnt seem right
        {
            //artist_id = "c44e9c22-ef82-4a77-9bcd-af6c958446d6";//Mumford & Sons

            //Assign classes
            var TheReturnData = new ReturnReleaseData();
            TheReturnData.releases = new List<CLSReturnReleases>();

            try
            {
                //Get Artists and release data from Musicbrains
                var WebClient = new WebClient();
                string jsonFromPage = WebClient.DownloadString("http://musicbrainz.org/ws/2/artist/" + artist_id + "?inc=releases&type=album&fmt=json");
                var ArtistData = Newtonsoft.Json.JsonConvert.DeserializeObject<ArtistData>(jsonFromPage);

                //Add Data
                foreach (var Data in ArtistData.releases)
                {
                    var ReleaseDataToAdd = new CLSReturnReleases();
                    ReleaseDataToAdd.otherArtists = new List<CLRReturnOtherArtists>();

                    //Add data to return
                    ReleaseDataToAdd.releaseId = Data.Id;
                    ReleaseDataToAdd.title = Data.Title;
                    ReleaseDataToAdd.status = Data.Status;
                    ReleaseDataToAdd.label = "No Label Data";

                    //Get releases from musicbrainz
                    jsonFromPage = WebClient.DownloadString("http://musicbrainz.org/ws/2/release/" + Data.Id + "?inc=artists+labels&fmt=json");
                    jsonFromPage = jsonFromPage.Replace("artist-credit", "ArtistCredit");
                    jsonFromPage = jsonFromPage.Replace("label-info", "LabelInfo");
                    //Deserialize into class
                    var releaseAndArtists = Newtonsoft.Json.JsonConvert.DeserializeObject<ReleaseDataAndArtists>(jsonFromPage);

                    //In case there is no Label info
                    try
                    {
                        ReleaseDataToAdd.label = releaseAndArtists.LabelInfo[0].Label.Name;
                    }
                    catch { }

                    //Add release data to return
                    foreach (var artistData in releaseAndArtists.ArtistCredit)
                    {
                        var ReleaseOtherArtists = new CLRReturnOtherArtists();
                        ReleaseOtherArtists.id = artistData.Artist.Id;
                        ReleaseOtherArtists.name = artistData.Artist.Name;
                        ReleaseDataToAdd.otherArtists.Add(ReleaseOtherArtists);
                    }

                    TheReturnData.releases.Add(ReleaseDataToAdd);
                }
            }
            catch { }//Data returned has no value

            //Return Json
            return Json(TheReturnData, JsonRequestBehavior.AllowGet);
        }

        // GET: Artists/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GUID,ArtistName,Counrty,Aliases")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                artist.GUID = Guid.NewGuid();
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GUID,ArtistName,Counrty,Aliases")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
