using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult ListCustomers()
        {

            var customers = new List<Customer>
            {
                new Customer{ Name = "Diego Vidal", Id = 0 },
                new Customer{ Name = "Victor Vidal", Id = 1 },
                new Customer{ Name = "Guilherme Augusto", Id = 2 },
                new Customer{ Name = "Waldir de Paula", Id = 3 }

            };

            var viewModel = new ListCustomersViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("customers/customerdetails/{customer}")]
        public ActionResult CustomerDetails(string customer)
        {

            ViewBag.Customer = customer;
            //return Content("Olá meu nome é " + customer);
            return View();
        }
    }
}