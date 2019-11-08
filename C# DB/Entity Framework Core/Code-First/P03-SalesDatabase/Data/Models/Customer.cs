namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public int CustomerId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(80)]
        [Required]
        public string Email { get; set; }


        [Required]
        public string CreditCardNumber { get; set; }

        public int SalesId { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

    }
}
