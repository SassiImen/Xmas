using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Xmas.Areas.Membre.Models
{
    public class ProfileModel
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _surnom;
        private string _email;
        private string _motDePasse;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Surnom
        {
            get
            {
                return _surnom;
            }

            set
            {
                _surnom = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }

            set
            {
                _motDePasse = value;
            }
        }

        public string Photo
        {
            get
            {
                return GetPhoto();
            }
 
        }
        /// <summary>
        /// Function to generate the path to the profile picture
        /// </summary>
        /// <returns></returns>
        private string GetPhoto()
        {
            //We can't use server.MapPath outside a Controller but we can use System.Web.Hosting.HostingEnvironment
            string folderpath = System.Web.Hosting.HostingEnvironment.MapPath("~/Photos/");
            string[] PicturesFiles = Directory.GetFiles(folderpath,Id+".*");

            if(PicturesFiles.Count()>0)
            {
                FileInfo i = new FileInfo(PicturesFiles[0]);
                

                return  "/Photos/"+ i.Name;
            }
            else
            {
                return "";
            }
        }
    }
}