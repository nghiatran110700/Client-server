using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Client_Server.Models.entity;

namespace Client_Server.Controllers
{
    public class DiscountController : Controller
    {
        private Shop_Model db = new Shop_Model();

        // GET: Discount
        public ActionResult Index()
        {
            return View(db.discouts.ToList());
        }

        // GET: Discount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discout discout = db.discouts.Find(id);
            if (discout == null)
            {
                return HttpNotFound();
            }
            return View(discout);
        }

        // GET: Discount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDiscount,NameDiscout,percents,StartDay,EndDay")] discout discout)
        {
            if (ModelState.IsValid)
            {
                db.discouts.Add(discout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discout);
        }

        // GET: Discount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discout discout = db.discouts.Find(id);
            if (discout == null)
            {
                return HttpNotFound();
            }
            return View(discout);
        }

        // POST: Discount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDiscount,NameDiscout,percents,StartDay,EndDay")] discout discout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discout);
        }

        // GET: Discount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            discout discout = db.discouts.Find(id);
            if (discout == null)
            {
                return HttpNotFound();
            }
            return View(discout);
        }

        // POST: Discount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            discout discout = db.discouts.Find(id);
            db.discouts.Remove(discout);
            db.SaveChanges();
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
