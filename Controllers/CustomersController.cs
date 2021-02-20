using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LatihanAPIMVC.Controllers
{
    public class CustomersController : Controller
    {

        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44392/api/")
        };

        public ActionResult Index()
        {
            IEnumerable<Customer> customers = null;

            // concat dengan base adddress
            var responseTask = client.GetAsync("Customers");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Customer>>();
                readTask.Wait();
                customers = readTask.Result;
            }

            return View(customers);
        }


        public async Task<ActionResult> Details(int id)
        {
            var response = await client.GetAsync("Customers");
            var result = await response.Content.ReadAsAsync<IList<Customer>>();
            var customers = result.FirstOrDefault(c => c.Id == id);

            return View(customers);
        }

       
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public ActionResult Create(Customer customers)
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync("Customers", customers).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
        public async Task<ActionResult> Edit(int id)
        {
            var response = await client.GetAsync("Customers");
            var result = await response.Content.ReadAsAsync<IList<Customer>>();
            var customers = result.FirstOrDefault(c => c.Id == id);

            return View(customers);
        }

      
        [HttpPost]
        public ActionResult Edit(int id, Customer customers)
        {
            try
            {
                HttpResponseMessage response = client.PutAsJsonAsync<Customer>
                    ("Customers/" + id.ToString(), customers).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

     
        public async Task<ActionResult> Delete(int id)
        {
            var response = await client.GetAsync("Customers");
            var result = await response.Content.ReadAsAsync<IList<Customer>>();
            var customer = result.FirstOrDefault(c => c.Id == id);

            return View(customer);
        }

    
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync("Customers/" + id.ToString()).Result;

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.ToString();

                return View();
            }
        }
    }
}
