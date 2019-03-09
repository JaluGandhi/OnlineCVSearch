using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
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


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            bl.Email = txtEmail.Text;
            bl.Password = Base64Encription(txtPassword.Text);
            DataSet ds = dl.JobSeekerRegistrationByEmailPassword_Display(bl);

            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Session["JobSeeker_ID"] = ds.Tables[0].Rows[0]["JobSeeker_ID"];
                    Response.Redirect("JobSeeker/JobSeekerProfile.aspx", false);
                }
                else 
                {
                    bl.Email = txtEmail.Text;
                    bl.Password = Base64Encription(txtPassword.Text);
                    ds = dl.EmployerRegistrationByEmailPassword_Display(bl);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            Session["Employer_ID"] = ds.Tables[0].Rows[0]["Employer_ID"];
                            Response.Redirect("Employer/Home.aspx", false);
                        }
                        else
                        {
                            lblMsg.Text = "Email or Password are incorrect";
                        }
                    }
                }

            }
        }
        catch { lblMsg.Text = "Technical error"; }
        

    }
}