using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using SignalR_Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace SignalR_Chat.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var users = db.Users.Where(x => x.UserName != User.Identity.Name).ToList();
            ViewBag.Users = new SelectList(users, "UserName", "UserName");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var hub = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            hub.Clients.All.broadcast("Someone visited about!");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}