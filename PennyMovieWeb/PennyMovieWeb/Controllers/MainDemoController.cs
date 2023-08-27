using PennyMovieWeb.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PennyMovieWeb.Controllers
{
    public class MainDemoController : Controller
    {
        PennyMovieLogEntities1 db = new PennyMovieLogEntities1();  //dataBase Context設定參數
        // GET: MainDemo
        public ActionResult Index()
        {
            var model = db.TWMovieList.OrderByDescending(tw=>tw.PublishYear).ToList();
            return View(model);
        }
        public ActionResult JPIndex()
        {
            var model = db.JPMovieList.OrderByDescending(j=>j.PublishYear).ToList();
            return View(model);
        }
        public ActionResult USIndex()
        {
            var model = db.USAMovieList.OrderByDescending(us=>us.PublishYear).ToList();
            return View(model);
        }


        //GET: Demo/ShowHelloWorld
        [HttpGet] //可省略 因預設本來就是get
        public string ShowHelloWorld()
        {
            return "Hello World!";
        }
    }
}