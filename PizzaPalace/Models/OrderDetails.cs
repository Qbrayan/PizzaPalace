using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalace.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string Toppings { get; set; }

        public string Size { get; set; }

        public float UnitPrice { get; set; }

        public int Units { get; set; }

        public float Total { get; set; }

    }
}
