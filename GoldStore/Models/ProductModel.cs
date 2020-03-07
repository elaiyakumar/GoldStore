using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoldStore.Models
{
    public class ProductModel
    {
        public ProductModel()
        {           
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BatchNum { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        public int Count { get; set; }
    }
}