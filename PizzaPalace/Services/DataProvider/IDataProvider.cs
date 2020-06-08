using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPalace.Models;
using PizzaPalace.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalace.Services.DataProvider
{
    public interface IDataProvider
    {
        Task <IEnumerable<Size>> GetSizes();

        Task <IEnumerable<Pizza>> GetProducts();

        Task<PizzaViewModel> GetItems();

        Task <string> CreateOrder(List<PizzaViewModel> model);

    }
}
