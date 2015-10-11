using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Complain : System.Web.UI.Page
{
    String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null || Session["user_name"] == "")
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            load_grid();
            Label1.Text = Session["user_id"].ToString();
        }
    }

    public void load_grid()
    {
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select * from complain", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String date = DateTime.Now.ToShortDateString();
        String time = DateTime.Now.ToShortTimeString();
        try
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into complain values(@1,@2,@3,@4,@5)", con);
            cmd.Parameters.AddWithValue("@1", Label1.Text);
            cmd.Parameters.AddWithValue("@2", TextBox1.Text);
            cmd.Parameters.AddWithValue("@3", date);
            cmd.Parameters.AddWithValue("@4", time);
            cmd.Parameters.AddWithValue("@5", "Waiting");
            cmd.ExecuteNonQuery();
            con.Close();
            TextBox1.Text = "";
            load_grid();
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String id = GridView1.Rows[e.RowIndex].Cells[1].Text;
        SqlConnection con = new SqlConnection(str);
        con.Open();
        SqlCommand cmd = new SqlCommand("Delete from complain Where accountid=@1", con);
        cmd.Parameters.AddWithValue("@1", id);
        cmd.ExecuteScalar();
        con.Close();
        load_grid();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}