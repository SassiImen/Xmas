using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Areas.Membre.Models;
using Xmas.DAL.Repositories;
using Xmas.Tools;
using Xmas.Tools.Mappers;

namespace Xmas.Areas.Membre.Controllers
{
    public class GroupController : Controller
    {
       
        public ActionResult Index()
        {

            GroupeRepository GR = new GroupeRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            int id = SessionUtils.ConnectedUser.Id;
            List<GroupModel> Lgm = GR.GetAllFromMembre(id).Select(g => MapToDBModel.GroupToGroupModel(g)).ToList();
            ViewBag.Current = "Groupe";
            return View(Lgm);
            
        }

        public ActionResult Admin()
        {
            if (!SessionUtils.IsConnected)
            {
                return RedirectToAction("Login", new { Controller = "Home", area = "" });
            }

            GroupeRepository GR = new GroupeRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
            int id = SessionUtils.ConnectedUser.Id;
            List<GroupModel> Lgm = GR.GetAllFromMembre(id, true).Select(g => MapToDBModel.GroupToGroupModel(g)).ToList();
            ViewBag.Current = "Groupe Admin";
            return View(Lgm);
        }
    }
}
