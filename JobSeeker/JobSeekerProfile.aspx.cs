using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobSeeker_JobSeekerProfile : System.Web.UI.Page
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
                    Bind_ProfileData();
                    checkProfile();
                    if (Session["Percenteage"] != null)
                    {
                        int per = Convert.ToInt32(Session["Percenteage"].ToString());
                        if (per < 100)
                        {
                            lnkPDFCreate.Enabled = false;
                            VacErrMsg.Visible = true;
                            VacErrMsg.ForeColor = System.Drawing.Color.Red;
                            VacErrMsg.Text = per + "% COMPELETE";
                        }
                        else
                        {
                            lnkPDFCreate.Enabled = true;
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
        catch {
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


    protected void lnkPDFCreate_Click(object sender, EventArgs e)
    {
        try
        {

            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            DataSet ds0 = dl.JobSeekerRegistrationBy_JobSeekerID_Display(bl);
            DataSet ds1 = dl.JobSeekerEducationalBy_JobSeekerId_Display(bl);
            DataSet ds2 = dl.JobSeekerExperienceDetail_ByJobSeekerId_Display(bl);
            DataSet ds3 = dl.JobSeekerHobbyDetailBy_JobSeekerId_Display(bl);
            DataSet ds4 = dl.JobSeekerPersonalDetailBy_JobSeekerId_Display(bl);
            DataSet ds5 = dl.JobSeekerSkillDetailBy_JobSeekerId_Display(bl);


            StreamReader sr = new StreamReader(Server.MapPath("~/Resume/index.html"));
            string html = sr.ReadToEnd();
            html = html.Replace("#FNAME#", ds0.Tables[0].Rows[0]["FirstName"].ToString());
            html = html.Replace("#LNAME#", ds0.Tables[0].Rows[0]["LastName"].ToString());
            html = html.Replace("#EMAIL#", ds0.Tables[0].Rows[0]["Email"].ToString());
            html = html.Replace("#MOBILE#", ds0.Tables[0].Rows[0]["MobileNumber"].ToString());

            string Hobby = "";
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                Hobby += "<span class='key'>" + ds3.Tables[0].Rows[i]["HobbyName"] + "</span>";
            }
            html = html.Replace("#HOBBY#", Hobby);
            string Skill = "";
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                Skill += "<li>" + ds5.Tables[0].Rows[i]["SkillName"] + "</li>";
            }
            html = html.Replace("#SKILL#", Skill);

            string Education = "";
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string per = ds1.Tables[0].Rows[i]["Percentage"].ToString() + "%";
                Education += "<tr><td>" + ds1.Tables[0].Rows[i]["Board"].ToString() + "</td><td>" + ds1.Tables[0].Rows[i]["University"].ToString() + "</td><td>" + ds1.Tables[0].Rows[i]["Result"].ToString() + "</td><td>" + per + "</td></tr>";
            }
            html = html.Replace("#EDUCATION#", Education);

            string Experience = "";
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                string stdate = ds2.Tables[0].Rows[i]["StartDate1"].ToString();
                string eddate = ds2.Tables[0].Rows[i]["EndDate1"].ToString();
                Experience += "<tr><td>" + ds2.Tables[0].Rows[i]["CompanyName"].ToString() + "</td> <td>" + stdate + "</td><td>" + eddate + "</td> <td>" + ds2.Tables[0].Rows[i]["NumberOfYear"].ToString() + "</td></tr>";
            }
            html = html.Replace("#EXPERIENCE#", Experience);

            string add = ds4.Tables[0].Rows[0]["City"].ToString() + "," + ds4.Tables[0].Rows[0]["State"].ToString() + "," + ds4.Tables[0].Rows[0]["Country"].ToString()+".";
            html = html.Replace("#ADDRESS#", add);

            html = html.Replace("#GENDER#", ds4.Tables[0].Rows[0]["Gender"].ToString());

            html = html.Replace("#BIRTHDATE#", ds4.Tables[0].Rows[0]["DateOfBirth1"].ToString());
            html = html.Replace("#MARIATAIL#", ds4.Tables[0].Rows[0]["MariatailStatus"].ToString());
            html = html.Replace("#PASSPORT#", ds4.Tables[0].Rows[0]["Passport"].ToString());

            html=html.Replace("#PINCODE#",ds0.Tables[0].Rows[0]["Pincode"].ToString());


            string FileName = Session["JobSeeker_ID"].ToString() + "_Resume_Generate_" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + ".pdf";
            if (HtmlToPDF(html, FileName))
            {
                //Success
                bl.ResumeFile = FileName;
                bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
                try
                {
                    int i = dl.JobSeekerPersonalDetail_ResumeFile_UpdateData(bl);
                    if (i > 0)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Resume is successfully created";
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Resume is failed to create created";
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
                //Fail
            }
        }
        catch { }
    }

    public bool HtmlToPDF(string html, string FileName)
    {
        //FileName=1_Resume_Generate_dd_MM_yyyy_hh_mm_ss.pdf
        try
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(Server.MapPath("~/Resume/" + FileName));
                return true;
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
        return false;
    }




    public void Bind_ProfileData()
    {
        try {
            int JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            DataSet ds = new DataSet();
            bl = new BussinessLayer();
            bl.JobSeeker_ID = JobSeeker_ID;
            ds = dl.JobSeekerRegistrationBy_JobSeekerID_Display(bl);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtMiddleName.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtContactNumber.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Email or Password are incorrect";
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Technincal Error";
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
            if (txtContactNumber.Text.Length == 10)
            {
                if (txtPincode.Text.Length == 6)
                {
                    bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
                    bl.Address = txtAddress.Text;
                    bl.Pincode = txtPincode.Text;
                    bl.MobileNumber = txtContactNumber.Text;
                    bl.FirstName = txtFirstName.Text;
                    bl.LastName = txtLastName.Text;
                    bl.MiddleName = txtMiddleName.Text;
                    int i = dl.JobSeekerRegistration_UpdateData(bl);
                    if (i > 0)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Successfully saved";
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
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Pincode number must be 6 didgit"; 
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Contact number must be 10 digit";
            }

        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technincal Error";
        }
    }


    
}