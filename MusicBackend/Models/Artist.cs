using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using MusicBrainz.Data;
using System.Xml.Schema;

namespace MusicBackend.Models
{
    public class Artist
    {
        [StringLength(60, MinimumLength =3)]
        [Required]
        public string ArtistName { get; set; }
        [Key]
        public Guid GUID { get; set; }
        [StringLength(2)]
        [Required]
        public string Counrty { get; set; }
        public string Aliases { get; set; }
    }

    public class ArtistDBContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
    }
    #region Artists
    public class CLSReturnArtist
    {
        public string name { get; set; }
        public string counrty { get; set; }
        public List<string> alias { get; set; }
        public string albumLink { get; set; }
    }

    public class ReturnArtistData
    {
        public List<CLSReturnArtist> results { get; set; }
        public int numberOfSearchResults { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfPages { get; set; }
    }
    #endregion

    #region Releases
    public class CLRReturnOtherArtists
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class CLSReturnReleases
    {
        public string releaseId { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string label { get; set; }
        public int numberOfTracks { get; set; }
        public List<CLRReturnOtherArtists> otherArtists { get; set; }
    }

    public class ReturnReleaseData
    {
        public List<CLSReturnReleases> releases { get; set; }
    }

    public class ArtistData
    {
        [XmlArray("alias-list")]
        [XmlArrayItem("alias", IsNullable = false)]
        public List<Alias> Aliaslist { get; set; }
        [XmlElement("area")]
        public GArea Area { get; set; }
        [XmlElement("begin-area")]
        public GArea Beginarea { get; set; }
        [XmlElement("country")]
        public string Country { get; set; }
        [XmlElement("disambiguation")]
        public string Disambiguation { get; set; }
        [XmlElement("end-area")]
        public GArea Endarea { get; set; }
        [XmlElement("gender")]
        public string Gender { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement("life-span", IsNullable = false)]
        public Lifespan Lifespan { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlAttribute("score", Form = XmlSchemaForm.Qualified, Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public int Score { get; set; }
        [XmlElement("sort-name")]
        public string Sortname { get; set; }
        [XmlArray("tag-list")]
        [XmlArrayItem("tag", IsNullable = false)]
        public List<GTag> Taglist { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        public List<ReleaseDatas> releases {get; set;}
    }

    public class ReleaseDatas
    {
        [XmlArray("artist-credit")]
        [XmlArrayItem("name-credit", IsNullable = false)]
        public List<ReleaseNamecredit> Artistcredit { get; set; }
        [XmlElement("asin")]
        public string Asin { get; set; }
        [XmlElement("barcode")]
        public string Barcode { get; set; }
        [XmlElement("country")]
        public string Country { get; set; }
        [XmlElement("date")]
        public string Date { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlArray("label-info-list")]
        [XmlArrayItem("label-info", IsNullable = false)]
        public List<ReleaseLabelinfo> Labelinfolist { get; set; }
        [XmlElement("medium-list")]
        public ReleaseMediumlist Mediumlist { get; set; }
        [XmlElement("packaging")]
        public string Packaging { get; set; }
        [XmlElement("release-event-list")]
        public ReleaseReleaseeventlist Releaseeventlist { get; set; }
        [XmlElement("release-group")]
        public ReleaseReleasegroup Releasegroup { get; set; }
        [XmlAttribute("score", Form = XmlSchemaForm.Qualified, Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public int Score { get; set; }
        [XmlElement("status")]
        public string Status { get; set; }
        [XmlElement("text-representation")]
        public ReleaseTextrepresentation Textrepresentation { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
    }

    public class ReleaseDataAndArtists
    {
        [XmlArray("artist-credit")]
        [XmlArrayItem("name-credit", IsNullable = false)]
        public List<ReleaseNamecredit> Artistcredit { get; set; }
        [XmlElement("asin")]
        public string Asin { get; set; }
        [XmlElement("barcode")]
        public string Barcode { get; set; }
        [XmlElement("country")]
        public string Country { get; set; }
        [XmlElement("date")]
        public string Date { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlArray("label-info-list")]
        [XmlArrayItem("label-info", IsNullable = false)]
        public List<ReleaseLabelinfo> Labelinfolist { get; set; }
        [XmlElement("medium-list")]
        public ReleaseMediumlist Mediumlist { get; set; }
        [XmlElement("packaging")]
        public string Packaging { get; set; }
        [XmlElement("release-event-list")]
        public ReleaseReleaseeventlist Releaseeventlist { get; set; }
        [XmlElement("release-group")]
        public ReleaseReleasegroup Releasegroup { get; set; }
        [XmlAttribute("score", Form = XmlSchemaForm.Qualified, Namespace = "http://musicbrainz.org/ns/ext#-2.0")]
        public int Score { get; set; }
        [XmlElement("status")]
        public string Status { get; set; }
        [XmlElement("text-representation")]
        public ReleaseTextrepresentation Textrepresentation { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        public List<ArtistDatas> ArtistCredit { get; set; }
        public List<LabelDatas> LabelInfo { get; set; }
    }

    public class ArtistDatas
    {
        [XmlElement("artist")]
        public RecordingArtist Artist { get; set; }
        [XmlAttribute("joinphrase")]
        public string Joinphrase { get; set; }
    }

    public class LabelDatas
    {
        [XmlElement("catalog-number")]
        public string Catalognumber { get; set; }
        [XmlElement("label")]
        public ReleaseLabelinfoLabel Label { get; set; }
    }


    #endregion
}
