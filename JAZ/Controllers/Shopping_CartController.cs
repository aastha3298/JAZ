using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JAZ.Models;

namespace JAZ.Controllers
{
    public class Shopping_CartController : Controller
    {
        private JazModel db = new JazModel();

        // GET: Shopping_Cart
        public async Task<ActionResult> Index()
        {
            var shopping_Cart = db.Shopping_Cart.Include(s => s.Product).Include(s => s.User);
            return View(await shopping_Cart.ToListAsync());
        }

        // GET: Shopping_Cart/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart shopping_Cart = await db.Shopping_Cart.FindAsync(id);
            if (shopping_Cart == null)
            {
                return HttpNotFound();
            }
            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Product_Name");
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Username");
            return View();
        }

        // POST: Shopping_Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,User_ID,Product_ID,Product_Quantity")] Shopping_Cart shopping_Cart)
        {
            if (ModelState.IsValid)
            {
                db.Shopping_Cart.Add(shopping_Cart);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Product_Name", shopping_Cart.Product_ID);
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Username", shopping_Cart.User_ID);
            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart shopping_Cart = await db.Shopping_Cart.FindAsync(id);
            if (shopping_Cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Product_Name", shopping_Cart.Product_ID);
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Username", shopping_Cart.User_ID);
            return View(shopping_Cart);
        }

        // POST: Shopping_Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,User_ID,Product_ID,Product_Quantity")] Shopping_Cart shopping_Cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopping_Cart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Product_Name", shopping_Cart.Product_ID);
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Username", shopping_Cart.User_ID);
            return View(shopping_Cart);
        }

        // GET: Shopping_Cart/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart shopping_Cart = await db.Shopping_Cart.FindAsync(id);
            if (shopping_Cart == null)
            {
                return HttpNotFound();
            }
            return View(shopping_Cart);
        }

        // POST: Shopping_Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Shopping_Cart shopping_Cart = await db.Shopping_Cart.FindAsync(id);
            db.Shopping_Cart.Remove(shopping_Cart);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost, ActionName("EditCart")]
        public async Task<ActionResult> EditCart(int id, int qty)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping_Cart cart = await db.Shopping_Cart.FindAsync(id);
            cart.Product_Quantity = qty;
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
