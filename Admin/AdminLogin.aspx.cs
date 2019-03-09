using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminLogin : System.Web.UI.Page
{
    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            bl.AdministratorEmail = txtUsername.Text;
            bl.AdministratorPassword = txtPassword.Text;
           DataSet ds=dl.Administrator__Email_Password_Display(bl);
           if (ds != null)
           {
               if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
               {
                   Session["Administrator_Id"] = ds.Tables[0].Rows[0]["Administrator_Id"].ToString() ;
                   Response.Redirect("JobSeekerDetail.aspx", false);
               }
               else { lblMsg.Text = "Email or Password are incorrect"; }
           }
           
        }
        catch
        {
            lblMsg.Text = "Technical error";
        }
    }
}