using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.DAL.Models;

namespace Xmas.DAL.Repositories
{
    public class MembreRepository : BaseRepository<Membre, int>
    {
        public MembreRepository(string Cnstr) : base(Cnstr)
        {
            SelectOneCommand = "Select * from Membre where idMembre=@idMembre";
            SelectAllCommand = "Select * from Membre";
            InsertCommand = @"INSERT INTO  Membre (Nom ,Prenom ,Surnom ,Courriel ,MotDePasse)
                            OUTPUT inserted.idMembre VALUES(@Nom, @Prenom, @Surnom, @Courriel,@MotDePasse)";
            UpdateCommand = @"UPDATE  Membre
                           SET Nom = @Nom,  Prenom = @Prenom,  Surnom = @Surnom, Courriel = @Courriel,  MotDePasse = @MotDePasse>
                         WHERE IdMembre = @IdMembre;";
            DeleteCommand = @"Delete from  Membre  WHERE IdMembre = @IdMembre;";
        }

        public Membre VerifLogin(Membre membre)
        {
            SelectOneCommand = "Select * from Membre where Courriel=@Courriel and MotDePasse=@MotDePasse";
            return base.getOne(Map, MapToDico(membre)) ;
        }

        public override IEnumerable<Membre> GetAll()
        {
            return base.getAll(Map);
        }

        public override Membre GetOne(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("idMembre", id);              
            return base.getOne(Map, QueryParameters);
        }

        public override Membre Insert(Membre toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdMembre = id;
            return toInsert;
        }

        public override bool Update(Membre toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);
             
        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("@IdMembre", id);
            return base.Delete(QueryParameters);

        }


       
        private Dictionary<string, object> MapToDico(Membre toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["idMembre"] = toInsert.Id;
            p["Nom"] = toInsert.Nom;
            p["Prenom"] = toInsert.Prenom;
            p["Surnom"] = toInsert.Surnom;
            p["Courriel"] = toInsert.Courriel;
            p["MotDePasse"] = toInsert.MotDePasse;
            return p;
        }

        private Membre Map(SqlDataReader arg)
        {
            return new Membre()
            {
               IdMembre = (int)arg["idMembre"],
                Nom = arg["Nom"].ToString(),
                Prenom = arg["Prenom"].ToString(),
                Surnom = arg["Surnom"].ToString(),
                Courriel = arg["Courriel"].ToString(),
                MotDePasse= arg["MotDePasse"].ToString()
            };
        } 
       
    }
}
