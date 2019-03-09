using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_JobSeekerFullDetail : System.Web.UI.Page
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
            bl.JobSeeker_ID = Convert.ToInt32(Session["JObSeeker_ID"].ToString());
            DataTable dt1 = dl.JobSeekerFullDetail_Profile_Display(bl).Tables[0];
            GVJbProfile.DataSource = dt1;
            GVJbProfile.DataBind();

            DataTable dt2 = dl.JobSeekerPersonalDetailBy_JobSeekerId_Display(bl).Tables[0];
            GVPersonalInfo.DataSource = dt2;
            GVPersonalInfo.DataBind();

            DataTable dt3 = dl.JobSeekerEducationalBy_JobSeekerId_Display(bl).Tables[0];
            GVEducationalInfo.DataSource = dt3;
            GVEducationalInfo.DataBind();


            DataTable dt4 = dl.JobSeekerExperienceDetail_ByJobSeekerId_Display(bl).Tables[0];
            GVExperienceInfo.DataSource = dt4;
            GVExperienceInfo.DataBind();


            DataTable dt5 = dl.JobSeekerSkillDetailBy_JobSeekerId_Display(bl).Tables[0];
            GVSkillInfo.DataSource = dt5;
            GVSkillInfo.DataBind();

            DataTable dt6 = dl.JobSeekerHobbyDetailBy_JobSeekerId_Display(bl).Tables[0];
            GVHobbyInfo.DataSource = dt6;
            GVHobbyInfo.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnActive_Click(object sender, EventArgs e)
    {
        try
        {
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            bl.JobSeeker_IsActive = 1;
            int i = dl.Administrator_JobSeeker_IsActive_Update(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Sucessfully Active";
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
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            bl.JobSeeker_IsActive = 0;
            int i = dl.Administrator_JobSeeker_IsActive_Update(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Sucessfully Block";
                btnBlock.Enabled = false;
                btnActive.Enabled = true;
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