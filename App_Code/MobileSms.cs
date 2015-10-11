using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class MobileSms
{
	 
        static string sUserID = "ggauravag";
        static string sPwd = "smscode";
        static string sSID = "WebSMS";

        public static string sendSMS(string sNumber, string sMessage)
        {

            string sURL = "http://smslane.com/vendorsms/pushsms.aspx?user=" + sUserID + "&password=" + sPwd + "&msisdn=" + sNumber + "&sid=" + sSID + "&msg=" + sMessage + "&mt=0&fl=0";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            string sResponse = null;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();

                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sResponse;
        }

        public static string send(string accid,string otp)
        {
            String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            String n = "";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from registration where accountid=@1", con);
            cmd.Parameters.AddWithValue("@1",accid);
            SqlDataReader sdr = cmd.ExecuteReader();

            if(sdr.Read())
            {
                n = sdr.GetString(3);
            }
            string num = "91"+n;
            string msg = "Your One Time Password (OTP) for transaction is : "+otp;

            string res = sendSMS(num, msg);
      
            return res;
        }

     public static string SendRegSMS(string mob,string msg)
        {
            string num = "91" + mob;
            string message = msg;
            string result = sendSMS(num, message);
            return result;
        }

    public static string Deposit(string accid,string msg)
     {
         String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
         String n = "";
         SqlConnection con = new SqlConnection(str);
         con.Open();
         SqlCommand cmd = new SqlCommand("select * from registration where accountid=@1", con);
         cmd.Parameters.AddWithValue("@1", accid);
         SqlDataReader sdr = cmd.ExecuteReader();

         if (sdr.Read())
         {
             n = sdr.GetString(3);
         }
         string num = "91" + n;
         string result = sendSMS(num, msg);
         return result;
     }
    }
