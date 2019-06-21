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
            public const string getLoan_payment = @"select docno, pay_date, brh_id, path_no, pmas.path_name(brh_id, path_no) path_name, area_no, pmas.area_name(brh_id, path_no, area_no) area_name,
                                                    lnc_no, nvl(pcont.cust_no(lnc_no), 0) cust_no, firstname, lastname, nvl(pcust.ftel_sms(pcont.cust_no(lnc_no)), ' ') tel_sms, 
                                                    pcust.ftel_sms_send_status(pcust.ftel_sms(pcont.cust_no(lnc_no))) tel_sms_send_status, mpay_amt, nvl(pay_amt, 0) pay_amt, last_pay_date, late_no_day, nvl(bal, 0) bal, 
                                                    sts, mseq, dseq 
                                                    from loan_paymentv where brh_id = '02' and path_no = '28' and trunc(pay_date) = trunc(sysdate)";
        }
    }
}