using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{

    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string Base64Encription(string plaintext)
    {
        var plaintextbyetes = Encoding.UTF8.GetBytes(plaintext);
        string encodedtext = Convert.ToBase64String(plaintextbyetes);
        return encodedtext;
    }



    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            bl.Email = txtEmail.Text;

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
                    bl.Email = txtEmail.Text;
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
                            if (txtContactNumber.Text.Length == 10)
                            {
                                if (txtPincode.Text.Length == 6)
                                {
                                    if (txtpassword.Text == ConfirmPassword.Text)
                                    {
                                        bl.Email = txtEmail.Text;
                                        bl.Password = Base64Encription(txtpassword.Text);
                                        bl.Address = txtAddress.Text;
                                        bl.Pincode = txtPincode.Text;
                                        bl.MobileNumber = txtContactNumber.Text;
                                        bl.FirstName = txtFirstName.Text;
                                        bl.LastName = txtLastName.Text;
                                        bl.MiddleName = txtMiddleName.Text;
                                        bl.JobSeeker_IsActive = 1;
                                        try
                                        {
                                            int i = dl.JobSeekerRegistration_InsertData(bl);
                                            if (i > 0)
                                            {
                                                Response.Redirect("Login.aspx");
                                            }
                                            else
                                            {
                                                lblMsg.Text = "Registration has not been successfully";
                                            }
                                        }
                                        catch
                                        {
                                            lblMsg.Text = "Input is not valid";
                                        }
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Password does not mathched";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "Pincode number mustbe 6 digit";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                lblMsg.Text = "Contact number must be only 10 digit";

                            }
                        }
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
}
    


    



    
