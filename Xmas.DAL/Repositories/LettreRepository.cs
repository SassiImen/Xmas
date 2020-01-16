using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.DAL.Infra;
using Xmas.DAL.Models;

namespace Xmas.DAL.Repositories
{
    public class LettreRepository : BaseRepository<Lettre, CompositeKey<int,int>>
    {
        public LettreRepository(string Cnstr) : base(Cnstr)
        { 
            SelectAllCommand = "SELECT * FROM Lettre";
            SelectOneCommand = "SELECT * FROM Lettre WHERE IdMembre=@IdMembre AND  IdEvenement= @IdEvenement ";
            InsertCommand = "INSERT INTO Lettre(IdMembre,IdEvenement,Contenu) VALUES (@IdMembre,@IdEvenement,@Contenu)";
            UpdateCommand = "UPDATE Lettre SET IdMembre=@IdMembre,IdEvenement=@IdEvenement,Contenu=@Contenu WHERE IdMembre=@IdMembre AND  IdEvenement= @IdEvenement";
            DeleteCommand = "DELETE FROM  Lettre WHERE IdMembre=@IdMembre AND  IdEvenement= @IdEvenement";
        }

        public override IEnumerable<Lettre> GetAll()
        {
            return base.getAll(Map);
        }

        public override Lettre GetOne(CompositeKey<int,int> id)
        {
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            QueryParameters.Add("IdMembre", id.PK1);
            QueryParameters.Add("IdEvenement", id.PK2);
            return base.getOne(Map, QueryParameters);
        }

        public override Lettre Insert(Lettre toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            base.Insert(Parameters); 
            return toInsert;
        }

        public override bool Update(Lettre toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(CompositeKey<int, int> id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdMembre", id.PK1);
            Parameters.Add("IdEvenement", id.PK2);
            return base.Delete( Parameters);
        }


        #region Mappers
        private Dictionary<string, object> MapToDico(Lettre toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
           p["IdMembre"]= toInsert.IdMembre;
              p["IdEvenement"] =  toInsert.IdEvenement;
             p["Contenu"] =  toInsert.Contenu;
            return p;
        }
      
        private Lettre Map(SqlDataReader p)
        {
            return new Lettre()
            {
                IdMembre = (int)p["IdMembre"],
                IdEvenement = (int)p["IdEvenement"],
                Contenu =  p["Contenu"].ToString() 

            };
        }
        #endregion
    }
}
