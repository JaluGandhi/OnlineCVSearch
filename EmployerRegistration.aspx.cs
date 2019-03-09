using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployerRegistration : System.Web.UI.Page
{
    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                bind_DDLIndustryType();
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }


    public void bind_DDLIndustryType()
    {
        try
        {
            DataTable dt = dl.IndustryType_Display().Tables[0];
            DDLIndustryType.DataSource = dt;
            DDLIndustryType.DataTextField = "IndustryName";
            DDLIndustryType.DataValueField = "IndustryType_ID";
            DDLIndustryType.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }

    public string Base64Encription(string plaintext)
    {
        var plaintextbyetes = Encoding.UTF8.GetBytes(plaintext);
        string encodedtext = Convert.ToBase64String(plaintextbyetes);
        return encodedtext;
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {

        bl.Email = txtEmailId.Text;

        DataSet ds = dl.JobSeekerRegistrationByEmail_Display(bl);


        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Email is alredy exixst";
            }
            else
            {
                bl.Email = txtEmailId.Text;
                ds = dl.EmployerRegistrationByEmail_Display(bl);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Email is alredy exixst";
                    }
                    else
                    {
                        if (txtMobileNumber.Text.Length == 10)
                        {
                            if (txtPinCode.Text.Length == 6)
                            {
                                
                                bl.IndustryType_ID = Convert.ToInt32(DDLIndustryType.SelectedValue);
                                bl.Name = txtName.Text;
                                bl.Email = txtEmailId.Text;
                                bl.Password = Base64Encription(txtPassword.Text);
                                bl.CompanyName = txtCompanyName.Text;
                                bl.ContactPersonName = txtContactPersonasName.Text;
                                bl.Address = txtOfficeAddress.Text;
                                bl.City = txtCity.Text;
                                bl.State = txtState.Text;
                                bl.Country = txtCountry.Text;
                                bl.Pincode = txtPinCode.Text;
                                bl.MobileNumber = txtMobileNumber.Text;
                                bl.OwanerName = txtOwanerName.Text;
                                bl.StartDate = Convert.ToDateTime(txtDate.Text);
                                bl.Employer_IsActive = 1;
                                try
                                {
                                    int i = dl.EmployerRegistration_InsertData(bl);
                                    if (i > 0)
                                    {
                                        Response.Redirect("Login.aspx");
                                    }
                                    else
                                    {
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                        lblMsg.Text = "Registration has not been successfully";
                                    }
                                }
                                catch
                                {
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                    lblMsg.Text = "Input is not valid";
                                }
                            }
                            else
                            {
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                lblMsg.Text = "Pincode number must be 6 digit";
                            }
                        }
                        else
                        {
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Text = "Contact number must be 10 digit";
                        }
                    }
                }
            }
        }


        else
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}