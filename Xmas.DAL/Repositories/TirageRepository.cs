using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.DAL.Models;

namespace Xmas.DAL.Repositories
{
    public class TirageRepository : BaseRepository<Tirage, int>
    {
        public TirageRepository(string Cnstr) : base(Cnstr)
        { 
            SelectAllCommand = "SELECT * FROM Tirage";
            SelectOneCommand = "SELECT * FROM Tirage WHERE IdTirage=@IdTirage ";
            InsertCommand = "INSERT INTO Tirage(IdMembreOffre,IdMembreRecois,IdEvenement,DateTirage) VALUES (@IdMembreOffre,@IdMembreRecois,@IdEvenement,@DateTirage)";
            UpdateCommand = "UPDATE Tirage SET IdMembreOffre = @IdMembreOffre, IdMembreRecois = @IdMembreRecois, IdEvenement = @IdEvenement, DateTirage = @DateTirage WHERE IdTirage = @IdTirage";
            DeleteCommand = "DELETE FROM  Tirage WHERE IdTirage=@IdTirage";
        }

        public override IEnumerable<Tirage> GetAll()
        {
            return base.getAll(Map);
        }

        public override Tirage GetOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdTirage", id);
            return base.getOne(Map, Parameters);
        }

        public override Tirage Insert(Tirage toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            int id = base.Insert(Parameters);
            toInsert.IdTirage = id;
            return toInsert;
        }

        public override bool Update(Tirage toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdTirage", id);
            return base.Delete( Parameters);
        }


        #region Mappers
        private Dictionary<string, object> MapToDico(Tirage toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["IdMembreOffre"] = toInsert.IdMembreOffre;
            p["IdMembreRecois"] = toInsert.IdMembreRecois;
            p["IdEvenement"] = toInsert.IdEvenement;
            p["DateTirage"] = toInsert.DateTirage; 
            return p;
        }

        private Tirage Map(SqlDataReader p)
        {
            return new Tirage()
            {
                IdMembreOffre= (int)p["IdMembreOffre"],
                IdMembreRecois = (int)p["IdMembreRecois"] ,
                IdEvenement = (int)p["IdEvenement"] ,
                DateTirage =(DateTime) p["DateTirage"] 

            };
        }
        #endregion
    }
}
