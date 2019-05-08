using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace DataAccessLayer
{
    class DbConnect 
    {
        DbConnection con;
        DbCommand com;
        DbDataAdapter adpt;
        
        static public IConfigurationRoot Configuration { get; set; }
        static public IDbConnection DbConnection { get; set; }

        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            Console.WriteLine($"option1 = {Configuration["option1"]}");
            Console.WriteLine($"option2 = {Configuration["option2"]}");
            Console.WriteLine(
                $"option1 = {Configuration["subsection:suboption1"]}");

            return "";
        }       
        string ConStr = ""; // ConfigurationManager.["ConnectionString"].ConnectionString;

        /// <summary>
        /// Default Constructor
        /// Creates a database connection with the DB(Default connection).
        /// </summary>
        public DbConnect()
        {
            ConStr= GetConnectionString();

            //ConnectionStringSettings settings = WebConfigurationManager.ConnectionStrings[ConnectionStringName];
            DbProviderFactory factory = DbProviderFactories.GetFactory("");
            con = factory.CreateConnection();
            con.ConnectionString = "";//settings.ConnectionString;
            com = con.CreateCommand();
            adpt = factory.CreateDataAdapter();
        }

        /// <summary>
        /// Parameterized constructor
        /// Creates a database connection with the DB(Connection string of DB is passed as parameter)
        /// </summary>
        /// <param name="connectionStringName"></param>
        public DbConnect(string connectionStringName)
        {
            DbConnection settings = new DbConnection()
                                 .("")
                                 .;

            DbConnection.ConnectionString = connectionStringName;

            DbProviderFactory factory = DbProviderFactories.GetFactory(DbConnection);
            con = factory.CreateConnection();
            con.ConnectionString = "";//settings.ConnectionString;
            com = con.CreateCommand();
            adpt = factory.CreateDataAdapter();
        }

        /// <summary>
        /// Executes a query and selects data from DB and fill into DataSet
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Dataset of selected data from DB</returns>
        protected DataSet SelectDataSet(string query)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))   // USE
                        adpt.Fill(ds);
                    return ds;
                }
                //catch
                //{
                //    return ds;
                //}

                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        /// <summary>
        /// Executes a query and selects data from DB and fill into Datatable
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Datatable of selected data from DB</returns>
        protected DataTable SelectDataTable(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adpt = new SqlDataAdapter(cmd))   // USE
                        adpt.Fill(dt);
                    return dt;
                }
                //catch
                //{
                //    return dt;
                //}
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        /// <summary>
        /// Executes a query(Update/Delete/Insert) and selects the no of rows affected.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Integer value of no of rows affected.</returns>
        protected int ExecuteQuery(string query)
        {
            //Update/Delete/INSERT
            int count = 0;
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.CommandType = CommandType.Text;
                    count = (cmd.ExecuteNonQuery());
                    return count;
                }
                //catch
                //{
                //    return count;
                //}
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        protected int ExecuteTransaction(string query)
        {
            //Update/Delete/INSERT
            int count = 0;
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.CommandType = CommandType.Text;
                    SqlTransaction transaction = con.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        count = (cmd.ExecuteNonQuery());
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        count = 0;
                    }

                    return count;
                }
                //catch
                //{
                //    return count;
                //}
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }


        /// <summary>
        /// Executes a query and selects a single value as a string
        /// </summary>
        /// <param name="query"></param>
        /// <returns>A single string value</returns>
        protected string SelectScalar(string query)
        {
            string v = "";
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.CommandType = CommandType.Text;
                    v = Convert.ToString(cmd.ExecuteScalar());
                    return v;
                }
                //catch
                //{
                //    return v;
                //}
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        /// <summary>
        /// Executes a query and selects a single value as an integer
        /// </summary>
        /// <param name="query"></param>
        /// <returns>A single string value</returns>
        protected int SelectintScalar(string query)
        {
            int v;
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.CommandType = CommandType.Text;
                    v = Convert.ToInt32(cmd.ExecuteScalar());
                    return v;
                }
                //catch
                //{
                //    return v;
                //}
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        /// <summary>
        /// Executes a query and selects a desired single value(passed as parameter)
        /// </summary>
        /// <param name="query"></param>
        /// 
        /// 
        /// <returns>A single value</returns>
        protected string SelectScalarIdentity(string query)
        {
            query += " SELECT SCOPE_IDENTITY()";
            return SelectScalar(query);
        }

        /// <summary>
        /// Gets all the parameters and adds into DbParameter, executes the stored procedure and selects a value(if any).
        /// </summary>
        /// <param name="storeProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns>A single object value(if any)</returns>
        protected object ExecuteSP(string storeProcedure, SPParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(storeProcedure, con))
            {
                try
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedure;
                    cmd.Parameters.Clear();
                    if (parameters != null)
                    {
                        foreach (SPParameter param in parameters)
                        {
                            DbParameter p = cmd.CreateParameter();
                            p.DbType = param.ParamType;
                            p.Direction = param.ParamDirection;
                            p.ParameterName = param.ParamName;

                            if (p.Direction == ParameterDirection.Input)
                            {
                                p.Value = (param.ParamValue == null || param.ParamValue.ToString() == "") ? DBNull.Value : param.ParamValue;
                            }
                            if (p.DbType == DbType.String)
                            {
                                p.Size = param.ParamSize;
                            }
                            cmd.Parameters.Add(p);
                        }
                    }

                    cmd.ExecuteNonQuery();
                    object output = null;
                    foreach (DbParameter p in cmd.Parameters)
                    {
                        if (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.ReturnValue)
                        {
                            output = p.Value;
                            break;
                        }
                    }
                    con.Close();
                    return output;
                }
                catch
                {
                    return null;
                }

                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        /// <summary>
        /// Executes the stored procedure
        /// </summary>
        /// <param name="storeProcedure"></param>
        protected void ExecuteSP(string storeProcedure)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(storeProcedure, con))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedure;

                    cmd.ExecuteNonQuery();

                }

                finally
                {
                    con.Close();
                    con.Dispose();

                }
            }

        }

        /// <summary>
        /// Gets all the input and output parameters and adds into DbParameter.
        /// Executes the stored procedure, selects the data and fill into DataSet
        /// </summary>
        /// <param name="storeProcedure"></param>
        /// <param name="in_parameters"></param>
        /// 
        /// <returns>Dataset of selected data from DB</returns>
        protected DataSet SelectSPDataSet(string storeProcedure, SPParameter[] in_parameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConStr))
            using (SqlCommand cmd = new SqlCommand(storeProcedure, con))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storeProcedure;
                    cmd.Parameters.Clear();

                    if (in_parameters != null)
                    {
                        foreach (SPParameter param in in_parameters)
                        {
                            DbParameter p = cmd.CreateParameter();
                            p.DbType = param.ParamType;
                            p.Direction = param.ParamDirection;
                            p.ParameterName = param.ParamName;

                            if (p.Direction == ParameterDirection.Input)
                            {
                                p.Value = (param.ParamValue == null || param.ParamValue.ToString() == "") ? DBNull.Value : param.ParamValue;
                            }
                            if (p.DbType == DbType.String)
                            {
                                p.Size = param.ParamSize;
                            }
                            cmd.Parameters.Add(p);
                        }
                    }

                    adpt.SelectCommand = cmd;
                    adpt.Fill(ds);


                    return ds;
                }

                catch { return ds; }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }

    public class SPParameter
    {
        public string ParamName;
        public object ParamValue;
        public DbType ParamType;
        public ParameterDirection ParamDirection;
        public int ParamSize;

        /// <summary>
        /// Parameterized constructor
        /// Assigns values to the parameters
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramVal"></param>
        /// <param name="paramType"></param>
        /// <param name="paramDirection"></param>
        public SPParameter(string paramName, object paramVal, DbType paramType, ParameterDirection paramDirection)
        {
            ParamName = paramName;
            ParamValue = paramVal;
            ParamType = paramType;
            ParamDirection = paramDirection;
        }

        /// <summary>
        /// Parameterized constructor
        /// Assigns values to the parameters
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramVal"></param>
        /// <param name="paramSize"></param>
        /// <param name="paramType"></param>
        /// <param name="paramDirection"></param>
        public SPParameter(string paramName, object paramVal, int paramSize, DbType paramType, ParameterDirection paramDirection)
        {
            ParamName = paramName;
            ParamValue = paramVal;
            ParamType = paramType;
            ParamDirection = paramDirection;
            ParamSize = paramSize;
        }

        /// <summary>
        /// Default Constructor
        /// Assigns default value to the parameters
        /// </summary>
        public SPParameter()
        {
            ParamName = null;
            ParamValue = null;
            ParamType = 0;
            ParamDirection = 0;
        }
    }
}
