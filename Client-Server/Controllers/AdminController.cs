using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client_Server.Models.entity;
using Client_Server.Models.DTO;
using Client_Server.Models.DAO;
using System.IO;
using System.Net;
using System.Data.Entity;
using PagedList;

namespace Client_Server.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Shop_Model db = new Shop_Model();
        public ActionResult Index(string keyword, int pageNum = 1, int pageSize = 5)
        {
            ProductDAO dao = new ProductDAO();
            
            if (keyword != null)
            {
                return View(dao.searchByName(keyword));
            }
            return View(dao.list().ToPagedList(pageNum, pageSize));
        }
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
                if (uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Access/img/"), System.IO.Path.GetFileName(uploadhinh.FileName));
                    uploadhinh.SaveAs(path);
                    pro.img = uploadhinh.FileName;
                    
                    db.SaveChanges();
                }
                pro.status = true;
                db.products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idBrand = new SelectList(db.brands, "id", "NameBrand", pro.idBrand);
            ViewBag.idCate = new SelectList(db.categories, "idCategory", "NameCate", pro.idCate);
            return View(pro);
        }

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
        public ActionResult Edit([Bind(Include = "idProduct,NameProduct,Price,img,descriptions,idBrand,idCate,status")] product product,HttpPostedFileBase uploadhinh)
        {
            if (ModelState.IsValid)
            {
                if (uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Access/img/"), System.IO.Path.GetFileName(uploadhinh.FileName));
                    uploadhinh.SaveAs(path);
                    product.img = uploadhinh.FileName;
                    db.SaveChanges();
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idBrand = new SelectList(db.brands, "id", "NameBrand", product.idBrand);
            ViewBag.idCate = new SelectList(db.categories, "idCategory", "NameCate", product.idCate);
            return View(product);
        }
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