using JAZ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JAZ.Controllers
{
    public class HomeController : Controller
    {
        private JazModel db = new JazModel();
        public async Task<ActionResult> Index()
        {
            var products = db.Products.Include(p => p.Product_Category1);
            ViewBag.id = db.Users.AsEnumerable().Where(x => x.Email.Equals(User.Identity.Name)).Select(x => x.ID).FirstOrDefault();
            return View(await products.ToListAsync());
        }

        public PartialViewResult Search(string name)
        {
            var productList = db.Products.AsEnumerable().Where(x => x.Product_Name.Equals(name));
            return PartialView(productList);
        }
        [Authorize]
        public ActionResult AddToCart(int cartid)
        {
            List<Product> list = new List<Product>();
         
            Shopping_Cart cart = new Shopping_Cart();
            if (User.Identity.IsAuthenticated)
            {

                Product product = new Product();
                try
                {
                    cart.User_ID = db.Users.Where(x => x.Email.Equals(User.Identity.Name)).Select(x => x.ID).FirstOrDefault();
                    cart.Product_ID = cartid;
                    cart.Product_Quantity = 1;
                    product.ID = cartid;
                    product.Product_Qantity = db.Products.Where(x => x.ID.Equals(cartid)).Select(x => x.Product_Qantity).FirstOrDefault() - 1;
                    //dc.Entry(books).Property("Quantity").IsModified = true;
                    db.Shopping_Cart.Add(cart);
                    db.SaveChanges();
                    //ViewBag.Data = dc.shopping_cart.Where(x => x.customer_info.Email == User.Identity.Name).Count();
                    list = db.Products.ToList();
                }
                catch (Exception ex)
                {
                }

                return View("Index", list);
            }
            else
            {
                ViewBag.Data = 0;
                list = db.Products.ToList();
                ViewBag.error = "Please Login to add to cart";
                return View("Index", list);
            }
        }
        public ActionResult ViewCategory(string category)
        {
            if (category.Equals("Sea Shells"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Category1.Product_Type.Equals(category));
                ViewBag.msg = data.Count() + " Product(s) Found!";
                return View("Index", data);
            }
            else if (category.Equals("Paper"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Category1.Product_Type.Equals(category));
                ViewBag.msg = data.Count() + " Products(s) Found!";
                return View("Index", data);
            }
            else if (category.Equals("Upcycle"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Category1.Product_Type.Equals(category));
                ViewBag.msg = data.Count() + " Products(s) Found!";
                return View("Index", data);
            }
            else 
            {
                ViewBag.msg = "No Product found";
                ViewBag.color = "red";
                return View("Index",new List<Product>());
            }
        }
        public PartialViewResult ViewPrice(int price)
        {
            if (price.Equals("4"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Price <=(price));
                ViewBag.msg = data.Count() + " Products(s) Found!";
                return PartialView("_PartialViewPrice", data);
            }
            else if (price.Equals("10"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Price <=price && x.Product_Price >4);
                ViewBag.msg = data.Count() + " Product(s) Found!";
                return PartialView("_PartialViewPrice", data);
            }
            else if (price.Equals("15"))
            {
                ViewBag.color = "green";
                var data = db.Products.AsEnumerable().Where(x => x.Product_Price >10 && x.Product_Price <=20);
                ViewBag.msg = data.Count() + " Products(s) Found!";
                return PartialView("_PartialViewPrice", data);
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