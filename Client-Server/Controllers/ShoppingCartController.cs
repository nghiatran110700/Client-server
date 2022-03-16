using Client_Server.Models.DTO;
using Client_Server.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client_Server.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        Shop_Model db = new Shop_Model();
        public cart getCart()
        {
            cart c =  Session["Cart"] as cart;
            if(c == null || Session["Cart"] == null)
            {
                c = new cart();
                Session["Cart"] = c;
            }
            return c;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddtoCart(int? id,int size)
        {
            product p = db.products.Find(id);
            if(p != null)
            {
                getCart().addProduct(p,size);
            }
            Session["total"] = getCart().tota_bill();
            return RedirectToAction("ShowCart","ShoppingCart");
        }
        public ActionResult addCart(FormCollection form)
        {
            int id = Int32.Parse(form["idProduct"]);
            int size = Int32.Parse(form["size"]);
            product p = db.products.Find(id);
            if (p != null)
            {
                getCart().addProduct(p, size);
            }
            Session["total"] = getCart().tota_bill();
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("ShowCart", "ShoppingCart");
            }
            cart c = Session["Cart"] as cart;
            return View(c);
        }
        
        public ActionResult RemoveCart(int id, int size)
        {
            cart c = Session["Cart"] as cart;
            c.remove(id, size);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult Sale(FormCollection form)
        {
            int code = Int32.Parse(form["sale"]);
            if (code != null)
            {
                var dis = db.discouts.Where(s=>s.StartDay < DateTime.Now && s.EndDay >DateTime.Now).SingleOrDefault(s => s.idDiscount == code);
                Session["conlai"] = (getCart().tota_bill() * dis.percents)/100;
            }
            else
            {
                Session["total"] = getCart();
            }    
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        [HttpPost]
        public ActionResult UpdateCart(FormCollection form)
        {
            cart c = Session["Cart"] as cart;
            int id = Int32.Parse(form["idProduct"]);
            int soluong = Int32.Parse(form["soluong"]);
            int sizeold = Int32.Parse(form["sizeold"]);
            int size = Int32.Parse(form["size"]);
            c.update(id,sizeold, size, soluong);
            Session["total"] = getCart().tota_bill();
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult History()
        {
            var lst = db.bills.OrderByDescending(s=>s.idBill).Where(s => s.idCustomer == 2).ToList();
            return View(lst);
        }
        public ActionResult CkechOut(FormCollection form)
        {
            try {
                cart c = Session["Cart"] as cart;
                bill _bill = new bill();
                _bill.phone = form["sdt"];
                _bill.addressCustomer = form["diachi"];
               
                _bill.idDiscount = 2;
                _bill.idCustomer = 2;
                _bill.statusBill = "Đơn hàng mới chưa được xác nhận";
                _bill.billDate = DateTime.Now;
                db.bills.Add(_bill);
                foreach (var item in c.Item)
                {
                    detailBill _detailBill = new detailBill();
                    _detailBill.idBill = _bill.idBill;
                    _detailBill.idProduct = item.product.idProduct;
                    _detailBill.amount = item.soLuong;
                    _detailBill.size = item.size;
                    db.detailBills.Add(_detailBill);
                }
                db.SaveChanges();
                c.clear();
                return RedirectToAction("History","ShoppingCart");
               // return RedirectToAction("History", "ShoppingCart");
            }
            catch {
                return Content("Lỗi khi mua hàng mời bạn kiểm tra lại thông tin ");
            }
        }

    }

}