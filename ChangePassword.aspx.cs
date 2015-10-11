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
using System.Net.Mail;
using System.Net.Security;
public partial class ChangePassword : System.Web.UI.Page
{
    String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    String ss = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user_name"] == null || Session["user_name"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            ss = (String)Session["user_name"];
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        try
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update login set password=@1 where username=@2", con);
            cmd.Parameters.AddWithValue("@1", CryptorEngine.Encrypt(TextBox1.Text,true));
            cmd.Parameters.AddWithValue("@2", ss);
            cmd.ExecuteScalar();
            con.Close();

            Response.Write("<script type='text/javascript'>alert('Password Changed Successfully');</script> ");
            Response.Redirect("Home.aspx");
        }
        catch (Exception q)
        {
            Response.Write(q.ToString());
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //String pass = CryptorEngine.Encrypt(TextBox3.Text, true);
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from login where username=@1", con);
        cmd.Parameters.AddWithValue("@1",ss);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            if (sdr.GetString(1).Equals(CryptorEngine.Encrypt(TextBox3.Text,true)) || sdr.GetString(1)==CryptorEngine.Encrypt(TextBox3.Text,true))
            {
                MultiView1.ActiveViewIndex = 0;   
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('Password Not Matched');</script> ");
            }
        }
        con.Close();
    }
}