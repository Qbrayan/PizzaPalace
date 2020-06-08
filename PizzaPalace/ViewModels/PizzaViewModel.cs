using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalace.ViewModels
{
    public class PizzaViewModel
    {
       

        public int ProductID { get; set; }


        [Required]
        [Display(Name = "Toppings")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Unit price")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public float UnitPrice { get; set; }

        [Display(Name = "Number of Units")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public int Units  { get;set;}

        [Display(Name = "Total price")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public float Total { get; set; }

        public IEnumerable<SelectListItem> Sizes { get; set; }


        public IEnumerable<SelectListItem> Toppings { get; set; }
    }
}
