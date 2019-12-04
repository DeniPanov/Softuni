namespace MusicHub.DataProcessor.ImportDtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ImportAlbumsDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}