using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class OTP : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection con;
    String otp = "";
    String accid = "";
    String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    static int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null || Session["user_name"] == "")
        {
            Response.Redirect("Home.aspx");
        }
        else
        {

            otp = Session["otp"].ToString();
            accid = Session["user_id"].ToString();
        }
    }

    public void disable(int a)
    {
        if(a==4)
        {
            i = 0;
            Response.Write("<script type='text/javascript'>alert('You have already attemted 3 times.');</script>");
            Session["otp"] = "";
            Response.Redirect("Home.aspx");
        }
        else
        {
            Response.Write("<script type='text/javascript'>alert('Please try again');</script>");
        }
    }

    public void balance(string tamt,string tto,string tid)
    {
        String pbal = Transaction.Available_Balance(accid);
        String tpbal = Transaction.Available_Balance(tto);
        int previous_balance = Convert.ToInt32(pbal);
        int entered_amount = Convert.ToInt32(tamt);
        double balance_left = Convert.ToInt64(tpbal);
        double final_amount = previous_balance - entered_amount;
        double total_amount = balance_left + entered_amount;
        Transaction.balance_update(final_amount.ToString(),accid);
        Transaction.balance_update(total_amount.ToString(),tto);

        String available_bal = Transaction.Available_Balance(accid);
        con = new SqlConnection(str);
        con.Open();
        cmd = new SqlCommand("Update transactions set Available_Balance=@1,Status=@2 where Transaction_ID=@3", con);
        cmd.Parameters.AddWithValue("@1",available_bal);
        cmd.Parameters.AddWithValue("@2","Y");
        cmd.Parameters.AddWithValue("@3",tid);
        cmd.ExecuteNonQuery();
        con.Close();

        string msg="Amount deposited in your Account Rs:"+tamt;
        string msg1 = "Amount withdrawal from your Account Rs:"+tamt;
        Email.Deposit(tto,msg);
        Email.Withdrawal(accid,msg1);
       // MobileSms.Deposit(accid,msg1);
       // MobileSms.Deposit(tto, msg);
        Response.Write("<script type='text/javascript'>alert('Funds Transfered Succesfully');</script>");
        TextBox1.Text = "";
        //  Response.Redirect("Home.aspx");
       
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        String tid, tto, tfrom, tamt, tdate, tavaibal;
        if(TextBox1.Text == otp)
        {
            con = new SqlConnection(str);
            con.Open();
            cmd = new SqlCommand("select * from transactions where Status=@1", con);
            cmd.Parameters.AddWithValue("@1","N");
            SqlDataReader sdr = cmd.ExecuteReader();

            if(sdr.Read())
            {
                tid = sdr.GetString(0);
                tto = sdr.GetString(1);
                tfrom = sdr.GetString(2);
                tamt = sdr.GetString(3);
                tdate = sdr.GetString(4);
                tavaibal = sdr.GetString(5);
                balance(tamt,tto,tid);
            }


        }
        else
        {
            i++;
          disable(i);
            
        }
    }
}