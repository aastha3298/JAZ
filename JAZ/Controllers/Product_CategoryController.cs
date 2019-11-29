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
    public class Product_CategoryController : Controller
    {
        private JazModel db = new JazModel();

        // GET: Product_Category
        public async Task<ActionResult> Index()
        {
            return View(await db.Product_Category.ToListAsync());
        }

        // GET: Product_Category/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = await db.Product_Category.FindAsync(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View(product_Category);
        }

        // GET: Product_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Product_Type")] Product_Category product_Category)
        {
            if (ModelState.IsValid)
            {
                db.Product_Category.Add(product_Category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product_Category);
        }

        // GET: Product_Category/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = await db.Product_Category.FindAsync(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View(product_Category);
        }

        // POST: Product_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Product_Type")] Product_Category product_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product_Category);
        }

        // GET: Product_Category/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Category product_Category = await db.Product_Category.FindAsync(id);
            if (product_Category == null)
            {
                return HttpNotFound();
            }
            return View(product_Category);
        }

        // POST: Product_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product_Category product_Category = await db.Product_Category.FindAsync(id);
            db.Product_Category.Remove(product_Category);
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
    }
}
