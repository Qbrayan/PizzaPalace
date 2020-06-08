using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalace.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public float SubTotal { get; set; }

        public float Total { get; set; }

    }
}
