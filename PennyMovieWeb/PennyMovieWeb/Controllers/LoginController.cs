using PennyMovieWeb.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PennyMovieWeb.Controllers
{
    public class LoginController : Controller
    {
        PennyMovieLogEntities1 db = new PennyMovieLogEntities1();
      
        public ActionResult RegisterIndex(MemberList Member)
        {
            //Member為request的list
            //如果資料驗證未通過則回傳原本的View
            if (!ModelState.IsValid)
            {
                return View();
            }
            // 如果註冊的帳號不存在，才能執行新增與儲存
            var member = db.MemberList.Where(m => m.UserID == Member.UserID).FirstOrDefault();
            if (member == null)
            {
                db.MemberList.Add(Member);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Message = "帳號已被使用，請重新註冊";

            return View();
        }
      
    }
}