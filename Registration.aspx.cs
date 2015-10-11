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
using System.IO;
using System.Text;
public partial class Registration : System.Web.UI.Page
{
    String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    SqlConnection con;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
    }

    public void login_user(String gpass,String id)
    {
        
        con = new SqlConnection(str);
        con.Open();
        cmd = new SqlCommand("insert into login values(@1,@2,@3,@4,@5)", con);
        cmd.Parameters.AddWithValue("@1", TextBox1.Text);
        cmd.Parameters.AddWithValue("@2", CryptorEngine.Encrypt(gpass, true));
        cmd.Parameters.AddWithValue("@3","Y");
        cmd.Parameters.AddWithValue("@4", "user");
        cmd.Parameters.AddWithValue("@5", id);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    
    static String RandomNumber(int min, int max)
    {

        Random random = new Random(); 
        return random.Next(1000, 9999).ToString();
    }

    static String RandomNumber1(int min, int max)
    {

        Random random = new Random();
        return random.Next(10000, 999999999).ToString();
    }

    public bool checkextension(string str)
    {
        bool res = false;
        int idx = str.IndexOf('.');
        string substr = str.Substring(idx + 1);
        if (substr == "jpg" || substr == "JPG" || substr == "jpeg" || substr == "JPEG")
        {
            res = true;
        }
        return res;
    }

    public void balance(String acctype, String id)
    {
        con = new SqlConnection(str);
        con.Open();
        cmd = new SqlCommand("insert into balance values(@1,@2,@3)", con);
        cmd.Parameters.AddWithValue("@1", id);
        cmd.Parameters.AddWithValue("@2", "10000");
        cmd.Parameters.AddWithValue("@3", acctype);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       

            String eml = TextBox3.Text;

            String acctype = null;
            if (RadioButton1.Checked)
            {
                acctype = RadioButton1.Text;
            }
            else
            {
                acctype = RadioButton2.Text;
            }
            //creating random password for user
            String gpass = RandomNumber(1000, 9999);
            String id = RandomNumber1(10000, 999999999);
            // Inserting into registration table
            try
            {
                con = new SqlConnection(str);
                con.Open();
                cmd = new SqlCommand("insert into registration values(@1,@2,@3,@4,@5,@6,@7)", con);
                cmd.Parameters.AddWithValue("@1", TextBox1.Text);
                cmd.Parameters.AddWithValue("@2", TextBox2.Text);
                cmd.Parameters.AddWithValue("@3", TextBox3.Text);
                cmd.Parameters.AddWithValue("@4", TextBox4.Text);
                cmd.Parameters.AddWithValue("@5", acctype);
                if (checkextension(FileUpload1.FileName) == true)
                {
                    FileUpload1.SaveAs(Server.MapPath("~/profile/") + FileUpload1.FileName);                       
                    cmd.Parameters.AddWithValue("@6", "~/profile/" + FileUpload1.FileName);
                     //  FileUpload1.PostedFile.ContentLength "kb"                                             // To know the size of the file.
                }
                else
                {
                    Label1.Text = "Please Upload file correctly";
                }
                cmd.Parameters.AddWithValue("@7", id);
                cmd.ExecuteNonQuery();
                con.Close();

                // Inserting values in login table
                login_user(gpass, id);
                balance(acctype,id);

                //Email Sending code

                String ss = "<b><i>Welcome to our Website</i></b><br>Your Email id: " + eml + "<br>Password:" + gpass + "<br>Account ID:" + id + "<br><br>Please Login Once to Change your Password as it is Generated Password";
                Email.Registration(TextBox3.Text,ss);
                 // mail.Attachments.Add(new Attachment(Server.MapPath("~/images/pic.jpg")));

                //Mobile Sending code
                String message="You have Registered Succesfully.Your Password is:"+gpass +"Email id:"+eml +"Account Id:"+id;
               // MobileSms.SendRegSMS(TextBox4.Text,message);
               
                Response.Write("<script type='text/javascript'>alert('Congratulations You Have Registered Successfully Please Check Your Inbox');</script>");

                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";

                
            }
            catch (Exception ex)
            {
                Response.Write("Could not send the e-mail - error:" + ex.Message);
            }

        
    }

    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }
}