using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employer_ContactDetail : System.Web.UI.Page
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
            DataTable dt = dl.EmployerContactDetail_EmployerID_Display(bl).Tables[0];
            GVContactInfo.DataSource = dt;
            GVContactInfo.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtContactNumber.Text.Length == 10)
        {
            if (btnSave.Text == "Save")
            {
                try
                {
                    bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
                    bl.ContactPersonName = txtContactPersonName.Text;
                    bl.ContactNumber = txtContactNumber.Text;
                    int i = dl.EmployerContactDetail_InsertData(bl);
                    if (i > 0)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Successfully saved";
                        txtContactPersonName.Text = txtContactNumber.Text = "";
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
                    bl.Contact_ID = Convert.ToInt32(Session["Contact_ID"].ToString());
                    bl.ContactPersonName = txtContactPersonName.Text;
                    bl.ContactNumber = txtContactNumber.Text;
                    int i = dl.EmployerContactDetail_UpdateData(bl);
                    if (i > 0)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Successfully updated";
                        txtContactPersonName.Text = txtContactNumber.Text = "";
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
        else
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Conatct number must be 10 digit";
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtContactPersonName.Text = txtContactNumber.Text = "";
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnE = (Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;
            Session["Contact_ID"] = GVContactInfo.DataKeys[gr.RowIndex].Values["Contact_ID"];
            txtContactPersonName.Text = GVContactInfo.DataKeys[gr.RowIndex].Values["ContactPersonName"].ToString();
            txtContactNumber.Text = GVContactInfo.DataKeys[gr.RowIndex].Values["ContactNumber"].ToString();
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
        try{
        Button btnE = (Button)sender;
        GridViewRow gr = (GridViewRow)btnE.NamingContainer;
        bl.Contact_ID = Convert.ToInt32(GVContactInfo.DataKeys[gr.RowIndex].Values["Contact_ID"].ToString());
        int i=dl.EmployerContactDetail_DeleteData(bl);
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
}