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
    public class CadeauEvenementRepository : BaseRepository<CadeauEvenement, CompositeKey<int, int>>
    {
        public CadeauEvenementRepository(string Cnstr) : base(Cnstr)
        { 
            SelectAllCommand = "SELECT * FROM CadeauEvenement";
            SelectOneCommand = "SELECT * FROM CadeauEvenement WHERE IdEvenement=@IdEvenement AND IdCadeau=@IdCadeau ";
            InsertCommand = "INSERT INTO CadeauEvenement(IdEvenement,IdCadeau,Preference) VALUES (@IdEvenement,@IdCadeau,@Preference)";
            UpdateCommand = "UPDATE CadeauEvenement SET IdEvenement=@IdEvenement, IdCadeau=@IdCadeau,Preference=@Preference WHERE IdEvenement=@IdEvenement AND IdCadeau=@IdCadeau";
            DeleteCommand = "DELETE FROM  CadeauEvenement WHERE IdEvenement=@IdEvenement AND IdCadeau=@IdCadeau";
        }

        public override IEnumerable<CadeauEvenement> GetAll()
        {
            return base.getAll(Map);
        }

        public override CadeauEvenement GetOne(CompositeKey<int, int> id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdEvenement", id.PK1);
            Parameters.Add("IdCadeau", id.PK2);
            return base.getOne(Map, Parameters);
        }

        public override CadeauEvenement Insert(CadeauEvenement toInsert)
        {
            Dictionary<string, object> Parameters = MapToDico(toInsert);
            base.Insert(Parameters);       
            return toInsert;
        }

        public override bool Update(CadeauEvenement toUpdate)
        {
            Dictionary<string, object> Parameters = MapToDico(toUpdate);
            return base.Update(Parameters);

        }

        public override bool Delete(CompositeKey<int, int> id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("IdEvenement", id.PK1);
            Parameters.Add("IdCadeau", id.PK2);
            return base.Delete(Parameters);
        }


        #region Mappers
        private Dictionary<string, object> MapToDico(CadeauEvenement toInsert)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p["_idEvenement"] = toInsert.IdCadeau;
            p["IdEvenement"]= toInsert.IdEvenement;
                 p["Preference"] = toInsert.Preference;
            return p;
        }

        private CadeauEvenement Map(SqlDataReader p)
        {
            return new CadeauEvenement()
            {

                IdCadeau = (int)p["IdCadeau"] ,
                IdEvenement =(int) p["IdEvenement"],
                Preference = (bool)p["Preference"]

            };
        }
        #endregion
    }
}
