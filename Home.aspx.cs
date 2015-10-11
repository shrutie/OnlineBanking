using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using CurrencyService;

public partial class Home : System.Web.UI.Page
{
    String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    String s = "";
    String id = "";
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader sdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null || Session["user_name"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {

            s = Session["user_name"].ToString();
            id = Session["user_id"].ToString();
            Label1.Text = s;

            if (!this.IsPostBack)
            {
                con = new SqlConnection(str);
                con.Open();
                cmd = new SqlCommand("select * from registration where username=@1", con);
                cmd.Parameters.AddWithValue("@1",s);
                sdr = cmd.ExecuteReader();
                if(sdr.Read())
                {
                    String imgname = sdr.GetString(5);
                    Image1.ImageUrl = imgname;
                }
            }
        }

        
        try
        {
            CurrencyConvertorSoapClient c = new CurrencyConvertorSoapClient();
            double rate = c.ConversionRate(Currency.USD, Currency.INR);
            Label6.Text = rate.ToString();
        }
        catch(InvalidOperationException ex)
        {
            Response.Write(ex.Message);
        }


        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        TextBox3.Enabled = false;
        TextBox4.Enabled = false;
        TextBox5.Enabled = false;


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Login.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
      
        con = new SqlConnection(str);
        con.Open();
        cmd = new SqlCommand("Select * from registration  where username=@1", con);
        cmd.Parameters.AddWithValue("@1", s);
        sdr = cmd.ExecuteReader();
        
        if (sdr.Read())
        {
           
            TextBox1.Text = sdr.GetString(0);
            TextBox2.Text = sdr.GetString(1);
            TextBox3.Text = sdr.GetString(2);
            TextBox4.Text = sdr.GetString(3);
            TextBox5.Text = sdr.GetString(4);
            TextBox6.Text = sdr.GetString(6);
        }
        con.Close();
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox2.Enabled = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox3.Enabled = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        TextBox4.Enabled = true;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        TextBox5.Enabled = true;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand("Update registration set username=@1,dateofbirth=@2,email=@3,mobile=@4,accounttype=@5,image=@6  where accountid=@7", con);
            cmd.Parameters.AddWithValue("@1", TextBox1.Text);
            cmd.Parameters.AddWithValue("@2", TextBox2.Text);
            cmd.Parameters.AddWithValue("@3", TextBox3.Text);
            cmd.Parameters.AddWithValue("@4", TextBox4.Text);
            cmd.Parameters.AddWithValue("@5", TextBox5.Text);

            if (checkextension(FileUpload1.FileName) == true)
            {
                FileUpload1.SaveAs(Server.MapPath("~/profile/") + FileUpload1.FileName);
                cmd.Parameters.AddWithValue("@6", "~/profile/" + FileUpload1.FileName);
            }
            else
            {
                Label2.Text = "Please Upload file correctly";
            }
            
            cmd.Parameters.AddWithValue("@7",TextBox6.Text);
            cmd.ExecuteScalar();
            con.Close();

            Response.Write("<script type='text/javascript'>alert('Record Updated Successfully');</script> ");
        }
        catch (Exception q)
        {
            Response.Write(q.Message);
        }
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }

    public void delete_registration()
    {
        try
        {
            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand("Delete from registration where username=@1", con);
            cmd.Parameters.AddWithValue("@1", s);
            cmd.ExecuteScalar();
            con.Close();
            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    public void delete_balance()
    {
        try
        {
            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand("Delete from balance where accountid=@1", con);
            cmd.Parameters.AddWithValue("@1", id);
            cmd.ExecuteScalar();
            con.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Write("<script type='text/javascript'>alert('Record Deleted Succefully');</script>");
        
        try
        {
            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand("Delete from login where username=@1", con);
            cmd.Parameters.AddWithValue("@1", s);
            cmd.ExecuteScalar();
            con.Close();
            delete_registration();
            delete_balance();
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }

        Response.Write("<script type='text/javascript'>alert('Record Deleted Succefully');</script>");
        Session.Abandon();
        Session.Clear();
        Response.Redirect("Login.aspx");

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        TextBox1.Enabled = true;
    }

    public void value_label()
    {

        con = new SqlConnection(str);
        con.Open();
        cmd = new SqlCommand("Select * from balance where accountid=@1", con);
        cmd.Parameters.AddWithValue("@1", id);
        sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {

          Label5.Text = Label4.Text = Label3.Text = sdr.GetString(1);

        }
        else
        {
            Response.Write("Invalid Format");
        }
        con.Close();
    }


    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        value_label();
        MultiView1.ActiveViewIndex = 1;
        try
        {
            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand("Select * from registration  where username=@1", con);
            cmd.Parameters.AddWithValue("@1", s);
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                String emailid = sdr.GetString(2);
                String ss = "<b><i>Your Account is been logged in to transfer the money from your account to another account.<br><br><br>Please ignore this message if the account is used by you.</i></b>";
                Email.EmailAdmin(emailid,ss);
                con.Close();
            }

        }
        catch(Exception ee)
        {
            Response.Write(ee.Message);
        }
    }

    static String RandomNumber(int min, int max)
    {

        Random random = new Random();
        return random.Next(1000, 9999).ToString();
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
       
        int pbal = Convert.ToInt32(Label3.Text);
        int transferbal = Convert.ToInt32(TextBox8.Text);
        
    
        if (transferbal > pbal)
        {
            Response.Write("<script type='text/javascript'>alert('You don't have Sufficient Funds to transfer');</script>");
        }
        else
        {
            
            Session["otp"] = RandomNumber(1000, 9999);
           // MobileSms.send(id,Session["otp"].ToString());                           //sending otp code  by sms 
           Email.OneTimePassword(id,Session["otp"].ToString());                    //sending otp code by email
           Transaction.Trans(TextBox7.Text,id,TextBox8.Text);
        
           Response.Redirect("OTP.aspx");
          
            TextBox7.Text = "";
            TextBox8.Text = "";
        }
    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        value_label();
        MultiView1.ActiveViewIndex = 2;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        int amt = Convert.ToInt32(TextBox9.Text);
        int pbal = Convert.ToInt32(Label4.Text);
        int bal = pbal + amt;

        Transaction.balance_update(bal.ToString(), id);
        Transaction.own(id,amt.ToString());
        String msg = "Your account has been deposited with Rs:" + amt;
        Email.Deposit(id,msg);
        //MobileSms.Deposit(id, msg);
        Response.Write("<script type='text/javascript'>alert('Amount Deposited Successfully');</script>");
        value_label();
        TextBox9.Text = "";
    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        value_label();
        MultiView1.ActiveViewIndex = 3;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        int amt = Convert.ToInt32(TextBox10.Text);
        int pbal = Convert.ToInt32(Label5.Text);
        int bal = pbal - amt;
        if (bal > 0)
        {
            Transaction.balance_update(bal.ToString(), id);
            Transaction.own(id, amt.ToString());
            String msg = "Your account has been withdrwal with Rs:"+amt;
            Email.Withdrawal(id,msg);
            //MobileSms.Deposit(id, msg);
            Response.Write("<script type='text/javascript'>alert('Amount Withdrwal Successfully');</script>");
            value_label();
            TextBox9.Text = "";
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('Available Amount is less then the entered withdrawal amount');</script>");
        }
    }

    public void checkbook_money(int ck_amt)
    {
        value_label();
        int amount = Convert.ToInt32(Label3.Text);
        amount = amount - ck_amt;
        Transaction.balance_update(amount.ToString(), id);
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        String acctype = null;
        String page_no = null;
        int ck_amt = 0;

        if (RadioButton3.Checked)
        {
            acctype = RadioButton3.Text;
        }
        else
        {
            acctype = RadioButton4.Text;
        }

        if(RadioButton5.Checked)
        {
            page_no = RadioButton5.Text;
            ck_amt = 50;
        }
        else if(RadioButton6.Checked)
        {
            page_no = RadioButton6.Text;
            ck_amt = 100;
        }
        else
        {
            page_no = RadioButton7.Text;
            ck_amt = 150;
        }
        try
        {
            
            checkbook_money(ck_amt);

            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand("Insert into checkbook values(@1,@2,@3,@4,@5,@6,@7,@8)", con);
            cmd.Parameters.AddWithValue("@1", TextBox11.Text);
            cmd.Parameters.AddWithValue("@2", TextBox12.Text);
            cmd.Parameters.AddWithValue("@3", TextBox13.Text);
            cmd.Parameters.AddWithValue("@4", TextBox14.Text);
            cmd.Parameters.AddWithValue("@5", TextBox15.Text);
            cmd.Parameters.AddWithValue("@6", TextBox16.Text);
            cmd.Parameters.AddWithValue("@7", TextBox17.Text);
            cmd.Parameters.AddWithValue("@8", page_no);
            cmd.ExecuteNonQuery();
            con.Close();
            String msg = "CheckBook will reach in 48 Hours at your Address";
            Email.EmailCheckBook(TextBox15.Text,msg);                                               //Sending email
           // MobileSms.SendRegSMS(TextBox14.Text,msg);                                               //Sending Mobile Sms
            Response.Write("<script type='text/javascript'>alert('Check book will reach in 48 Hours at your Address.');</script>");
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        TextBox11.Text = id;
        con = new SqlConnection(str);
        con.Open();
        cmd = new SqlCommand("select * from registration where accountid=@1", con);
        cmd.Parameters.AddWithValue("@1", id);
        sdr = cmd.ExecuteReader();
        if(sdr.Read())
        {
            TextBox14.Text = sdr.GetString(3).ToString();
            TextBox15.Text = sdr.GetString(2).ToString();
        }
        con.Close();
        MultiView1.ActiveViewIndex = 4;
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserStatement.aspx");
    }
}