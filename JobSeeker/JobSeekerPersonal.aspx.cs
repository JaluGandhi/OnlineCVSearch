using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobSeeker_JobSeekerPersonal : System.Web.UI.Page
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
            else { Response.Redirect("~/Login.aspx", false); }
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
                bl.City = txtCity.Text;
                bl.State = txtState.Text;
                bl.Country = txtCountry.Text;
                bl.DateOfBirth=Convert.ToDateTime(txtDOB.Text);
                bl.MariatailStatus=DDLMeritialStatus.SelectedValue;
                bl.Passport=txtPassport.Text;
                bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
                if (RadioButtonMale.Checked == true) { bl.Gender = "Male"; }
                else { bl.Gender = "Female"; }
                string filename = "";
                string ext = "";
                if (FLUResume.HasFile)
                {
                     ext = Path.GetExtension(FLUResume.FileName);
                    if (ext.ToLower() == ".doc" || ext.ToLower() == ".docx" || ext.ToLower() == ".pdf")
                    {
                        filename = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") +"_"+ FLUResume.FileName;
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Data Saved But Resume was in invalid format";
                    }
                }
                bl.ResumeFile = filename;
                int i=dl.JobSeekerPersonalDetail_InsertData(bl);
                if (i > 0)
                {
                    if (FLUResume.HasFile)
                    {
                        if (ext.ToLower() == ".doc" || ext.ToLower() == ".docx" || ext.ToLower() == ".pdf")
                        {
                            FLUResume.SaveAs(Server.MapPath("~/Resume/" + filename));
                            bind();
                        }
                        else
                        {
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Text = "Data Saved But Resume was in invalid format";
                        }
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
                    txtCity.Text = txtCountry.Text = txtDOB.Text = txtPassport.Text = txtState.Text = "";
                    DDLMeritialStatus.SelectedIndex = 0;
                    RadioButtonMale.Checked = true;
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Successfully saved";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Faild to save";
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
                bl.City = txtCity.Text;
                bl.State = txtState.Text;
                bl.Country = txtCountry.Text;
                bl.DateOfBirth = Convert.ToDateTime(txtDOB.Text);
                bl.MariatailStatus = DDLMeritialStatus.SelectedValue;
                bl.Passport = txtPassport.Text;
                bl.Personal_ID = Convert.ToInt32(Session["Personal_ID"].ToString());

                if (RadioButtonMale.Checked == true) { bl.Gender = "Male"; }
                else { bl.Gender = "Female"; }
                string filename = "";
                string ext = "";
                if (FLUResume.HasFile)
                {
                    ext = Path.GetExtension(FLUResume.FileName);
                    if (ext.ToLower() == ".doc" || ext.ToLower() == ".docx" || ext.ToLower() == ".pdf")
                    {
                        filename = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss") +"_"+ FLUResume.FileName;
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Data Saved But Resume was in invalid format";
                    }
                }
                else
                {
                    filename = Session["Resume"].ToString();
                }
                bl.ResumeFile = filename;
                int i = dl.JobSeekerPersonalDetail_UpdateData(bl);
                if (i > 0)
                {
                    if (FLUResume.HasFile)
                    {
                        if (ext.ToLower() == ".doc" || ext.ToLower() == ".docx" || ext.ToLower() == ".pdf")
                        {
                            FLUResume.SaveAs(Server.MapPath("~/Resume/" + filename));
                        }
                        else
                        {
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Text = "Data Saved But Resume was in invalid format";
                        }
                    }
                    txtCity.Text = txtCountry.Text = txtDOB.Text = txtPassport.Text = txtState.Text = "";
                    DDLMeritialStatus.SelectedIndex = 0;
                    RadioButtonMale.Checked = true;
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Successfully updated";
                    bind();
                    btnSave.Text = "Save";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Faild to save";
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
            DataTable dt = dl.JobSeekerPersonalDetailBy_JobSeekerId_Display(bl).Tables[0];
            GVPersonalInfo.DataSource = dt;
            GVPersonalInfo.DataBind();
        }
        catch
        {
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
            Session["Personal_ID"] = GVPersonalInfo.DataKeys[gr.RowIndex].Values["Personal_ID"];
            txtCity.Text = GVPersonalInfo.DataKeys[gr.RowIndex].Values["City"].ToString();
            txtCountry.Text = GVPersonalInfo.DataKeys[gr.RowIndex].Values["Country"].ToString();
            txtDOB.Text = Convert.ToDateTime(GVPersonalInfo.DataKeys[gr.RowIndex].Values["DateOfBirth"]).ToString("yyyy-MM-dd");
            txtPassport.Text = GVPersonalInfo.DataKeys[gr.RowIndex].Values["Passport"].ToString();
            txtState.Text = GVPersonalInfo.DataKeys[gr.RowIndex].Values["State"].ToString();
            DDLMeritialStatus.SelectedValue = GVPersonalInfo.DataKeys[gr.RowIndex].Values["MariatailStatus"].ToString();
            if (GVPersonalInfo.DataKeys[gr.RowIndex].Values["Gender"].ToString() == "Male")
            {
                RadioButtonMale.Checked = true;
            }
            else { RadioButtonFemale.Checked = true; }
            Session["Resume"] = GVPersonalInfo.DataKeys[gr.RowIndex].Values["ResumeFile"].ToString();
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
            bl.Personal_ID = Convert.ToInt32(GVPersonalInfo.DataKeys[gr.RowIndex].Values["Personal_ID"].ToString());
            int i = dl.JobSeekerPersonalDetail_DeleteData(bl);
            if (i > 0)
            {
                
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Successfully Deleted";
                bind();
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Faild to delete";
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
            txtCity.Text = txtCountry.Text = txtDOB.Text = txtPassport.Text = txtState.Text = "";
            DDLMeritialStatus.SelectedIndex = 0;
            RadioButtonMale.Checked = true;
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}