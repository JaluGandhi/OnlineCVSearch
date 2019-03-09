using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobSeeker_JobSeekerMaster : System.Web.UI.MasterPage
{
    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkBtnVacancy_Click(object sender, EventArgs e)
    {
        try
        {
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            DataSet ds1 = dl.JobSeekerEducationalBy_JobSeekerId_Display(bl);
            DataSet ds2 = dl.JobSeekerExperienceDetail_ByJobSeekerId_Display(bl);
            DataSet ds3 = dl.JobSeekerHobbyDetailBy_JobSeekerId_Display(bl);
            DataSet ds4 = dl.JobSeekerPersonalDetailBy_JobSeekerId_Display(bl);
            DataSet ds5 = dl.JobSeekerSkillDetailBy_JobSeekerId_Display(bl);
            if (ds1 != null && ds2 != null && ds3 != null && ds4 != null && ds5 != null)
            {
                if (ds1.Tables[0].Rows.Count > 0 && ds2.Tables[0].Rows.Count > 0 && ds3.Tables[0].Rows.Count > 0 && ds4.Tables[0].Rows.Count > 0 && ds5.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect("Vacancy.aspx", false);
                }
                else
                {
                    lblMsg.Text = "Your Profile was not complete | Please Complete it before apply on job";
                    pnlPopUp.Visible = true;
                }
            }
            else
            {
                lblMsg.Text = "Your Profile was not complete | Please Complete it before apply on job";
                pnlPopUp.Visible = true;
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnPopUpClose_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        pnlPopUp.Visible = false;
    }
}
