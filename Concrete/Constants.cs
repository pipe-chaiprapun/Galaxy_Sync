namespace GalaxySync.Concrete
{
    public static class Constants
    {
        public static class OracleDb
        {
            public const string User = "DE";
            public const string Password = "DE";
            public const string Host = "192.168.1.10";
            public const string Port = "1521";
            public const string Source = "HPDB";
        }
        public static class SqlCommand
        {
            public const string getLoan_paymentv = @"select docno, pay_date, brh_id, path_no, area_no, lnc_no, nvl(firstname, ' ') firstname, nvl(lastname, ' ') lastname, mpay_amt, nvl(pay_amt, 0) pay_amt, last_pay_date, late_no_day, bal, sts, mseq, dseq
                                                   from loan_paymentv where trunc(pay_date) = trunc(sysdate) and brh_id = :brh_id and path_no = :path_no";
        }
    }
}