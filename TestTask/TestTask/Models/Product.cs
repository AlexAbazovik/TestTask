using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Display (Name="Product name:")]
        [Required(ErrorMessage = "Enter a product name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Name { get; set; }
        [Display(Name = "Quantity:")]
        [Required(ErrorMessage = "Enter the number of goods")]
        public int Quantity { get; set; }
        [Display(Name="Barcode:")]
        [Required(ErrorMessage = "Enter the barcode")]
        [MinLength(13)]
        [MaxLength(13)]
        public string Barcode { get; set; }
    }
}