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

        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipType
            };
            return View("CustomerForm", viewModel);
        }

        //use post when we modify data
        [HttpPost]
        public ActionResult Save(Customer customer) //model binding is when MVC framework binds the request to a C# Model
        {
            if(customer.Id == 0)
            {
                //add customer to DB
                _context.Customers.Add(customer); //at this point its not saved to the DB, it's just in the memory
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            //dbcontext has a tracking mechanism and would mark a record as added, modify or deleted 
            _context.SaveChanges(); //at this point SQL statements are generated and DB changes are made

            return RedirectToAction("Index", "Customers");

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm", viewModel); //to override the default view "Edit", we can pass a parameter to view to identify any other view
        }
    }
}