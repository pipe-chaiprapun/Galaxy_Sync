using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using GalaxySync.Concrete;
using GalaxySync.Services;
using Microsoft.AspNetCore.Http;
using GalaxySync.Models.Api;

namespace GalaxySync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private string connString = "User Id=DE;Password=DE;Data Source=192.168.1.10:1521/HPDB;";
        GalaxyService gts = new GalaxyService();

        [HttpGet("getloan")]
        public IActionResult GetLoan(int brh_id, int path_no)
        {
            var data = gts.GetLoan_paymentvs(brh_id, path_no);
            return Ok(data);
        }
        
        [HttpPost("sendPayment")]
        public IActionResult PostPayment([FromForm]m_LoanPayment value)
        {
            return Ok(value);
        }
    }
}