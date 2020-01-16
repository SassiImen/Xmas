using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Areas.Membre.Models;
using Xmas.DAL.Models;
using Xmas.DAL.Repositories;
using Xmas.Models;
using Xmas.Tools;
using Xmas.Tools.Mappers;

namespace Xmas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }

  
        public ActionResult Login()
        {
            if (SessionUtils.IsConnected)
            {
                return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel m)
        {
            MembreRepository Mr = new MembreRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
          
            ProfileModel Mmodel = MapToDBModel.MemberToProfile(Mr.VerifLogin(MapToDBModel.LoginToMembre(m)));
            if (Mmodel != null)
            {
                SessionUtils.ConnectedUser =Mmodel;
                SessionUtils.IsConnected = true;
                return RedirectToAction("Index", new { controller = "Home", area = "Membre" });
            }
            else
            {
                ViewBag.ErrorLoginMessage = "Erreur Login/Mot de passe";
                return View();
            }

        }

        [HttpPost]
        public ViewResult Register(RegisterModel Rm, HttpPostedFileBase ProfilePicture)
        {

           
            List<string> matchContentType = new List<string>() { "image/jpeg", "image/png", "image/gif" };
            if (!matchContentType.Contains(ProfilePicture.ContentType) || ProfilePicture.ContentLength>80000)
            {
                ViewBag.ErrorMessage = "Le fichier ne possède pas une extension autorisée (png, jpg,gif)";
                return View("Login");
            }

           
            if (!ModelState.IsValid)
            {
               
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                       
                        ViewBag.ErrorMessage += error.ErrorMessage + "<br>";
                    }
                }
            }
            else
            {
                MembreRepository Mr = new MembreRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);
               
                Membre M = Mr.Insert(MapToDBModel.RegisterToMembre(Rm));
                if ( M!= null)
                {
                    string[] splitFileName = ProfilePicture.FileName.Split(new char[]{'.'}, StringSplitOptions.RemoveEmptyEntries);
                    string ext = splitFileName[splitFileName.Length - 1]; 

                  
                    string newFileName = M.Id + "." + ext;

                 
                    string folderpath = Server.MapPath("~/photos/");
                  
                    string FileNameToSave = folderpath + "/" + newFileName;
                

                    try
                    {
                        
                        ProfilePicture.SaveAs(FileNameToSave);
                    }
                    catch (Exception)
                    {
                        ViewBag.ErrorMessage = "L'image n'a pas pu être sauvée";
                        throw;
                    }



                    ViewBag.Login = Rm.Email;
                    ViewBag.SuccessMessage = "Vous pouvez vous connecter";
                }
                else
                {
                   
                    ViewBag.ErrorMessage = "Erreur lors de l'insertion";
                }

            }

            return View("Login");

        }


        public RedirectToRouteResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

    }
}