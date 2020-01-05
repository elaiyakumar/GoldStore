using System;
using System.ComponentModel.DataAnnotations;

namespace GoldStore.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string OrderCode { get; set; }
        public int PoductId { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
    }
}