using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int SalesId { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();


    }
}
