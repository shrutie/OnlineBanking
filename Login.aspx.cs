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


public partial class Login : System.Web.UI.Page
{
    String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    public void update_login()
    {
        //Response.Write("Update called");
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("Update login set firsttimelog=@1 where username=@2", con);
        cmd.Parameters.AddWithValue("@1", "N");
        cmd.Parameters.AddWithValue("@2", TextBox1.Text);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            if(CheckBox1.Checked)
            {
                HttpCookie cookie = new HttpCookie("users");
                cookie.Value = "Ritesh Agarwal";

                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
            }
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from login where username=@1 and password=@2", con);
            cmd.Parameters.AddWithValue("@1", TextBox1.Text);
            cmd.Parameters.AddWithValue("@2", CryptorEngine.Encrypt(TextBox2.Text,true));
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())                           
            {
                
                Session["user_id"] = sdr.GetString(4);
                Response.Write(Session["user_id"].ToString());
                     
                if (sdr.GetString(2) == "Y" && sdr.GetString(3) == "user")                   //checking that login is first time or not
                {
                        //Console.WriteLine("Logged in is first time user");
                       
                        update_login();
                        Session["user_name"] = TextBox1.Text;
                        Response.Redirect("ChangePassword.aspx");
                    
                }

                if (sdr.GetString(2) == "N")
                {
                   
                    if (sdr.GetString(3) == "user")
                    {
                        Session["user_name"] = TextBox1.Text;
                        Response.Redirect("Home.aspx");
                    }

                    if (sdr.GetString(3) == "admin")
                    {
                        Session["user_name"] = TextBox1.Text;
                        Response.Redirect("AdminHome.aspx");
                    }

                }
                
                else
                {
                    Response.Write("<script type='javascript'>alert('Not a recognised format');</script>");
                }
            }
            else
            {
                Response.Write("<script type='javascript'>alert('Record does not exists');</script>");
            }

            con.Close();
        }
        catch(Exception exp)
        {
            Response.Write(exp.Message);
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Forget_Password.aspx");
    }
}