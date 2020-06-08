using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaPalace.Models;
using PizzaPalace.Persistence.Context;
using PizzaPalace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPalace.Persistence.Repositories
{
    public class DataRepository:IDataRepository
    {
        protected readonly AppDbContext _context;

        public static TimeSpan Timeout = TimeSpan.FromSeconds(30);
        public DataRepository(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes()
        {

                List<SelectListItem> sizes = await _context.Sizes.AsNoTracking()
                    .OrderByDescending(n => n.Name)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name
                        }).ToListAsync();
                var sizetip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select size ---"
                };
                //sizes.Insert(0, sizetip);
                return new SelectList(sizes, "Value", "Text");

        }

        public async Task<IEnumerable<SelectListItem>> GetToppings()
        {

            List<SelectListItem> toppings = await _context.Toppings.AsNoTracking()
                .OrderBy(n => n.Name)
                    .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToListAsync();
            //var tip = new SelectListItem()
            //{
            //    Value = null,
            //    Text = "--- select topping ---"
            //};
            //toppings.Insert(0, tip);
           
            return new SelectList(toppings, "Value", "Text");

        }

        public async Task<PizzaViewModel> GetItems()
        {
            var pizza = new PizzaViewModel()
            {
                Sizes = await GetTypes(),
                Toppings = await GetToppings()
            };
            return pizza;


        }


        public async Task<IEnumerable<Pizza>> GetProducts()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<IEnumerable<Size>> GetSizes()
        {
            return await _context.Sizes.ToListAsync();
        }


        public async Task<string> CreateOrder(List<PizzaViewModel> models)
        {
            float subTotal = 0;
            string receipt = "";
            foreach(var model in models)
            {
                subTotal += model.Total;
            }

            float gst = Convert.ToSingle(Math.Round(0.05 * subTotal, 2));
            float total = gst + subTotal;

            var order = new Order
            {
                SubTotal = subTotal,
                Total = total
            };
            _context.Orders.Add(order);

            foreach (var model in models)
            {
                var details = new OrderDetails
                {
                    OrderId = order.Id,
                    Toppings = model.ProductName,
                    Size = model.Category,
                    UnitPrice = model.UnitPrice,
                    Units = model.Units,
                    Total = model.Total
                };
                receipt += $"1 {model.Category}, {model.ProductName.Split(',').ToList().Count} Topping Pizza - {model.ProductName} : {model.Total} \n";
                _context.OrderDetails.Add(details);
            }

            await _context.SaveChangesAsync();

            receipt += $"SubTotal:{subTotal} \n " +
                $"GST: {gst}\n" +
                $"Total: {total}\n";

            return receipt;

        }


    }
}
