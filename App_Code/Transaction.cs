using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
public class Transaction
{

    public static String RandomNumber(int min, int max)
    {

        Random random = new Random(); 
        return random.Next(10000, 99999).ToString();
    }

    public static String Available_Balance(string id)
    {
        string bal="";
        string str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from balance where accountid=@1", con);
        cmd.Parameters.AddWithValue("@1", id);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            bal = sdr.GetString(1);
            return bal;
        }
        else
        {
            return null;
        }
    }
    public static string Trans(string idto,string idfrom,string amt)
   {

      string str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
      string tid=RandomNumber(10000, 99999);
      string date=DateTime.Now.ToShortDateString();
      string avalaiblebal = Available_Balance(idfrom);
      
      string ss = "";
      try
      {

          SqlConnection con = new SqlConnection(str);
          con.Open();
          SqlCommand cmd = new SqlCommand("insert into transactions values(@1,@2,@3,@4,@5,@6,@7)", con);
          cmd.Parameters.AddWithValue("@1", tid);
          cmd.Parameters.AddWithValue("@2", idto);
          cmd.Parameters.AddWithValue("@3", idfrom);
          cmd.Parameters.AddWithValue("@4", amt);
          cmd.Parameters.AddWithValue("@5", date);
          cmd.Parameters.AddWithValue("@6", avalaiblebal);
          cmd.Parameters.AddWithValue("@7", "N");
          cmd.ExecuteNonQuery();
          con.Close();
         
      }
        catch(Exception ex)
      {
          ss = ex.Message;
      }
      return ss;
   }

    public static string own(string ownerid,string amt)
    {
        string str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        string transid = RandomNumber(10000, 99999);
        string date = DateTime.Now.ToShortDateString();
        string avalaiblebal = Available_Balance(ownerid);
        try
        {

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into transactions values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", transid);
            cmd.Parameters.AddWithValue("@2", "self");
            cmd.Parameters.AddWithValue("@3", ownerid);
            cmd.Parameters.AddWithValue("@4", amt);
            cmd.Parameters.AddWithValue("@5", date);
            cmd.Parameters.AddWithValue("@6", avalaiblebal);
            cmd.Parameters.AddWithValue("@7","Y");
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    public static string balance_update(string bal,string accid)
    {
        string str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        
        try
        {

            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update balance set balance=@1 where accountid=@2", con);
            cmd.Parameters.AddWithValue("@1",bal);
            cmd.Parameters.AddWithValue("@2",accid);
            cmd.ExecuteScalar();
            con.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

}