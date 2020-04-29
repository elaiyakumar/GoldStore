using System.Web.Mvc; 
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GoldStore.Models
{
    public class OrderItemModel
    {
        public OrderItemModel()
        {
            AvailableProducts = new List<SelectListItem>(); 
        }
        
        public int Id { get; set; }

        public int? OrderId { get; set; }

        [Required(ErrorMessage = "Please select a Product")]
        public int? ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal Cost { get; set; }

        //public string ProductName { get; set; }
        //public IList<ProductModel> Products { get; set; }

 
        public IList<SelectListItem> AvailableProducts { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
    }
}