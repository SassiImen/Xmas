using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
using Xmas.DAL.Interface;
using Xmas.DAL.Models;

namespace Xmas.DAL.Repositories
{
    public abstract class BaseRepository<T, TKey> : IRepository<T, TKey>
        where T : IEntity<TKey>, new()
        where TKey : struct
    {

        private string _selectAllCommand;
        private string _selectOneCommand;
        private string _insertCommand;
        private string _updateCommand;
        private string _deleteCommand;
        private Connection _oconn;






        public string SelectAllCommand
        {
            get
            {
                return _selectAllCommand;
            }

            protected set
            {
                _selectAllCommand = value;
            }
        }

        public string SelectOneCommand
        {
            get
            {
                return _selectOneCommand;
            }

            protected set
            {
                _selectOneCommand = value;
            }
        }



        public string InsertCommand
        {
            get
            {
                return _insertCommand;
            }

            protected set
            {
                _insertCommand = value;
            }
        }

        public string UpdateCommand
        {
            get
            {
                return _updateCommand;
            }

            protected set
            {
                _updateCommand = value;
            }
        }

        public string DeleteCommand
        {
            get
            {
                return _deleteCommand;
            }

            protected set
            {
                _deleteCommand = value;
            }
        }

        protected T getOne(Func<SqlDataReader, T> selector, Dictionary<string, object> QueryParameters)
        {
            Command cmd = new Command(SelectOneCommand);
            foreach (KeyValuePair<string, object> item in QueryParameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }
            return _oconn.ExecuteReader<T>(cmd, selector).FirstOrDefault();
           
        }
        protected IEnumerable<T> getAll(Func<SqlDataReader, T> callBack,
            Dictionary<string, object> QueryParameters = null)
        {
            Command cmd = new Command(SelectAllCommand);
            if (QueryParameters != null)
            {
                foreach (KeyValuePair<string, object> item in QueryParameters)
                {
                    cmd.AddParameter(item.Key, item.Value);
                }
            }
            return _oconn.ExecuteReader<T>(cmd, callBack);
        }


        protected int Insert(Dictionary<string, object> parameters)
        {
            Command cmd = new Command(InsertCommand);
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }

            return (int)_oconn.ExecuteScalar(cmd);
        }

        protected bool Update(Dictionary<string, object> parameters)
        {
            Command cmd = new Command(UpdateCommand);
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }

           
            return _oconn.ExecuteNonQuery(cmd) >= 0;
        }

        protected bool Delete(Dictionary<string, object> parameters)
        {
            Command cmd = new Command(DeleteCommand);
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }
           
            return _oconn.ExecuteNonQuery(cmd) >= 0;
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T GetOne(TKey id);
        public abstract T Insert(T toInsert);
        public abstract bool Update(T toUpdate);
        public abstract bool Delete(TKey id);

        public BaseRepository(string Cnstr)
        {
            _oconn = new Connection(Cnstr);
        }
    }
}
