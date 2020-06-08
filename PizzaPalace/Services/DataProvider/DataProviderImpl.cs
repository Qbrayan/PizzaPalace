using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaPalace.Models;
using PizzaPalace.Persistence.Repositories;
using PizzaPalace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalace.Services.DataProvider
{
    public class DataProviderImpl:IDataProvider
    {
        protected readonly IDataRepository _dataRepository;
        public DataProviderImpl(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<IEnumerable<Size>> GetSizes()
        {
            return await _dataRepository.GetSizes();
        }

        //public async Task<IEnumerable<SelectListItem>> GetToppings()
        //{
        //    return await _dataRepository.GetToppings();
        //}

        public async Task<PizzaViewModel> GetItems()
        {
            return await _dataRepository.GetItems();
        }

        public async Task<IEnumerable<Pizza>> GetProducts()
        {
            return await _dataRepository.GetProducts();
        }

        public async Task<string> CreateOrder(List<PizzaViewModel> model)
        {
            return await _dataRepository.CreateOrder(model);
        }
    }
}
