namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportPerformersSongsDto
    {
        [XmlAttribute("id")]
        public int SongId { get; set; }
    }
}