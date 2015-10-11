using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Adm : System.Web.UI.Page
{
    String str = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    SqlConnection con;
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        //load_grid(); 
        if(!this.IsPostBack)
        {
            load_grid(); 
        }
    }

    public void load_grid()
    {
        con = new SqlConnection(str);
        con.Open();
        cmd = new SqlCommand("select * from registration",con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();

    }

    public void delete_reg(object sender, GridViewDeleteEventArgs e)
    {
        String un = GridView1.DataKeys[e.RowIndex].Value.ToString();
        con=new SqlConnection(str);
        con.Open();
        cmd = new SqlCommand("Delete from registration where username=@1", con);
        cmd.Parameters.AddWithValue("@1",un);
        int i = cmd.ExecuteNonQuery();
        if (i == 1)
        {
            Response.Write("<script language='javascript'>alert('record deleted successfully');</script>");
            load_grid();
        }
        con.Close();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        load_grid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        load_grid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        String un = GridView1.DataKeys[e.RowIndex].Value.ToString();
        String dob = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("dateofbirth")).Text.ToString();
        String email = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("email")).Text.ToString();
        String mob = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("mobile")).Text.ToString();
        String acctyp = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("accounttype")).Text.ToString();
        String aid = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("accountid")).Text.ToString();

        con.Open();
        SqlCommand cmd = new SqlCommand("Update registration set dateofbirth=@1,email=@2,mobile=@3,accounttype=@4,accountid=@6 where username=@7", con);
        cmd.Parameters.AddWithValue("@1", dob);
        cmd.Parameters.AddWithValue("@2", email);
        cmd.Parameters.AddWithValue("@3", mob);
        cmd.Parameters.AddWithValue("@4", acctyp);
        //cmd.Parameters.AddWithValue("@5", "~/profile/"+pics);
        cmd.Parameters.AddWithValue("@6", aid);
        cmd.Parameters.AddWithValue("@7", un);
        cmd.ExecuteNonQuery();
        con.Close();

        load_grid();
    }
}