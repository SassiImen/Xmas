using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Tools;

namespace Xmas.Areas.Membre.Controllers
{
    public class HomeController : Controller
    {
        // GET: Membre/Home
        public ActionResult Index()
        {
            if (!SessionUtils.IsConnected)
            {
                return RedirectToAction("Login", new { controller = "Home", area = "" });
            }
            else
            {
                ViewBag.Nom = SessionUtils.ConnectedUser.Nom;
                
                return View(SessionUtils.ConnectedUser);
            }
             
            
        }
    }
}