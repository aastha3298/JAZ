using JAZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JAZ.Controllers
{
    public class HomeController : Controller
    {
        private JazModel db = new JazModel();
        public ActionResult Index()
        {
            var productList = db.Products.AsEnumerable();
            return View(productList);
        }

        public ActionResult Search(string name)
        {
            var productList = db.Products.AsEnumerable().Where(x => x.Product_Name.Equals(name));
            return View(productList);
        }
        public ActionResult ViewCategory(string category)
        {
            if (category.Equals("Collection1"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Category1.Product_Type.Equals(category));
                ViewBag.msg = data.Count() + " Product(s) Found!";
                return PartialView("ViewCategory", data);
            }
            else if (category.Equals("Collection2"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Category1.Product_Type.Equals(category));
                ViewBag.msg = data.Count() + " Products(s) Found!";
                return PartialView("ViewCategory", data);
            }
            else if (category.Equals("Collection3"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Category1.Product_Type.Equals(category));
                ViewBag.msg = data.Count() + " Products(s) Found!";
                return PartialView("ViewCategory", data);
            }
            else 
            {
                ViewBag.msg = "No Product found";
                ViewBag.color = "red";
                return PartialView("ViewCategory",new List<Product>());
            }
        }
        public ActionResult ViewPrice(int price)
        {
            if (price.Equals("4"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Price <=(price));
                ViewBag.msg = data.Count() + " Products(s) Found!";
                return PartialView("ViewPrice", data);
            }
            else if (price.Equals("10"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Price <=price);
                ViewBag.msg = data.Count() + " Product(s) Found!";
                return PartialView("ViewPrice", data);
            }
            else if (price.Equals("Collection3"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Price >10 && x.Product_Price <=20);
                ViewBag.msg = data.Count() + " Products(s) Found!";
                return PartialView("ViewPrice", data);
            }
            else
            {
                ViewBag.msg = "No Product found";
                ViewBag.color = "red";
                return PartialView("ViewPrice", new List<Product>());
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}