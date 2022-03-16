using Client_Server.Models.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client_Server.Controllers
{
    public class LoginController : Controller
    {
        Shop_Model db = new Shop_Model();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String name, String password)
        {
            foreach(var item in db.accounts)
            {
                if(item.username.Equals(name) && item.password.Equals(password))
                {
                    if(item.idRole == true)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                }
                else
                {
                    ViewBag.eror = "Thông Tin mật Khẩu Hoặc Tài Khoản Không Chính Xác";
                }
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection form)
        {
            account acc = new account();
            string fullname = form["fullname"];
            string Email = form["Email"];
            string password = form["password"];
            string RepeatPassword = form["RepeatPassword"];
            var result = db.accounts.Where(s=>s.username == Email).SingleOrDefault();
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(RepeatPassword) && password == RepeatPassword)
            {
                if (result != null)
                {
                    ViewBag.user = "Email Đã Được Đăng Ký";
                    return View();
                }
                else
                {
                    acc.NameCustomer = fullname;
                    acc.username = Email;
                    acc.password = password;
                    acc.idRole = false;
                    db.accounts.Add(acc);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                ViewBag.eror = "Đăng Ký Thất Bại Mời Bạn Nhập Lại!!!";
                return View();
            }
        }

    }
}