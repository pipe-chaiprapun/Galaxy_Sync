using GalaxySync.Concrete;
using GalaxySync.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxySync.Services
{
    public class GalaxyService
    {
        private const string _user = Constants.OracleDb.User;
        private const string _password = Constants.OracleDb.Password;
        private const string _host = Constants.OracleDb.Host;
        private const string _port = Constants.OracleDb.Port;
        private const string _source = Constants.OracleDb.Source;
        private readonly string _connStr = $"User Id={_user};Password={_password};Connection Timeout=600;Data Source={_host}:{_port}/{_source}";

        public List<Loan_paymentv> GetLoan_paymentvs(int brh, int path)
        {
            using (OracleConnection conn = new OracleConnection(_connStr))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(Constants.SqlCommand.getLoan_paymentv, conn) { CommandType = CommandType.Text })
                    {
                        cmd.Parameters.Add("brh_id", brh);
                        cmd.Parameters.Add("path_no", path);
                        var reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<Loan_paymentv> data = new List<Loan_paymentv>();
                            while (reader.Read())
                            {
                                data.Add(new Loan_paymentv
                                {
                                    DOC_NO = reader["DOCNO"].ToString(),
                                    PAY_DATE = (DateTime)reader["PAY_DATE"],
                                    BRH_ID = reader["BRH_ID"].ToString(),
                                    PATH_NO = reader["PATH_NO"].ToString(),
                                    AREA_NO = reader["AREA_NO"].ToString(),
                                    LNC_NO = reader["LNC_NO"].ToString(),
                                    FIRSTNAME = reader["FIRSTNAME"].ToString(),
                                    LASTNAME = reader["LASTNAME"] == DBNull.Value ? string.Empty : reader["LASTNAME"].ToString(),
                                    MPAY_AMT = Int32.Parse(reader["MPAY_AMT"].ToString()),
                                    PAY_AMT = Int32.Parse(reader["PAY_AMT"].ToString()),
                                    LAST_PAY_DAY = (DateTime)reader["LAST_PAY_DATE"],
                                    //LATE_NO_DAY = Int32.Parse(reader["LAST_NO_DAY"].ToString()),
                                    //BAL = Int32.Parse(reader["BAL"].ToString()),
                                    STS = reader["STS"] == DBNull.Value ? string.Empty : reader["STS"].ToString(),
                                   // MSEQ = Int64.Parse(reader["MSEQ"].ToString()),
                                    //DSEQ = Int64.Parse(reader["DSEQ"].ToString())
                                });
                            }
                            cmd.Dispose();
                            reader.Dispose();
                            return data;
                        }
                        else
                        {
                            cmd.Dispose();
                            reader.Dispose();
                            return null;
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Error => {e.Message}");
                    return null;
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
