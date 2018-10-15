using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StockMarketAPI.Models
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        [Required]
        public int Shares { get; set; }
        [Required]
        public string CurrentValue { get; set; }
        [Required]
        public double BoughtValue { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }
    }
}