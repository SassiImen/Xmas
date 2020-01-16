using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Xmas.Areas.Membre.Models;
using Xmas.DAL.Models;
using Xmas.DAL.Repositories;
using Xmas.Models;

namespace Xmas.Tools.Mappers
{

    public static class MapToDBModel
    {
        public static Membre LoginToMembre(LoginModel lm)
        {
            return new Membre()
            {
                Courriel = lm.Email,
                MotDePasse = lm.Password
            };
        }

        public static MembreModel MembreToMembreModel(Membre membre)
        {
            if (membre == null) return null;
            return new MembreModel()
            {
                Nom = membre.Nom
            };
        }

        internal static GroupModel GroupToGroupModel(object g)
        {
            throw new NotImplementedException();
        }

        public static GroupModel GroupToGroupModel(Groupe g)
        {
            return new GroupModel()
            {
                IdGroupe = g.IdGroupe,
                Description = g.Description,
                Nom = g.Nom
            };
        }

        public static Membre RegisterToMembre(RegisterModel rm)
        {
            return new Membre()
            {
                Nom = rm.Nom,
                Prenom = rm.Prenom,
                Surnom = rm.Surnom,
                Courriel = rm.Email,
                MotDePasse = rm.MotDePasse
            };
        }

        internal static ProfileModel MemberToProfile(Membre mmodel)
        {
            if (mmodel == null) return null;
            return new ProfileModel()
            {
                Id = mmodel.Id,
                Nom = mmodel.Nom,
                Prenom = mmodel.Prenom,
                Surnom = mmodel.Surnom,
                Email = mmodel.Courriel
            };
        }

    

        public static EditGroupModel GroupToEditGroupModel(Groupe g)
        {
            EditGroupModel Em = new EditGroupModel();

            Em.MonGroupe = new GroupModel()
            {
                IdGroupe = g.IdGroupe,
                Description = g.Description,
                Nom = g.Nom
            };
            EvenementRepository er = new EvenementRepository(ConfigurationManager.ConnectionStrings["CnstrDev"].ConnectionString);

            List<Evenement> ev = er.GetAll().ToList();
            Em.MesEvents = new List<EventModel>();
         
            foreach (Evenement item in ev)
            {
                Em.MesEvents.Add(MapToDBModel.EvenementToEventModel(item));
            }
            return Em;
        }

        private static EventModel EvenementToEventModel(Evenement item)
        {
            return new EventModel()
            {
                IdEvenement = item.IdEvenement,
                Nom = item.Nom
            };
        }
    }
}

