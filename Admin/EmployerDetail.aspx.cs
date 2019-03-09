using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EmployerDetail : System.Web.UI.Page
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
                    bind_DDLIndustryType();
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
    public void bind_DDLIndustryType()
    {
        try
        {
            DataTable dt = dl.IndustryType_Display().Tables[0];
            DDLIndustryType.DataSource = dt;
            DDLIndustryType.DataTextField = "IndustryName";
            DDLIndustryType.DataValueField = "IndustryType_ID";
            DDLIndustryType.DataBind();
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
            bl.IndustryType_ID =Convert.ToInt32( DDLIndustryType.SelectedValue.ToString());
            DataTable dt = dl.Administrator_EmplyerBasic_Display(bl).Tables[0];
            GVEmpInfo.DataSource = dt;
            GVEmpInfo.DataBind();
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

            Session["Employer_ID"] = GVEmpInfo.DataKeys[gr.RowIndex].Values["Employer_ID"].ToString();
            Response.Redirect("EmployerFullDetail.aspx", false);
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void DDLIndustryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            bind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}