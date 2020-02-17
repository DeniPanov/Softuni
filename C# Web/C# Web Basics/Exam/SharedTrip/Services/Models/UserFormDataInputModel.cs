namespace SharedTrip.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserFormDataInputModel
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
