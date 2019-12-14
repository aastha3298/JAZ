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
    public class Order_TransactionsController : Controller
    {
        private JazModel db = new JazModel();

        // GET: Order_Transactions
        public async Task<ActionResult> Index()
        {
            var order_Transactions = db.Order_Transactions.Include(o => o.User);
            return View(await order_Transactions.ToListAsync());
        }
        [Authorize]

        // GET: billing
        public ActionResult billing()
        {
            var order_Transactions = db.Order_Transactions.Where(x=>x.User.Email.Equals(User.Identity.Name)).FirstOrDefault();
            return View(order_Transactions);
        }
        public ActionResult Confirmation()
        {
            var order_Transactions = db.Order_Transactions.Include(o => o.User);
            return View("Index", order_Transactions.ToListAsync());
        }
        // GET: Order_Transactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Transactions order_Transactions = await db.Order_Transactions.FindAsync(id);
            if (order_Transactions == null)
            {
                return HttpNotFound();
            }
            return View(order_Transactions);
        }

        // GET: Order_Transactions/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Username");
            return View();
        }

        // POST: Order_Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Transaction_ID,User_ID,Transaction_Date,Delivery_Date,Payment_Status,Transaction_Total")] Order_Transactions order_Transactions)
        {
            if (ModelState.IsValid)
            {
                db.Order_Transactions.Add(order_Transactions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.Users, "ID", "Username", order_Transactions.User_ID);
            return View(order_Transactions);
        }

        // GET: Order_Transactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Transactions order_Transactions = await db.Order_Transactions.FindAsync(id);
            if (order_Transactions == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Username", order_Transactions.User_ID);
            return View(order_Transactions);
        }

        // POST: Order_Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Transaction_ID,User_ID,Transaction_Date,Delivery_Date,Payment_Status,Transaction_Total")] Order_Transactions order_Transactions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Transactions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.Users, "ID", "Username", order_Transactions.User_ID);
            return View(order_Transactions);
        }

        // GET: Order_Transactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Transactions order_Transactions = await db.Order_Transactions.FindAsync(id);
            if (order_Transactions == null)
            {
                return HttpNotFound();
            }
            return View(order_Transactions);
        }

        // POST: Order_Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order_Transactions order_Transactions = await db.Order_Transactions.FindAsync(id);
            db.Order_Transactions.Remove(order_Transactions);
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
