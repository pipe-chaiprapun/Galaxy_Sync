using System;

namespace GalaxySync.Models
{
    public class Loan_paymentv
    {
        public string DOC_NO { get; set; }
        public DateTime PAY_DATE { get; set; }
        public string BRH_ID { get; set; }
        public string PATH_NO { get; set; }
        public string AREA_NO { get; set; }
        public string LNC_NO { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public int MPAY_AMT { get; set; }
        public int PAY_AMT { get; set; }
        public DateTime LAST_PAY_DAY { get; set; }
        public int LATE_NO_DAY { get; set; }
        public double BAL { get; set; }
        public string STS { get; set; }
        public long MSEQ { get; set; }
        public long DSEQ { get; set; }
    }
}