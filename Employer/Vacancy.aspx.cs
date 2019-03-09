using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employer_Vacancy : System.Web.UI.Page
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
                    bind();
                }
            }
            else
            { Response.Redirect("~/Login.aspx", false); }
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
            DataTable dt = dl.Vacancy_EmployerID_Disaplay(bl).Tables[0];
            GVVacancyInfo.DataSource = dt;
            GVVacancyInfo.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    public void dateCal()
    {
        try
        {
            DateTime d1 = Convert.ToDateTime(txtStartDate.Text);
            DateTime d2 = Convert.ToDateTime(txtEndDate.Text);
            lblMsg.Text = "";
            if (!((d2 - d1).TotalDays > 0))
            {
                txtStartDate.Text = txtEndDate.Text = null;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please enter Valid Date";
            }
            
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Please enter Valid Date";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        dateCal();
        if (btnSave.Text == "Save")
        {
            try
            {
                bl.Experience = Convert.ToInt32(txtExperience.Text);
                bl.StartDate = Convert.ToDateTime(txtStartDate.Text);
                bl.EndDate = Convert.ToDateTime(txtEndDate.Text);
                bl.SkillName = txtSkill.Text;
                bl.NumberOfPost = Convert.ToInt32(txtNumberOfPost.Text);
                bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
                if (DDLIsClose.SelectedValue == "Yes")
                {
                    bl.IsClose = 1;
                }
                else { bl.IsClose = 0; }
                int i = dl.Vacancy_InsertData(bl);
                if (i > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Successfully saved";
                    txtExperience.Text = txtNumberOfPost.Text = txtSkill.Text = txtEndDate.Text = txtStartDate.Text = "";
                    DDLIsClose.SelectedIndex = 0;
                    bind();
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
                bl.Experience = Convert.ToInt32(txtExperience.Text);
                bl.StartDate = Convert.ToDateTime(txtStartDate.Text);
                bl.EndDate = Convert.ToDateTime(txtEndDate.Text);
                bl.SkillName = txtSkill.Text;
                bl.NumberOfPost = Convert.ToInt32(txtNumberOfPost.Text);
                bl.Vacancy_ID = Convert.ToInt32(Session["Vacancy_ID"].ToString());
                if (DDLIsClose.SelectedValue == "Yes")
                {
                    bl.IsClose = 1;
                }
                else { bl.IsClose = 0; }
                int i = dl.Vacancy_UpdateData(bl);
                if (i > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Successfully updated";
                    txtExperience.Text = txtNumberOfPost.Text = txtSkill.Text = txtEndDate.Text = txtStartDate.Text = "";
                    DDLIsClose.SelectedIndex = 0;
                    btnSave.Text = "Save";
                    bind();
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
    //protected void idCustom_ServerValidate(object source, ServerValidateEventArgs args)
    //{

    //}
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnE = (Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;
            Session["Vacancy_ID"] = GVVacancyInfo.DataKeys[gr.RowIndex].Values["Vacancy_ID"];
            txtExperience.Text = GVVacancyInfo.DataKeys[gr.RowIndex].Values["Experience"].ToString();
            txtStartDate.Text = Convert.ToDateTime(GVVacancyInfo.DataKeys[gr.RowIndex].Values["StartDate"]).ToString("yyyy-MM-dd");
            txtEndDate.Text = Convert.ToDateTime(GVVacancyInfo.DataKeys[gr.RowIndex].Values["EndDate"]).ToString("yyyy-MM-dd");
            txtNumberOfPost.Text = GVVacancyInfo.DataKeys[gr.RowIndex].Values["NumberOfPost"].ToString();
            txtSkill.Text = GVVacancyInfo.DataKeys[gr.RowIndex].Values["Skill"].ToString();
            if (GVVacancyInfo.DataKeys[gr.RowIndex].Values["IsClose"].ToString() == "True")
            {
                DDLIsClose.SelectedIndex = 0;
            }
            else { DDLIsClose.SelectedIndex = 1; }
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
            bl.Vacancy_ID = Convert.ToInt32(GVVacancyInfo.DataKeys[gr.RowIndex].Values["Vacancy_ID"].ToString());
            int i = dl.Vacancy_DeleteData(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Successfully deleted";
                bind();
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Failed to delete";
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
        txtExperience.Text = txtNumberOfPost.Text = txtSkill.Text = txtEndDate.Text = txtStartDate.Text = "";
        DDLIsClose.SelectedIndex = 0;
    }
    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {
        dateCal();
    }
    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {
        dateCal();
    }
}