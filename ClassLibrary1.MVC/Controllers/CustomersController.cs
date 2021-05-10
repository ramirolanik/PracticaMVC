
using ClassLibrary1.Entities;
using ClassLibrary1.Logic;
using ClassLibrary1.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassLibrary1.MVC.Controllers
{
    public class CustomersController : Controller
    {
        CustomersLogic logic = new CustomersLogic();
        // GET: Categories
        public ActionResult Index()
        {            
            List<Entities.Customers> customers = logic.GetAll();

            List<CustomersView> customersViews = customers.Select(s => new CustomersView
            {
                CustomerID = s.CustomerID,

                CompanyName = s.CompanyName,

                ContactName = s.ContactName,
            }).ToList();       
                                   
            
            return View(customersViews);
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CustomersView customerView)
        {
            try
            {
                Customers CustomersEntity = new Customers { CompanyName = customerView.CompanyName, CustomerID = customerView.CustomerID, ContactName = customerView.ContactName }; 
                
                logic.Add(CustomersEntity);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Error");
            }
        }

    }
}