using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class AdminHome : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Server=R\\SQLEXPRESS;Database=OnlineBank;uid=sa;pwd=akshaya");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGrid();
            TransGrid();
        }
    }

    protected void TransGrid()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from transactions", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {
            GridViewTtansaction.DataSource = ds;
            GridViewTtansaction.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridViewTtansaction.DataSource = ds;
            GridViewTtansaction.DataBind();
            int columncount = gvDetails.Rows[0].Cells.Count;
            GridViewTtansaction.Rows[0].Cells.Clear();
            GridViewTtansaction.Rows[0].Cells.Add(new TableCell());
            GridViewTtansaction.Rows[0].Cells[0].ColumnSpan = columncount;
            GridViewTtansaction.Rows[0].Cells[0].Text = "No Records Found";
        }
        con.Close();
    }
    protected void BindGrid()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from registration",con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvDetails.DataSource = ds;
            gvDetails.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gvDetails.DataSource = ds;
            gvDetails.DataBind();
            int columncount = gvDetails.Rows[0].Cells.Count;
            gvDetails.Rows[0].Cells.Clear();
            gvDetails.Rows[0].Cells.Add(new TableCell());
            gvDetails.Rows[0].Cells[0].ColumnSpan = columncount;
            gvDetails.Rows[0].Cells[0].Text = "No Records Found";
        }
        con.Close();
    }

    protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDetails.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDetails.EditIndex = -1;
        BindGrid();
    }

    protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        String un = gvDetails.DataKeys[e.RowIndex].Value.ToString();
        String dob =((TextBox)gvDetails.Rows[e.RowIndex].FindControl("textdob")).Text.ToString();
        String eid = ((TextBox)gvDetails.Rows[e.RowIndex].FindControl("textemail")).Text.ToString();
        String mob =((TextBox) gvDetails.Rows[e.RowIndex].FindControl("textmobile")).Text.ToString();
        String atype = ((TextBox)gvDetails.Rows[e.RowIndex].FindControl("textacctype")).Text.ToString();
       // String pics = gvDetails.Rows[e.RowIndex].FindControl("img1").ToString();
        String aid = ((TextBox)gvDetails.Rows[e.RowIndex].FindControl("textaccid")).Text.ToString();

        con.Open();
        SqlCommand cmd = new SqlCommand("Update registration set dateofbirth=@1,email=@2,mobile=@3,accounttype=@4,accountid=@6 where username=@7",con);
        cmd.Parameters.AddWithValue("@1", dob);
        cmd.Parameters.AddWithValue("@2", eid);
        cmd.Parameters.AddWithValue("@3", mob);
        cmd.Parameters.AddWithValue("@4", atype);
        //cmd.Parameters.AddWithValue("@5", "~/profile/"+pics);
        cmd.Parameters.AddWithValue("@6", aid);
        cmd.Parameters.AddWithValue("@7", un);
        cmd.ExecuteNonQuery();
        con.Close();

        lblresult.ForeColor = Color.Green;
        lblresult.Text = un+"Updated Successfully";
        gvDetails.EditIndex = -1;
        BindGrid();
    }

    protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String un = gvDetails.DataKeys[e.RowIndex].Value.ToString();

        con.Open();
        SqlCommand cmd = new SqlCommand("Delete from registration where username=@1", con);
        cmd.Parameters.AddWithValue("@1",un);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if(i==1)
        {
            BindGrid();
            lblresult.ForeColor = Color.Red;
            lblresult.Text = un + " details deleted successfully";
        }
        
    }

    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "username"));
            //identifying the control in gridview
            ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("imgbtnDelete");
            //raising javascript confirmationbox whenver user clicks on link button
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");
            }

        }
    }

    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("AddNew"))
        {
            TextBox Un = (TextBox)gvDetails.FooterRow.FindControl("txtusername");
            TextBox dob = (TextBox)gvDetails.FooterRow.FindControl("txtdob");
            TextBox mail = (TextBox)gvDetails.FooterRow.FindControl("txtemail");
            TextBox mob = (TextBox)gvDetails.FooterRow.FindControl("txtmobile");
            TextBox acctype = (TextBox)gvDetails.FooterRow.FindControl("txtacctype");
            TextBox accid = (TextBox)gvDetails.FooterRow.FindControl("txtaccid");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into registration values(@1,@2,@3,@4,@5,@6,@7)",con);
            cmd.Parameters.AddWithValue("@1", Un.Text);
            cmd.Parameters.AddWithValue("@2", dob.Text);
            cmd.Parameters.AddWithValue("@3", mail.Text);
            cmd.Parameters.AddWithValue("@4", mob.Text);
            cmd.Parameters.AddWithValue("@5", acctype.Text);
            cmd.Parameters.AddWithValue("@6", "~/profile/regis.jpg");
            cmd.Parameters.AddWithValue("@7", accid.Text);
                
            int result = cmd.ExecuteNonQuery();
            con.Close();
            gvDetails.EditIndex = -1;
            if (result == 1)
            {
                BindGrid();
                lblresult.ForeColor = Color.Green;
                lblresult.Text = Un.Text + " Details inserted successfully";
            }
            else
            {
                lblresult.ForeColor = Color.Red;
                lblresult.Text = Un.Text + " Details not inserted";
            }


        }
    }

    protected void gvDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridViewTtansaction_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewTtansaction.EditIndex = e.NewEditIndex;
        TransGrid();
    }
    protected void GridViewTtansaction_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewTtansaction.EditIndex = -1;
        TransGrid();
    }
    protected void GridViewTtansaction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String transid = GridViewTtansaction.DataKeys[e.RowIndex].Value.ToString();

        con.Open();
        SqlCommand cmd = new SqlCommand("Delete from transactions where Transaction_ID=@1", con);
        cmd.Parameters.AddWithValue("@1", transid);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i == 1)
        {
            TransGrid();
            lbltrans.ForeColor = Color.Red;
            lbltrans.Text = transid + " details deleted successfully";
        }
    }
    protected void GridViewTtansaction_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        String transid = GridViewTtansaction.DataKeys[e.RowIndex].Value.ToString();
        String to = ((TextBox)GridViewTtansaction.Rows[e.RowIndex].FindControl("texttto")).Text.ToString();
        String from = ((TextBox)GridViewTtansaction.Rows[e.RowIndex].FindControl("texttfrom")).Text.ToString();
        String amt = ((TextBox)GridViewTtansaction.Rows[e.RowIndex].FindControl("textamt")).Text.ToString();
        String date = ((TextBox)GridViewTtansaction.Rows[e.RowIndex].FindControl("textdate")).Text.ToString();
        String abal = ((TextBox)GridViewTtansaction.Rows[e.RowIndex].FindControl("textabal")).Text.ToString();
        String status = ((TextBox)GridViewTtansaction.Rows[e.RowIndex].FindControl("textstatus")).Text.ToString();

        con.Open();
        SqlCommand cmd = new SqlCommand("Update transactions set Transfer_to=@1,Transfer_from=@2,Amount=@3,Date=@4,Available_Balance=@5,Status=@6 where Transaction_ID=@7", con);
        cmd.Parameters.AddWithValue("@1", to);
        cmd.Parameters.AddWithValue("@2", from);
        cmd.Parameters.AddWithValue("@3", amt);
        cmd.Parameters.AddWithValue("@4", date);
        cmd.Parameters.AddWithValue("@5", abal);
        cmd.Parameters.AddWithValue("@6", status);
        cmd.Parameters.AddWithValue("@7", transid);
        int n= cmd.ExecuteNonQuery();
        con.Close();
        if (n == 1)
        {
            lbltrans.ForeColor = Color.Green;
            lbltrans.Text = transid + "Updated Successfully";
            GridViewTtansaction.EditIndex = -1;
            TransGrid();
        }
    }
    protected void GridViewTtansaction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("AddNew1"))
        {
            TextBox transid = (TextBox)GridViewTtansaction.FooterRow.FindControl("txttid");
            TextBox to = (TextBox)GridViewTtansaction.FooterRow.FindControl("txttto");
            TextBox from = (TextBox)GridViewTtansaction.FooterRow.FindControl("txttfrom");
            TextBox amt = (TextBox)GridViewTtansaction.FooterRow.FindControl("txtamt");
            TextBox date = (TextBox)GridViewTtansaction.FooterRow.FindControl("txtdate");
            TextBox abal = (TextBox)GridViewTtansaction.FooterRow.FindControl("txtabal");
            TextBox status = (TextBox)GridViewTtansaction.FooterRow.FindControl("txtstatus");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into transactions values(@1,@2,@3,@4,@5,@6,@7)", con);
            cmd.Parameters.AddWithValue("@1", transid.Text);
            cmd.Parameters.AddWithValue("@2", to.Text);
            cmd.Parameters.AddWithValue("@3", from.Text);
            cmd.Parameters.AddWithValue("@4", amt.Text);
            cmd.Parameters.AddWithValue("@5", date.Text);
            cmd.Parameters.AddWithValue("@6", abal.Text);
            cmd.Parameters.AddWithValue("@7", status.Text);

            int result = cmd.ExecuteNonQuery();
            con.Close();
            GridViewTtansaction.EditIndex = -1;
            if (result == 1)
            {
                TransGrid();
                lbltrans.ForeColor = Color.Green;
                lbltrans.Text = transid.Text + " Details inserted successfully";
            }
            else
            {
                lbltrans.ForeColor = Color.Red;
                lbltrans.Text = transid.Text + " Details not inserted";
            }


        }
    }


}