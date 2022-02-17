using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Client_Server.Models.entity;

namespace Client_Server.Controllers
{
    public class productsController : Controller
    {
        private Shop_Model db = new Shop_Model();

        // GET: products
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.brand).Include(p => p.category);
            return View(products.ToList());
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.idBrand = new SelectList(db.brands, "id", "NameBrand");
            ViewBag.idCate = new SelectList(db.categories, "idCategory", "NameCate");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProduct,NameProduct,Price,img,descriptions,idBrand,idCate,status")] product pro, HttpPostedFileBase uploadhinh)
        {
            if (ModelState.IsValid)
            {
                if(uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Access/img/"), System.IO.Path.GetFileName(uploadhinh.FileName));
                    uploadhinh.SaveAs(path);
                    pro.img = uploadhinh.FileName;
                    db.SaveChanges();
                }
                db.products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBrand = new SelectList(db.brands, "id", "NameBrand", pro.idBrand);
            ViewBag.idCate = new SelectList(db.categories, "idCategory", "NameCate", pro.idCate);
            return View(pro);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.idBrand = new SelectList(db.brands, "id", "NameBrand", product.idBrand);
            ViewBag.idCate = new SelectList(db.categories, "idCategory", "NameCate", product.idCate);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProduct,NameProduct,Price,img,descriptions,idBrand,idCate,status")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBrand = new SelectList(db.brands, "id", "NameBrand", product.idBrand);
            ViewBag.idCate = new SelectList(db.categories, "idCategory", "NameCate", product.idCate);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
