using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PizzaPalace.Models;
using PizzaPalace.Services.DataProvider;
using PizzaPalace.ViewModels;

namespace PizzaPalace.Controllers
{
    public class HomeController : Controller
    {

        protected IDataProvider _dataProvider;
        private static readonly List<PizzaViewModel> products = new List<PizzaViewModel>();
        private static  IEnumerable<Pizza>  subproduct_types = new List<Pizza>();
        private static IEnumerable<Size> product_types = new List<Size>();
        public HomeController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }


        public async Task <IActionResult> Index()
        {
            product_types = await _dataProvider.GetSizes();
            subproduct_types =  await _dataProvider.GetProducts();
            var pizzaList=await _dataProvider.GetItems();
            return View(pizzaList);
        }

        [HttpGet]
        public ActionResult AddCart(PizzaViewModel order)
        {
            try
            {
                //dynamic json = JsonConvert.DeserializeObject(order);
                string size= order.Category;
                string toppings = order.ProductName;
                List<string> val =toppings.Split(',').ToList();

                var first = products.OrderByDescending(e => e.ProductID).FirstOrDefault();
                var id = (first != null) ? first.ProductID : 0;

                var size_price = product_types.FirstOrDefault(x => x.Id == size).Price;
                var t_price = subproduct_types.Where(x => x.Size == size && val.Contains(x.Topping))
                    .Sum(i=> i.Price);
                var unit_price = size_price + t_price;

                var product = new PizzaViewModel()
                {
                    ProductID =id+1,
                    ProductName=toppings,
                    Category=size,
                    UnitPrice=unit_price,
                    Units=1,
                    Total= unit_price *1

                };

                products.Add(product);
                return new JsonResult(products);

            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Destroy(int? id)
        {
     
            if (id >0)
            {              
                products.Remove(products.First(x => x.ProductID == id));

            }
            return Json(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string val = await _dataProvider.CreateOrder(products);
                    if (val != null)
                    {
                        return Json(val);
                    }
                }
                // Handling model state errors is beyond the scope of the demo, so just throwing an ApplicationException when the ModelState is invalid
                // and rethrowing it in the catch block.
                throw new ApplicationException("Invalid model");
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
