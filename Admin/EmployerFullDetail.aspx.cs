using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EmployerFullDetail : System.Web.UI.Page
{
    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();
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
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            DataTable dt1 = dl.Administrator_EmployerFullDTL_Display(bl).Tables[0];
            GVEmpInfo.DataSource = dt1;
            GVEmpInfo.DataBind();
            DataTable dt2 = dl.Administrator_EmployerFullDTL_ContactDTL_Display(bl).Tables[0];
            GVContactInfo.DataSource = dt2;
            GVContactInfo.DataBind();
        }
        catch { lblMsg.ForeColor = System.Drawing.Color.Red;
        lblMsg.Text = "Technical error";
        }
    }
    protected void btnActive_Click(object sender, EventArgs e)
    {
        try
        {
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            bl.Employer_IsActive = 1;
            int i = dl.Administrator_Employer_IsActive_Update(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Successfully Activated";

                btnActive.Enabled = false;
                btnBlock.Enabled = true;
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Failed to Active";
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnBlock_Click(object sender, EventArgs e)
    {
        try
        {
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            bl.Employer_IsActive = 0;
            int i = dl.Administrator_Employer_IsActive_Update(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Successfully Blocked";

                btnActive.Enabled = true;
                btnBlock.Enabled = false;
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Failed to Block";
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}