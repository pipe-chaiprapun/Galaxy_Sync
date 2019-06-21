using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxySync.Models
{
    public class m_payment
    {
        public string doc_no { get; set; }
        public DateTime pay_date { get; set; }
        public string brh_id { get; set; }
        public string path_no { get; set; }
        public string path_name { get; set; }
        public string area_no { get; set; }
        public string area_name { get; set; }
        public string lnc_no { get; set; }
        public long cust_no { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string tel_sms { get; set; }
        public int mpay_amt { get; set; }
        public int pay_amt { get; set; }
        public DateTime last_pay_date { get; set; }
        public int late_no_day { get; set; }
        public int bal { get; set; }
        //public string STS { get; set; }
        //public long MSEQ { get; set; }
        //public long DSEQ { get; set; }
    }
}
