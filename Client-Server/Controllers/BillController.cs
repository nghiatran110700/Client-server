using Client_Server.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client_Server.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Shop_Model db = new Shop_Model();
        public ActionResult Index()
        {
            
            Session["Tongtien"] = db.detailBills
                                    .Join(db.bills, b => b.idBill, d => d.idBill,
                                        (b,d)=> new { Price = b.product.Price,Amount = b.amount, status = d.statusBill}).Where(s=>s.status == "Đã giao hàng")
                                        .Sum(s=>s.Price*s.Amount);
            return View(db.bills.OrderByDescending(s=>s.idBill).ToList());
        }
        public ActionResult Detail(int? id)
        {

            var lst = db.detailBills.Where(s=>s.idBill == id).ToList();
            Session["idbill"] = id;
              var trangthai  = db.bills.SingleOrDefault(s=>s.idBill == id);
            Session["trangthai"] = trangthai.statusBill;
            Session["tongbill"] = lst.Sum(s => s.product.Price * s.amount);
            return View(lst);
        }
        public ActionResult Edit(int? id)
        {
            var lst = db.bills.Find(id);
            if(lst != null){
                lst.statusBill = "Đang giao hàng";
                db.SaveChanges();
            }
            return RedirectToAction("Index","bill");
        }
    }
}