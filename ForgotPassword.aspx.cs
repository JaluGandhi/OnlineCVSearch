using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string Base64Decription(string cyphertext)
    {
        var encodedbyetes = Convert.FromBase64String(cyphertext);
        string plaintext = Encoding.UTF8.GetString(encodedbyetes);
        return plaintext;
    }

    protected void btnRecover_Click(object sender, EventArgs e)
    {
        try
        {
            bl.Email = txtEmail.Text;
            DataSet ds = dl.EmployerRegistrationByEmail_Display(bl);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        string password = Base64Decription(ds.Tables[0].Rows[0]["Password"].ToString());
                        new clsMail().mailSend(txtEmail.Text, "CV_Search-Forgot password", "Your password is " + password);
                        labMsg.ForeColor = System.Drawing.Color.Green;
                        labMsg.Text = "Your password is send to your mail";
                    }
                    catch
                    {
                        labMsg.ForeColor = System.Drawing.Color.Red;
                        labMsg.Text = "Technical error";
                    }
                }
                else
                {
                    bl.Email = txtEmail.Text;
                    ds = dl.JobSeekerRegistrationByEmail_Display(bl);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                string password = Base64Decription(ds.Tables[0].Rows[0]["Password"].ToString());
                                new clsMail().mailSend(txtEmail.Text, "CV_Search-Forgot password", "Your password is " + password);
                                labMsg.ForeColor = System.Drawing.Color.Green;
                                labMsg.Text = "Your password is send to your mail";
                            }
                            catch
                            {
                                labMsg.ForeColor = System.Drawing.Color.Red;
                                labMsg.Text = "Technical error";
                            }
                        }
                        else
                        {
                            labMsg.ForeColor = System.Drawing.Color.Red;
                            labMsg.Text = " Email is incorrect";
                        }
                    }
                    else
                    {
                        labMsg.ForeColor = System.Drawing.Color.Red;
                        labMsg.Text = " Technical Error";
                    }
                }
            }
            else
            {
                labMsg.ForeColor = System.Drawing.Color.Red;
                labMsg.Text = " Technical Error";
            }
        }
        catch
        {
            labMsg.ForeColor = System.Drawing.Color.Red;
            labMsg.Text = "Technical error";
        }
    }
    
}