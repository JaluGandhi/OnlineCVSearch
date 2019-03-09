using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            //new clsMail().mailSend(txtEmail.Text, "CV_Search-Feedback", "You've applied to this " + ds1.Tables[0].Rows[0]["CompanyName"].ToString());
            string clmsg = "From " + txtYourName.Text + System.Environment.NewLine + "Email " + System.Environment.NewLine + txtMsg.InnerText;
            new clsMail().mailSend(txtEmail.Text, "CV_Search-Feedback-No-Reply", clmsg);

            new clsMail().mailSend("jaygandhi933@gmail.com", "CV_Search-Feedback-No-Reply", clmsg);

            lblMsg.InnerText = "Your mail has been send";
        }
        catch
        {
            lblMsg.InnerText = "Technical error";
        }
        
    }
}