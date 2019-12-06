namespace MusicHub.DataProcessor.ExportDtos
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using MusicHub.Data.Models;

    [XmlType("Song")]
    public class ExportSongDto
    {
        [Required]
        [XmlElement("SongName")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [XmlElement("Writer")]
        public string Writer { get; set; }

        [XmlElement("Performer")]
        public string Performer { get; set; }

        [XmlElement("AlbumProducer")]
        public string AlbumProducer { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }
    }
}
