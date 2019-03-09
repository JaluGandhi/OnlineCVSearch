using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobSeeker_Vacancy : System.Web.UI.Page
{
    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["JobSeeker_ID"] != null)
            {
                if (!IsPostBack)
                {
                    bind();
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
            DataTable dt = dl.Vacancy_Display().Tables[0];
            GVVacancyInfo.DataSource = dt;
            GVVacancyInfo.DataBind();
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
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            bl.Vacancy_ID = Convert.ToInt32(GVVacancyInfo.DataKeys[gr.RowIndex].Values["Vacancy_ID"].ToString());
            DataSet ds = dl.AppliedVacancy_JobSeeker_ID_Vacancy_ID_Disaplay(bl);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "You have already applied for this job";
                }
                else
                {

                    bl.AppliedDate = DateTime.Now;
                    bl.AppliedVancayStatus = 0;

                    int i = dl.AppliedVacancy_InsertData(bl);
                    if (i > 0)
                    {
                        try
                        {
                            DataSet ds1 = dl.AppliedVacancy_EmailSend_Details(bl);
                            if (ds1 != null)
                            {
                                //mail code
                                new clsMail().mailSend(ds1.Tables[0].Rows[0]["JobSeekerEmail"].ToString(), "CV_Search-Job-Email-NoReply", "You've applied to this " + ds1.Tables[0].Rows[0]["CompanyName"].ToString());
                                string employerMsg = "JobSeeker has applied on your comapny." + Environment.NewLine + "JobSeeker name is ";
                                new clsMail().mailSend(ds1.Tables[0].Rows[0]["Email"].ToString(), "CV_Search-Job-Email-NoReply", employerMsg + ds1.Tables[0].Rows[0]["Name"].ToString());
                            }
                        }
                        catch
                        {

                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Text = "Technical error";
                        }
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Applied for this job";
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Failed to apply";
                    }
                }
            }
        }
        catch
        {

            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";

        }
    }




    protected void btnSkillSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string SkillName = "";
            string[] Sk = txtSkillSearch.Text.Split(',');
            int fl = 0;
            foreach (string s in Sk)
            {
                if (fl == 0)
                {
                    SkillName = "(Vacancy.Skill like '%" + s.Trim() + "%' ";
                    fl = 1;
                }
                else
                {
                    SkillName += " or Vacancy.Skill like '%" + s.Trim() + "%' ";
                }
            }
            SkillName += ")";
            bl.SkillName = txtSkillSearch.Text;
            DataTable dt = dl.Vacancy_SearchByJobSeeker_Display(bl, SkillName).Tables[0];
            GVVacancyInfo.DataSource = dt;
            GVVacancyInfo.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }



    protected void btnSkillReset_Click(object sender, EventArgs e)
    {
        txtSkillSearch.Text = "";
    }
}