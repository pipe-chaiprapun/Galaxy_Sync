using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace GalaxySync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private string connString = "User Id=DE;Password=DE;Data Source=192.168.1.10:1521/HPDB;";
        public IActionResult Get()
        {
            using (OracleConnection conn = new OracleConnection(connString))
            {
                try
                {
                    conn.Open();
                    using(var cmd = new OracleCommand("select * from loan_paymentv where trunc(pay_date) = trunc(sysdate)", conn){CommandType = CommandType.Text}){
                      var reader = cmd.ExecuteReader();
                      List<string> data = new List<string>();
                      while(reader.Read()){
                        if(reader.IsDBNull(6)){
                          data.Add("-");
                        }
                        else
                        {
                          data.Add(reader.GetString(6));
                        }
                      }
                      cmd.Dispose();
                      reader.Dispose();
                      return Ok(data);
                    }
                }
                catch(Exception e){
                  return Ok(e.Message);
                }
                finally{
                  conn.Close();
                  conn.Dispose();
                }
            }
        }

    }
}