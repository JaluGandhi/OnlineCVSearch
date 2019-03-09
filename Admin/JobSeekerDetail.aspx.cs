using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_JobSeekerDetail : System.Web.UI.Page
{
    DataLayer dl = new DataLayer();
    BussinessLayer bl = new BussinessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Administrator_Id"] != null)
            {
                if (!IsPostBack)
                {
                    bind();
                }
            }

            else { Response.Redirect("AdminLogin.aspx", false); }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }

    }
    public void bind()
    {
        try
        {
            DataTable dt = dl.Administrator_JobSeekerBasic_Display().Tables[0];
            GVJbInfo.DataSource = dt;
            GVJbInfo.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnFullDetail_Click(object sender, EventArgs e)
    {
        try
        {

            Button btnE = (Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;
            Session["JobSeeker_ID"] = GVJbInfo.DataKeys[gr.RowIndex].Values["JobSeeker_ID"].ToString();
            Response.Redirect("JobSeekerFullDetail.aspx", false);
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}