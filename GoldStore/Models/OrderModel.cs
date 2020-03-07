using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoldStore.Models
{
    public class OrderModel
    {

        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();
        }

        public int Id { get; set; }

        public string OrderCode { get; set; }
        public int OrderStatusId { get; set; }
        public decimal OrderTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }


        public IList<OrderItemModel> OrderItems { get; set; }
    }
}