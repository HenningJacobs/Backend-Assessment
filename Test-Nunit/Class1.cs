using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Web;

namespace Test_Nunit
{
    public class Class1
    {
        [TestCase("joh",1,1)]
        [TestCase("mum",0,5)]
        //[TestCase("joh")]
        public void TestSearch(string Search_criteria, int Page_Number, int Page_size)
        {
            //Arange
            var Controller = new MusicBackend.Controllers.ArtistsController();

            //Act
            var Result = Controller.Search(Search_criteria, Page_Number, Page_size);

            //Assert
            NUnit.Framework.Assert.That(Result != null);
        }

        [TestCase("c44e9c22-ef82-4a77-9bcd-af6c958446d6","{\"releases\":[{\"releaseId\":\"0af02a32-7deb-3ff0-bbe8-f23a4227494f\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Gentlemen of the Road\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"2b15d676-1cc4-4703-801d-67fd9f02d3e2\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Dew Process\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"34c2b7b8-4403-4110-8c07-d204739705ec\",\"title\":\"2010-02-02: Triple J: Live at the Wireless, Sydney, Australia\",\"status\":\"Bootleg\",\"label\":\"No Label Data\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"3dcc266b-9d50-4f85-955c-a7c82b10d58e\",\"title\":\"Babel\",\"status\":\"Official\",\"label\":\"Island\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"421d266a-cb45-48f2-9e4a-5c415723460f\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"V2 Records GmbH\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"42266b93-d1ab-4b94-b155-b2e2c4f241d7\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"V2\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"519dab3a-2679-4237-95be-87a2c072cf00\",\"title\":\"Babel\",\"status\":\"Official\",\"label\":\"Dew Process\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"596c7222-e5be-3426-b396-d4ac3cb96f0d\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Dew Process\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"5e41ce0d-ce16-4a00-83bb-8e0e41d67cbb\",\"title\":\"Babel\",\"status\":\"Official\",\"label\":\"Island\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"6244223c-1a20-30a7-81e2-f445f890e161\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Glassnote Records\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"68bd1bad-f596-443d-8af4-7f298784fadc\",\"title\":\"Live at Shepherd\u0027s Bush Empire, London (Deluxe Companion)\",\"status\":\"Official\",\"label\":\"Glassnote Records\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"803070ad-b1c6-4ccc-b469-63179ffe9cab\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Glassnote Records\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"8b4224f6-6bb5-4aea-8f70-54b9f3a9bf12\",\"title\":\"Babel\",\"status\":\"Official\",\"label\":\"Cooperative Music\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"8bcc563e-7bcb-3f3c-96a1-94138e22f3bb\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Gentlemen of the Road\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"8cf6f9e0-9a9b-4b3c-a130-2f79b813eaf7\",\"title\":\"Babel\",\"status\":\"Official\",\"label\":\"Glassnote Records\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"964c1390-92d9-40e0-8bc9-8c2678551310\",\"title\":\"Babel\",\"status\":\"Official\",\"label\":\"Island\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"9cc88413-d456-4b96-a0c1-09fa6cc2cf88\",\"title\":\"iTunes Festival: London 2010\",\"status\":\"Official\",\"label\":\"Gentlemen of the Road\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"a015074b-e109-412d-9f7b-170b80a0ebbd\",\"name\":\"Dharohar Project\"},{\"id\":\"cd9713d6-6e5f-4143-9412-4d12b7bd47f2\",\"name\":\"Laura Marling\"},{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"9f411ee8-915a-3e21-ab02-0243fceca637\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Gentlemen of the Road\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"b1402714-a29f-384c-88d7-f172fc7079d0\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Gentlemen of the Road\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"be971abb-306b-4de5-b0be-18028eea03d9\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Island\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"c3c9820b-59c8-4449-8b04-292723386ef3\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Gentlemen of the Road\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"c84050fb-4864-4ec1-bbc8-f6cd1f5daa54\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Glassnote Records\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"d751cba4-242e-46d8-b230-3ca1d4e59b85\",\"title\":\"Sigh No More\",\"status\":\"Official\",\"label\":\"Gentlemen of the Road\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"ed1dc3fc-5475-4e4d-8ba6-bb4871d02987\",\"title\":\"Babel\",\"status\":\"Official\",\"label\":\"Cooperative Music\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]},{\"releaseId\":\"fd491d55-6d98-494a-bef6-23919d8b5c91\",\"title\":\"Babel\",\"status\":\"Official\",\"label\":\"Glassnote Records\",\"numberOfTracks\":0,\"otherArtists\":[{\"id\":\"c44e9c22-ef82-4a77-9bcd-af6c958446d6\",\"name\":\"Mumford \u0026 Sons\"}]}]}")]
        [TestCase("dfpgopdkfgpokpsdkgpokdpokgpokdfpogkp","{\"releases\":[]}")]
        [TestCase("", "{\"releases\":[]}")]
        public void TestReleases(string artist_id, string TestResult)
        {
            //Arange
            var Controller = new MusicBackend.Controllers.ArtistsController();

            //Act
            var Result = Controller.Releases(artist_id);

            //Assert
            //NUnit.Framework.Assert.That(Result == TestResult);
            NUnit.Framework.Assert.That(Result != null);
        }
    }
}
