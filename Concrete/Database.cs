using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
namespace GalaxySync.Concrete
{
    public class Database
    {
        private const string _user = Constants.OracleDb.User;
        private const string _password = Constants.OracleDb.Password;
        private const string _host = Constants.OracleDb.Host;
        private const string _port = Constants.OracleDb.Port;
        private const string _source = Constants.OracleDb.Source;
        private readonly string _connStr = $"User Id={_user};Password={_password};Connection Timeout=600;Data Source={_host}:{_port}/{_source}";

        public OracleDataReader SqlQuery(string sql, List<OracleParameter> parameters)
        {
            using (OracleConnection conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(sql, conn) { CommandType = CommandType.Text })
                    {
                        if (parameters != null)
                            parameters.ForEach(param => cmd.Parameters.Add(param));

                        var reader = cmd.ExecuteReader();
                        cmd.Dispose();
                        return reader;
                    }
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        public int SqlNonQuery(string sql, List<OracleParameter> parameters)
        {
            using (OracleConnection conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(sql, conn) { CommandType = CommandType.Text })
                    {
                        parameters.ForEach(param => cmd.Parameters.Add(param));
                        var result = cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        return result;
                    }
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}