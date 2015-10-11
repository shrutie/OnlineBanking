using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
                 
    public static string SendEmail(string Emailid,string subject,string body)
    {
        SmtpClient client = new SmtpClient();
        client.Port = 587;
        client.Host = "Smtp.gmail.com";
        client.EnableSsl = true;
        MailMessage mail = new MailMessage(new MailAddress("noreplyob@gmail.com"), new MailAddress(Emailid));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        mail.CC.Add(Emailid);
        mail.Bcc.Add(Emailid);
        mail.Subject = subject;
        mail.Body = body;
        mail.From = new MailAddress(Emailid, "AdminOnlineBank");
        System.Net.NetworkCredential cred = new System.Net.NetworkCredential();
        cred.UserName = "noreplyob@gmail.com";
        cred.Password = "programmer";
        client.Credentials = cred;
        client.Send(mail);
        return mail.ToString();
    }

    public static string EmailAdmin(string id,string msg)
    {
       
        String sub = "Your Account has been logged in to transfer the money";
        String ss=SendEmail(id,sub,msg);
        return ss;
    }

    public static string EmailReg(string id, string msg)
    {
        
        String sub = "You are Registered SuccessFully";
        String ss = SendEmail(id,sub,msg);
        return ss;
    }

    public static string EmailCheckBook(string id, string msg)
    {

        String sub = "You have Requested for Check Book";
        String ss = SendEmail(id, sub, msg);
        return ss;
    }

    public static string Registration(string eid,string msg)
    {

        String subject = "You have Registered Successfully";
        String ss = SendEmail(eid, subject, msg);
        return ss;
    }

    public static string OneTimePassword(string accid, string otp)
    {
        String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        String eid = "";
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from registration where accountid=@1", con);
        cmd.Parameters.AddWithValue("@1", accid);
        SqlDataReader sdr = cmd.ExecuteReader();

        if (sdr.Read())
        {
            eid = sdr.GetString(2);
        }
        
        String sub = "Enter the OTP To complete the Transaction";
        string msg = "Your One Time Password (OTP) for transaction is : " + otp;
        String ss = SendEmail(eid, sub, msg);
        return ss;
    }

    public static string Withdrawal(string accid, string msg)
    {
        String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        String eid = "";
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from registration where accountid=@1", con);
        cmd.Parameters.AddWithValue("@1", accid);
        SqlDataReader sdr = cmd.ExecuteReader();

        if (sdr.Read())
        {
            eid = sdr.GetString(2);
        }
        String sub = "Money Withdrawal From Your Account";
        String ss = SendEmail(eid, sub, msg);
        return ss;
    }

    public static string Deposit(string accid, string msg)
    {
        String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        String eid = "";
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from registration where accountid=@1", con);
        cmd.Parameters.AddWithValue("@1", accid);
        SqlDataReader sdr = cmd.ExecuteReader();

        if (sdr.Read())
        {
            eid = sdr.GetString(2);
        }
        String sub = "Money Deposited in Your Account";
        String ss = SendEmail(eid, sub, msg);
        return ss;
    }

    public static string forgot_pass(string id,string msg)
    {
        String sub = "Your Password for your account to be logged in";
        String n = SendEmail(id,sub,msg);
        return n;
    }
}