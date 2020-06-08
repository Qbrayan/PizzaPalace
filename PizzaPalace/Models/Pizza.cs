using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalace.Models
{
    public class Pizza
    {

        [Key]
        public string Id { get; set; }

        public string Size { get; set; }

        public string Topping { get; set; }

        public float Price { get; set; }
    }

}
