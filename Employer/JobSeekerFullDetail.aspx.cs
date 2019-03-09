using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employer_JobSeekerFullDetail : System.Web.UI.Page
{
    DataLayer dl = new DataLayer();
    BussinessLayer bl = new BussinessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Employer_ID"] != null)
            {
                if (!IsPostBack)
                {
                    bind();
                }
            }
            else { Response.Redirect("~/Login.aspx", false); }
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
}