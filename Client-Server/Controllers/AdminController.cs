using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client_Server.Models.entity;
using Client_Server.Models.DTO;
using Client_Server.Models.DAO;
using System.IO;

namespace Client_Server.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Shop_Model db = new Shop_Model();   
        public ActionResult Index(string keyword)
        {
            ProductDAO dao = new ProductDAO();
            
            if (keyword != null)
            {
                return View(dao.searchByName(keyword));
            }
            return View(dao.list());
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
    }
}