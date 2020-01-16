using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Areas.Membre.Models;
using Xmas.Models;

namespace Xmas.Tools
{
    public static class SessionUtils
    {
        public static bool IsConnected
        {
            get
            {
                if (HttpContext.Current.Session["IsConnected"] != null)
                {
                    return (bool)HttpContext.Current.Session["IsConnected"];
                }
                return false;

            }

            set
            {
                HttpContext.Current.Session["IsConnected"] = value;
            }
        }
        public static ProfileModel ConnectedUser
        {
            get 
            {
              if(HttpContext.Current.Session["ConnectedUser"]!=null)
                {
                    return (ProfileModel)HttpContext.Current.Session["ConnectedUser"];
                }
                return null;
               
            }

            set
            {
                HttpContext.Current.Session["ConnectedUser"] = value;
            }
        }
    }
}