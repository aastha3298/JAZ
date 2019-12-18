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
    public class UsersController : Controller
    {
        private JazModel db = new JazModel();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.City1).Include(u => u.Country1);
            return View(await users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.City = new SelectList(db.Cities, "City_Code", "City_Name");
            ViewBag.Country = new SelectList(db.Countries, "Country_Code", "Country_Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Username,First_Name,Last_Name,Email,Phone_Number,Password,Role,StAddress,City,Province,PostalCode,Country")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.City = new SelectList(db.Cities, "City_Code", "City_Name", user.City);
            ViewBag.Country = new SelectList(db.Countries, "Country_Code", "Country_Name", user.Country);
            return View(user);
        }

        [Authorize]
        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.City = new SelectList(db.Cities, "City_Code", "City_Name", user.City);
            ViewBag.Country = new SelectList(db.Countries, "Country_Code", "Country_Name", user.Country);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,First_Name,Last_Name,Email,Phone_Number,Password,Role,StAddress,City,Province,PostalCode,Country")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                 db.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            ViewBag.City = new SelectList(db.Cities, "City_Code", "City_Name", user.City).Distinct();
            ViewBag.Country = new SelectList(db.Countries, "Country_Code", "Country_Name", user.Country).Distinct();
            var products = db.Products.Include(p => p.Product_Category1);
            return View("~/Views/Home/Index.cshtml",products);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
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
