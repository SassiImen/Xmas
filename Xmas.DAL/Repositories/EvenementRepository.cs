using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.DAL.Models;

namespace Xmas.DAL.Repositories
{
    public class EvenementRepository : BaseRepository<Evenement, int>
    {
        public EvenementRepository(string Cnstr) : base(Cnstr)
        { 
            SelectAllCommand = "SELECT * FROM Evenement";
            SelectOneCommand = "SELECT * FROM Evenement WHERE IdEvenement=@IdEvenement ";
            InsertCommand = "INSERT INTO Evenement(Nom,Description,DateDebut,DateFin)  OUTPUT inserted.IdEvenement  VALUES (@Nom,@Description,@DateDebut,@DateFin)";
            UpdateCommand = "UPDATE Evenement SET Nom=@Nom,Description=@Description,DateDebut=@DateDebut,DateFin=@DateFin WHERE IdEvenement=@IdEvenement";
            DeleteCommand = "DELETE FROM  Evenement WHERE IdEvenement=@IdEvenement";
        }

        public override IEnumerable<Evenement> GetAll()
        {
            return base.getAll(Map);
        }

        public override Evenement GetOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdEvenement", id);
            return base.getOne(Map, Parameters); 
        }

        public override Evenement Insert(Evenement toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdEvenement = id;
            return toInsert;
        }

        public override bool Update(Evenement toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdEvenement", id);
            return base.Delete( Parameters);
        }


        #region Mappers
        private Dictionary<string, object> MapToDico(Evenement toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
           p["IdEvenement"] = toInsert.IdEvenement;
            p["Nom"] = toInsert.Nom;
            p["Description"] = toInsert.Description;
            p["DateDebut"] = toInsert.DateDebut;
            p["DateFin"] = toInsert.DateFin;
            return p;
        }

        private Evenement Map(SqlDataReader p)
        {
            return new Evenement()
            {
              IdEvenement=(int)p["IdEvenement"],
              Nom=p["Nom"].ToString(),
                Description = p["Nom"].ToString(),
                DateDebut =(DateTime) p["Nom"] ,
                DateFin = (DateTime)p["Nom"] 

            };
        }
        #endregion
    }
}
