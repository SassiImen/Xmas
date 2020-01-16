using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.DAL.Models;

namespace Xmas.DAL.Repositories
{
    public class CadeauRepository : BaseRepository<Cadeau, int>
    {
        public CadeauRepository(string Cnstr) : base(Cnstr)
        { 
            SelectAllCommand = "SELECT * FROM Cadeau";
            SelectOneCommand = "SELECT * FROM Cadeau WHERE IdCadeau=@IdCadeau ";
            InsertCommand = "INSERT INTO Cadeau(Nom,Description,Magasin,Prix,IdMembre) OUTPUT inserted.IdCadeau VALUES (@Nom,@Description,@Magasin,@Prix,@IdMembre)";
            UpdateCommand = "UPDATE Cadeau SET Nom=@Nom,Description=@Description,Magasin=@Magasin,Prix=@Prix,IdMembre=@IdMembre WHERE IdCadeau=@IdCadeau";
            DeleteCommand = "DELETE FROM  Cadeau WHERE IdCadeau=@IdCadeau";
        }

        public Cadeau VerifLogin(Cadeau cadeau)
        {
            SelectOneCommand = "Select * from Cadeau where Courriel=@Courriel and MotDePasse=@MotDePasse";
            return base.getOne(Map, MapToDico(cadeau));
        }

        public override IEnumerable<Cadeau> GetAll()
        {
            return base.getAll(Map);
        }

        public override Cadeau GetOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdCadeau", id);
            return base.getOne(Map, Parameters);
        }

        public override Cadeau Insert(Cadeau toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdCadeau = id;
            return toInsert;
        }

        public override bool Update(Cadeau toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdCadeau", id);
            return base.Delete( Parameters);
        }


        
        private Dictionary<string, object> MapToDico(Cadeau toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["Nom"] = toInsert.Nom;
            p["Description"] = toInsert.Description;
            p["Magasin"] = toInsert.Magasin;
            p["Prix"] = toInsert.Prix;
            p["IdMembre"] = toInsert.IdMembre;
            return p;
        }

        private Cadeau Map(SqlDataReader p)
        {
            return new Cadeau()
            {
              Nom=p["Nom"].ToString(),
                Description=p["Description"].ToString(),
                Magasin=p["Magasin"].ToString(),
                Prix=(double)p["Prix"], 
                IdMembre= (int)p["IdMembre"] 

            };
        }
     
    }
}
