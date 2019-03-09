using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employer_InterviewProcess : System.Web.UI.Page
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
                    InterviewProcessBind();
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
            DataSet ds = new DataSet();
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            bl.Vacancy_ID = Convert.ToInt32(Session["Vacancy_ID"].ToString());
            ds = dl.InterviewProcess_AllDetails_Display(bl);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtMobileNumber.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtSkill.Text = ds.Tables[0].Rows[0]["Skill"].ToString();
                    txtFromDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]).ToString("yyyy-MM-dd");
                    txtEndDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]).ToString("yyyy-MM-dd");
                    txtNumberOfPost.Text = ds.Tables[0].Rows[0]["NumberOfPost"].ToString();
                    txtExperience.Text = ds.Tables[0].Rows[0]["Experience"].ToString();

                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Technical error";

                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Technical error";

            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }

    }
    public void InterviewProcessBind()
    {
        try
        {
            bl.AppliedVacancy_ID = Convert.ToInt32(Session["AppliedVacancy_ID"].ToString());
            DataSet ds = dl.InterviewProcess_AppliedVacancy_ID_Display(bl);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtTime.Text = ds.Tables[0].Rows[0]["InterviewTime"].ToString();
                    txtInterviewProcessDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InterviewDate"]).ToString("yyyy-MM-dd");
                    txtContactPersonName.Text = ds.Tables[0].Rows[0]["ContactPersonName"].ToString();
                    txtInterviewAdress.Text = ds.Tables[0].Rows[0]["Location"].ToString();
                    RadioButtonListForJob.Visible = true;
                    RadioButtonListForJob.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                    btnSave.Text = "Save Details";
                }
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            bl.AppliedVacancy_ID = Convert.ToInt32(Session["AppliedVacancy_ID"].ToString());
            DateTime inDate = Convert.ToDateTime(txtInterviewProcessDate.Text);
            if (inDate > DateTime.Now)
            {


                DataSet ds = dl.InterviewProcess_AppliedVacancy_ID_Display(bl);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(RadioButtonListForJob.SelectedValue) > 0)
                        {

                            bl.InterviewProcess_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["InterviewProcess_ID"].ToString());
                            bl.InterviewTime = txtTime.Text;
                            bl.InterviewDate = Convert.ToDateTime(txtInterviewProcessDate.Text);
                            bl.ContactPersonName = txtContactPersonName.Text;
                            bl.Location = txtInterviewAdress.Text;
                            bl.InterviewStatus = Convert.ToInt32(RadioButtonListForJob.SelectedValue);


                            bl.IsDone = 1;
                            int i = dl.InterviewProcess_UpdateData(bl);
                            if (i > 0)
                            {
                                //txtTime.Text = txtInterviewProcessDate.Text = txtContactPersonName.Text = txtInterviewAdress.Text = "";
                                lblMsgInterview.ForeColor = System.Drawing.Color.Green;
                                lblMsgInterview.Text = "Successfully saved";
                            }
                            else
                            {
                                lblMsgInterview.ForeColor = System.Drawing.Color.Red;
                                lblMsgInterview.Text = "Failed to save";
                            }
                        }
                        else
                        {
                            lblMsgInterview.ForeColor = System.Drawing.Color.Red;
                            lblMsgInterview.Text = "Please select any one option";
                        }
                    }
                    else
                    {
                        bl.InterviewTime = txtTime.Text;
                        bl.InterviewDate = Convert.ToDateTime(txtInterviewProcessDate.Text);
                        bl.ContactPersonName = txtContactPersonName.Text;
                        bl.Location = txtInterviewAdress.Text;
                        bl.InterviewStatus = 0;
                        bl.IsDone = 0;
                        int i = dl.InterviewProcess_InsertData(bl);
                        if (i > 0)
                        {
                            //txtTime.Text = txtInterviewProcessDate.Text = txtContactPersonName.Text = txtInterviewAdress.Text = "";
                            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
                            DataSet ds1 = dl.EmployerRegistration_EmployerID_Display(bl);
                            try
                            {
                                
                                //send mail from company to jobseeker for interview information
                                string Jbsmsg = ds1.Tables[0].Rows[0]["CompanyName"].ToString() + System.Environment.NewLine +
                                   "Your interview is set on " + Convert.ToDateTime(txtInterviewProcessDate.Text).ToString("dd-MM-yyyy") +
                                   " at " + txtTime.Text + System.Environment.NewLine +
                                   "Address is "+txtInterviewAdress.Text+System.Environment.NewLine+
                                   "Contact person name is " + txtContactPersonName.Text;
                                new clsMail().mailSend(txtEmail.Text, "CV_Search_Interview_Set", Jbsmsg);
                            }
                            catch { }
                            try
                            {

                                //send mail to company for interview information
                                string Empmsg = "You have set the interview  for " + txtName.Text + System.Environment.NewLine +
                                   "Contact person name is " + txtContactPersonName.Text + System.Environment.NewLine +
                                   "Interview date is " + Convert.ToDateTime(txtInterviewProcessDate.Text).ToString("dd-MM-yyyy") +
                                   " at " + txtTime.Text + System.Environment.NewLine +
                                   "Address is " + txtInterviewAdress.Text;
                                new clsMail().mailSend(ds1.Tables[0].Rows[0]["Email"].ToString(), "CV_Search_Interview_Set", Empmsg);

                            }
                            catch { }
                            lblMsgInterview.ForeColor = System.Drawing.Color.Green;
                            lblMsgInterview.Text = "Successfully saved";
                        }
                        else
                        {
                            lblMsgInterview.ForeColor = System.Drawing.Color.Red;
                            lblMsgInterview.Text = "Failed to save";
                        }
                    }
                }
            }
            else
            {
                lblMsgInterview.ForeColor = System.Drawing.Color.Red;
                lblMsgInterview.Text = "Interview Date Must be Greater than Today";
            }
        }
        catch
        {
            txtInterviewProcessDate.Text = "";
            lblMsgInterview.ForeColor = System.Drawing.Color.Red;
            lblMsgInterview.Text = "Technical error";
        }

    }
}