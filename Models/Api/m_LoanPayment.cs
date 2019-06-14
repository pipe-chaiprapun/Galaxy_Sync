using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxySync.Models.Api
{
    public class m_LoanPayment
    {
        public List<int> amount { get; set; }
        public List<IFormFile> images { get; set; }
    }
}
