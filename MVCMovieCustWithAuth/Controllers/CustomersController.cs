using MVCMovieCustWithAuth.Models;
using MVCMovieCustWithAuth.View_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMovieCustWithAuth.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MenberShipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var singleCustomer = _context.Customers.Include(c => c.MenberShipType).SingleOrDefault(c => c.Id == id);
            if (singleCustomer == null)
                return HttpNotFound();
            return View(singleCustomer);
        }
        [HttpGet]
        public ActionResult New()
        {
            var menberShipTypes = _context.MenberShipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MenberShipTypes = menberShipTypes
            };
            return View(viewModel);
        }
        //[HttpPost]
        //public ActionResult Create(Customer customer) //model Binding
        //{
        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Customers");
        //}

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.MenbershipTypeId = customer.MenbershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
  
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var updateCust = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (updateCust == null)
            {
                return HttpNotFound();
            }
            var vm = new NewCustomerViewModel
            {
                Customer = updateCust,
                MenberShipTypes = _context.MenberShipTypes.ToList()
            };
            return View("New", vm);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}