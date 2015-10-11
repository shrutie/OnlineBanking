using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EnCryptDecrypt;
public partial class Forget_Password : System.Web.UI.Page
{
    String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    String aid = "";
    String mob = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public string account_id()
    {
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from registration where email=@1", con);
        cmd.Parameters.AddWithValue("@1", TextBox1.Text);
        SqlDataReader sdr = cmd.ExecuteReader();

        if(sdr.Read())
        {
            aid = sdr.GetString(6);
            mob = sdr.GetString(3);
        }
        return aid;
    }

    static String RandomNumber(int min, int max)
    {

        Random random = new Random();
        return random.Next(1000, 9999).ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String accid = account_id();
        String gpass = RandomNumber(1000, 9999);
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("update login set password=@1,firsttimelog=@2 where accountid=@3",con);
        cmd.Parameters.AddWithValue("@1" ,CryptorEngine.Encrypt(gpass,true));
        cmd.Parameters.AddWithValue("@2", "Y");
        cmd.Parameters.AddWithValue("@3", accid);
        int n = cmd.ExecuteNonQuery();

        if(n==1)
        {
            String message = "Your password is:"+gpass;
            Email.forgot_pass(TextBox1.Text,message);
           // MobileSms.SendRegSMS(mob,message);

            Response.Write("<script language='javascript'>alert('check your email or mobile for new password');</script>");
        }
    }
}