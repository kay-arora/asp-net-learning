using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.DataLayer;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private AppDbContext _context;
        //List<Customer> customers = new List<Customer>();
        List<Customer> customersData = new List<Customer>()
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

        public CustomersController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //GET: Customers
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            
            var customerList = new CustomerListViewModel();
            customerList.Customers = customers;

            if (customerList.Customers == null || customerList.Customers.Count == 0)
                return Content("We don't have any customers");

            return View(customerList);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var customer = customers.First(x => x.Id == id);

            return View(customer);
            //return Content("Hello " + customer.Name);
        }
    }
}