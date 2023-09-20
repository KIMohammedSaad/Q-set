using System;
using System.ComponentModel.DataAnnotations;


namespace Q_set1.Models
{

    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MfgDate { get; set; }

        [Required]
        public string Category { get; set; }
    }

}
