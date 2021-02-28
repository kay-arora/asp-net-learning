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
        //List<Customer> customers = new List<Customer>();
        List<Customer> customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "John Smith",
                    Id = 1
                },
                new Customer()
                {
                    Name = "Mary Williams",
                    Id = 2
                }
            };

        //GET: Customers
        public ActionResult Index()
        {


            var customerList = new CustomerListViewModel();
            customerList.Customers = customers;

            if (customerList.Customers == null || customerList.Customers.Count == 0)
                return Content("We don't have any customers");

            return View(customerList);
        }

        public ActionResult Details(int id)
        {
            var customer = customers.First(x => x.Id == id);
            return Content("Hello " + customer.Name);
        }
    }
}