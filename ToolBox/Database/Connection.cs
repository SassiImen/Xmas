using System;
using System.Collections.Generic;
using System.Data.SqlClient;
/// <summary>
/// The Toolbox namespace to use with using on the others project
/// </summary>
namespace ToolBox.Database
{
    /// <summary>
    /// Class to encapsulate the Connection logic like execute a query on the database to 
    /// insert data or update or ...
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Field to store the connection string.
        /// Because of the readonly keyword, you can't set the value outside the constructor
        /// </summary>
        /// <example>
        /// <c>Data Source=MyServer;Initial Catalog=MyDb;Integrated Security=True;</c>
        /// </example>
        private readonly string _ConnectionString;

        /// <summary>
        /// Connection constructor which initialize the _ConnectionString field from our parameter 
        /// </summary>
        /// <param name="connectionString">
        /// A connection string for Data base connection
        /// </param>
        /// <example>
        /// <c>Connection c = new Connection ("Data Source=MyServer;Initial Catalog=MyDb;Integrated Security=True;");</c>
        /// </example>
        public Connection(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        /// <summary>
        /// Function allowing to recover the data returned by the Database follows the execution of a request. 
        /// The executed query is located in the Query property of the Command object.
        /// This function also receives the address of the function to execute in order to map the
        /// column data to the properties of a C# object.
        /// </summary>
        /// <typeparam name="TResult">Is the type of the C# Object to map</typeparam>
        /// <param name="command">A <seealso cref="Command"/> object which contains Query and parameters</param>
        /// <param name="selector">A <seealso cref="Func{T, TResult}"/> which represent the mapping function</param>
        /// <returns>An <seealso cref="IEnumerable{T}"/> with all the T objects whose properties have obtained the data from the database </returns>
        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<SqlDataReader, TResult> selector)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    connection.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        List<TResult> items = new List<TResult>();
                        while (dataReader.Read()) 
                        {
                            //Before add to the item list, the system call the function behind the selector delegate 
                            items.Add(selector(dataReader));
                        }

                        return items;
                    }
                }
            }
        }

        /// <summary>
        /// Function to execute a query like Insert, Update, delete
        /// </summary>
        /// <param name="command">A <seealso cref="Command"/> object which contains Query and parameters</param>
        /// <returns>An int which represent the total affected rows by the query execution</returns>
        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            { 
                using (SqlCommand cmd = CreateCommand(command, connection))
                {   
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Function that returns the result of aggregate queries (SUM, Count, AVG,...)
        /// or of a query containing an output (Insert into table(...) output Inserted.id Values(...))
        /// </summary>
        /// <param name="command">A <seealso cref="Command"/> object which contains Query and parameters</param>
        /// <returns>An object that represents the result of the aggregative function contained in the query or the result of the keyword Output present in the query</returns>
        
        public object ExecuteScalar(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                { 
                    connection.Open();
                    object o = cmd.ExecuteScalar();
                    return (o is DBNull) ? null : o; //If the Query return is null(DBNull) , we return the Null (Csharp)
                }
            }
        }

        /// <summary>
        /// Private function to create the SqlConnection Object with connectionstring
        /// </summary>
        /// <returns>A <seealso cref="SqlConnection"/></returns>
        /// <remarks>Tee connection is not open after this function</remarks>
        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _ConnectionString;
            return connection;
        }

        /// <summary>
        /// Private function to create the SqlCommand object from our Command and Connection
        /// </summary>
        /// <param name="command">our <seealso cref="Command"/></param>
        /// <param name="connection">A <seealso cref="SqlConnection"/></param>
        /// <returns>A <seealso cref="SqlCommand"/> with query and parameters from our command and associated with a sql connection </returns>
        private SqlCommand CreateCommand(Command command, SqlConnection connection)
        {
            SqlCommand cmd = connection.CreateCommand();
        
            cmd.CommandText = command.Query;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }

            return cmd;
        }
    }
}
