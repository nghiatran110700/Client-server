using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Client_Server.Models.entity;
using System.Threading.Tasks;
using Client_Server.Models.DAO;
using Client_Server.Models.DTO;
using System.Net;
using PagedList;

namespace Client_Server.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Shop_Model db = new Shop_Model();
        ProductDAO dao = new ProductDAO();
        public ActionResult Index()
        {
            var lst = dao.list().OrderByDescending(s=>s.idProduct).Take(6).ToList();
            return View(lst);
        }

        public ActionResult GetAllProduct(int pageNum = 1, int pageSize = 9)
        {
            var lst = dao.list();
            return View(lst.ToList().ToPagedList(pageNum,pageSize));
        }
        public ActionResult Category()
        {
            return PartialView(db.categories.ToList());
        }
        public ActionResult Brand()
        {
            var lst = db.products.GroupBy(s => s.idBrand).Join(db.brands, g => g.Key, b => b.id, (g,b) => new {Count = g.Count(), Name = b.NameBrand,id = b.id });
            
            List<CateDTO> c = new List<CateDTO>();
            foreach(var item in lst)
            {
                CateDTO p = new CateDTO();
                p.id = item.id;
                p.Count = item.Count;
                p.Name = item.Name;
                c.Add(p);
            }
            return PartialView(c.ToList());
        }
        public ActionResult DetailProduct(int? id)
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
        public ActionResult SearchByCate(int? id)
        {
            
            var lst = db.products.Where(s => s.idCate == id);
            if (lst != null)
            {
                return View(lst.ToList());
            }
            return RedirectToAction("Index","Customer");
        }
        
        public ActionResult SearchByBrand(int? id)
        {
            var lst = db.products.Where(s => s.idBrand == id);
            if(lst != null)
            {
                return View(lst.ToList());
            }
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult SearchByName(string keyword)
        {
            var lst = dao.searchByName(keyword).ToList();
            if(lst != null){
                return View(lst);
            }
            return RedirectToAction("ErorSearch", "Customer");
        }
        public ActionResult Recomenđe()
        {
            var pro = db.detailBills
                .GroupBy(s => s.idProduct)
                .Join(db.products, g => g.Key, p => p.idProduct, (g, p) => 
                new {NamePro = p.NameProduct,
                     idpro =  p.idProduct,
                     img = p.img,
                     price = p.Price,
                     count = g.Count()
                }).OrderByDescending(g=>g.count).Take(6).ToList();
            List<RemcomedPro> lst = new List<RemcomedPro>();
            foreach(var item in pro)
            {
                RemcomedPro r = new RemcomedPro();
                r.name = item.NamePro;
                r.id = item.idpro;
                r.img = item.img;
                r.count = item.count;
                r.price = item.price;
                lst.Add(r);
            }
            return PartialView(lst);
        }
        public ActionResult detailbill(int? id)
        {
            Session["Madonhang"] = id;
            var trangthai = db.bills.SingleOrDefault(s => s.idBill == id);
            Session["trangthai"] = trangthai.statusBill;
            @Session["tongbill"] = db.detailBills.Sum(s => s.product.Price * s.amount);
            return View(db.detailBills.Where(s=>s.idBill == id));
        }
        public ActionResult deleteBill(int? id)
        {
            var bill = db.bills.Find(id);
            if(bill != null)
            {
                bill.statusBill = "Đã Hủy đơn Hàng";
                db.SaveChanges();
                return RedirectToAction("History","ShoppingCart");
            }
            return View();
        }
        public ActionResult AgreeBill(int? id)
        {
            var bill = db.bills.Find(id);
            if (bill != null)
            {
                bill.statusBill = "Đã nhận hàng";
                db.SaveChanges();
                return RedirectToAction("History", "ShoppingCart");
            }
            return View();
        }
        public ActionResult AgainBill(int? id)
        {
            var bill = db.bills.Find(id);
            if (bill != null)
            {
                bill.statusBill = "Đơn hàng mới chưa được xác nhận";
                db.SaveChanges();
                return RedirectToAction("History", "ShoppingCart");
            }
            return View();
        }
    }
}