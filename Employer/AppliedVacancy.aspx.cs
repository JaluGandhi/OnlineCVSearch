using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employer_AppliedVacancy : System.Web.UI.Page
{
    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Employer_ID"] != null)
            {
                if (!IsPostBack)
                {
                    GVAppliedVacancyInfoPending.Visible = true;
                    bind();
                    GVAppliedVacancyInfoAproval.Visible = false;
                    GVAppliedVacancyInfoReject.Visible = false;

                }
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
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
            DataTable dt = dl.AppliedVacancy_Pending_Display(bl).Tables[0];
            GVAppliedVacancyInfoPending.DataSource = dt;
            GVAppliedVacancyInfoPending.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        try
        {
            Button btE = (Button)sender;
            GridViewRow gr = (GridViewRow)btE.NamingContainer;
            bl.AppliedVacancy_ID = Convert.ToInt32(GVAppliedVacancyInfoPending.DataKeys[gr.RowIndex].Values["AppliedVacancy_ID"].ToString());
            bl.AppliedVancayStatus = 1;
            int i = dl.AppliedVacancy_StatusChance_Employer(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "You have aproved to this JobSeeker";
                bind();
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Failed to Agree";
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    //protected void btnDelete_Click(object sender, EventArgs e)
    //{
        
    //}
    
    protected void btnReject_Click(object sender, EventArgs e)
    {
        try
        {
            Button btE = (Button)sender;
            GridViewRow gr = (GridViewRow)btE.NamingContainer;
            bl.AppliedVacancy_ID = Convert.ToInt32(GVAppliedVacancyInfoPending.DataKeys[gr.RowIndex].Values["AppliedVacancy_ID"].ToString());
            bl.AppliedVancayStatus = 2;
            int i = dl.AppliedVacancy_StatusChance_Employer(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "You have rejected to this JobSeeker";
                bind();
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Failed to Agree";
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void LinkBtnAprovel_Click(object sender, EventArgs e)
    {
        try
        {
            GVAppliedVacancyInfoAproval.Visible = true;
            GVAppliedVacancyInfoReject.Visible = false;
            GVAppliedVacancyInfoPending.Visible = false;
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            DataTable dt = dl.AppliedVacancy_Approval_Display(bl).Tables[0];
            GVAppliedVacancyInfoAproval.DataSource = dt;
            GVAppliedVacancyInfoAproval.DataBind();
           
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void LinkBtnReject_Click(object sender, EventArgs e)
    {
        try
        {
            GVAppliedVacancyInfoReject.Visible = true;
            GVAppliedVacancyInfoAproval.Visible = false;
            GVAppliedVacancyInfoPending.Visible = false;
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            DataTable dt = dl.AppliedVacancy_Reject_Display(bl).Tables[0];
            GVAppliedVacancyInfoReject.DataSource = dt;
            GVAppliedVacancyInfoReject.DataBind();
           
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void LinkBtnPending_Click(object sender, EventArgs e)
    {
        try
        {
            GVAppliedVacancyInfoPending.Visible = true;
            GVAppliedVacancyInfoAproval.Visible = false;
            GVAppliedVacancyInfoReject.Visible = false;
            bind();
           
        }
        catch
        {

            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnInterview_Click(object sender, EventArgs e)
    {
        try
        {
            Button btE = (Button)sender;
            GridViewRow gr = (GridViewRow)btE.NamingContainer;

            Session["AppliedVacancy_ID"] = GVAppliedVacancyInfoAproval.DataKeys[gr.RowIndex].Values["AppliedVacancy_ID"].ToString();
            Session["JobSeeker_ID"] = GVAppliedVacancyInfoAproval.DataKeys[gr.RowIndex].Values["JobSeeker_ID"].ToString();
            Session["Vacancy_ID"] = GVAppliedVacancyInfoAproval.DataKeys[gr.RowIndex].Values["Vacancy_ID"].ToString();
            Response.Redirect("InterviewProcess.aspx", false);
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}