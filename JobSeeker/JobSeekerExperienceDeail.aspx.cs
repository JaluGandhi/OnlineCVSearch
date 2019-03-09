using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobSeeker_JobSeekerExperienceDeail : System.Web.UI.Page
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
                    checkProfile();
                    if (Session["Percenteage"] != null)
                    {
                        int per = Convert.ToInt32(Session["Percenteage"].ToString());
                        if (per < 100)
                        {
                            VacErrMsg.Visible = true;
                            VacErrMsg.ForeColor = System.Drawing.Color.Red;
                            VacErrMsg.Text = per + "% COMPELETE";
                        }
                        else
                        {
                            VacErrMsg.Visible = true;
                            VacErrMsg.ForeColor = System.Drawing.Color.LimeGreen;
                            VacErrMsg.Text = per + "% COMPELETE";
                        }
                    }
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
    public void checkProfile()
    {
        try
        {
            int per = 0;
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            DataSet ds1 = dl.JobSeekerEducationalBy_JobSeekerId_Display(bl);
            DataSet ds2 = dl.JobSeekerExperienceDetail_ByJobSeekerId_Display(bl);
            DataSet ds3 = dl.JobSeekerHobbyDetailBy_JobSeekerId_Display(bl);
            DataSet ds4 = dl.JobSeekerPersonalDetailBy_JobSeekerId_Display(bl);
            DataSet ds5 = dl.JobSeekerSkillDetailBy_JobSeekerId_Display(bl);


            if (ds1.Tables[0].Rows.Count > 0)
            {
                per = per + 20;
            }
            if (ds2.Tables[0].Rows.Count > 0)
            {
                per = per + 20;
            }
            if (ds3.Tables[0].Rows.Count > 0)
            {
                per = per + 20;
            }
            if (ds4.Tables[0].Rows.Count > 0)
            {
                per = per + 20;
            }
            if (ds5.Tables[0].Rows.Count > 0)
            {
                per = per + 20;
            }


            Session["Percenteage"] = per;
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                bl.CompanyName = txtCompanyName.Text;
                bl.StartDate = Convert.ToDateTime(txtStartDate.Text);
                bl.EndDate = Convert.ToDateTime(txtEndDate.Text);
                bl.NumberOfYear = Convert.ToInt32(txtNumberOfYear.Text);
                bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
                if (RBIsContinueYes.Checked == true)
                    bl.IsContinue = 1;
                else
                    bl.IsContinue = 0;
                int i = dl.JobSeekerExperienceDetail_InsertData(bl);
                if (i > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Successfully saved";
                    txtCompanyName.Text = txtNumberOfYear.Text = txtEndDate.Text = txtStartDate.Text = "";
                    RBIsContinueYes.Checked = true;
                    bind();
                    checkProfile();
                    if (Session["Percenteage"] != null)
                    {
                        int per = Convert.ToInt32(Session["Percenteage"].ToString());
                        if (per < 100)
                        {
                            VacErrMsg.Visible = true;
                            VacErrMsg.ForeColor = System.Drawing.Color.Red;
                            VacErrMsg.Text = per + "% COMPELETE";
                        }
                        else
                        {
                            VacErrMsg.Visible = true;
                            VacErrMsg.ForeColor = System.Drawing.Color.LimeGreen;
                            VacErrMsg.Text = per + "% COMPELETE";
                        }
                    }
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Failed to save";
                }
            }
            catch
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Technical error";
            }

        }
        else
        {
            try
            {
                bl.CompanyName = txtCompanyName.Text;
                bl.StartDate = Convert.ToDateTime(txtStartDate.Text);
                bl.EndDate = Convert.ToDateTime(txtEndDate.Text);
                bl.NumberOfYear = Convert.ToInt32(txtNumberOfYear.Text);
                //bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
                bl.Experience_ID = Convert.ToInt32(ViewState["Experience_ID"].ToString());
                if (RBIsContinueYes.Checked == true)
                    bl.IsContinue = 1;
                else
                    bl.IsContinue = 0;
                int i = dl.JobSeekerExperienceDetail_UpdateData(bl);
                if (i > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Successfully updated";
                    txtCompanyName.Text = txtNumberOfYear.Text = txtEndDate.Text = txtStartDate.Text = "";
                    RBIsContinueYes.Checked = true;
                    bind();
                    btnSave.Text = "Save";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Failed to update";
                }
            }
            catch
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Technical error";
            }
        }
    }
    public void bind()
    {
        try
        {
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            DataTable dt = dl.JobSeekerExperienceDetail_ByJobSeekerId_Display(bl).Tables[0];
            GVExperienceInfo.DataSource = dt;
            GVExperienceInfo.DataBind();
        }
        catch {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {

            Button btnE = (Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;
            ViewState["Experience_ID"] = GVExperienceInfo.DataKeys[gr.RowIndex].Values["Experience_ID"];
            txtCompanyName.Text = GVExperienceInfo.DataKeys[gr.RowIndex].Values["CompanyName"].ToString();
            txtStartDate.Text = Convert.ToDateTime(GVExperienceInfo.DataKeys[gr.RowIndex].Values["StartDate"]).ToString("yyyy-MM-dd");
            txtEndDate.Text = Convert.ToDateTime(GVExperienceInfo.DataKeys[gr.RowIndex].Values["EndDate"]).ToString("yyyy-MM-dd");
            txtNumberOfYear.Text = GVExperienceInfo.DataKeys[gr.RowIndex].Values["NumberOfYear"].ToString();
            string rb = GVExperienceInfo.DataKeys[gr.RowIndex].Values["ISContinue1"].ToString();
            if (rb == "Yes")
            {
                RBIsContinueYes.Checked = true;
            }
            else { RBIsContinueNo.Checked = true; }
            btnSave.Text = "Update";
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnE = (Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;
            bl.Experience_ID = Convert.ToInt32(GVExperienceInfo.DataKeys[gr.RowIndex].Values["Experience_ID"].ToString());
            int i = dl.JobSeekerExperienceDetail_DeleteData(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Successfully Deleted";
                bind();
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Failed to Delete";
                bind();
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }

    public void CalYear()
    {
        try {
            DateTime d1 = Convert.ToDateTime(txtStartDate.Text);
            DateTime d2 = Convert.ToDateTime(txtEndDate.Text);
            if ((d2 - d1).TotalDays >= 0)
            {
                double yy = ((d2 - d1).TotalDays) / 365;

                txtNumberOfYear.Text = Math.Floor(yy).ToString();
                lblMsg.Text = "";
            }
            else
            {
                txtStartDate.Text = txtEndDate.Text = "";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please enter Valid Date";
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtStartDate.Text.Length == 10 && txtEndDate.Text.Length == 10)
            {
                CalYear();
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtStartDate.Text.Length == 10 && txtEndDate.Text.Length == 10)
            {
                CalYear();
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtCompanyName.Text = txtEndDate.Text = txtStartDate.Text = txtNumberOfYear.Text = "";
            RBIsContinueYes.Checked = true;
            btnSave.Text = "Save";
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}