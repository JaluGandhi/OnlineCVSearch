using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employer_Profile : System.Web.UI.Page
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
                    DropDownBind();
                    bind();
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

    public void DropDownBind()
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

    public void bind()
    {
        try
        {
            int Employer_ID = Convert.ToInt32(Session["Employer_ID"]);
            DataSet ds = new DataSet();
            bl = new BussinessLayer();
            bl.Employer_ID = Employer_ID;
            ds = dl.EmployerRegistration_EmployerID_Display(bl);
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtComapnyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    txtContactPersonName.Text = ds.Tables[0].Rows[0]["ContactPersonName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                    txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                    txtCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
                    txtPinCode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                    txtMobileNumber.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtOwanerName.Text = ds.Tables[0].Rows[0]["OwanerName"].ToString();
                    txtDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]).ToString("yyyy-MM-dd");
                    DDLIndustryType.SelectedValue = ds.Tables[0].Rows[0]["IndustryType_ID"].ToString();
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
            lblMsg.Text = "Technincal Error";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtMobileNumber.Text.Length == 10)
        {
            if (txtPinCode.Text.Length == 6)
            {
                try
                {
                    bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
                    bl.IndustryType_ID = Convert.ToInt32(DDLIndustryType.SelectedValue);
                    bl.Name = txtName.Text;
                    bl.CompanyName = txtComapnyName.Text;
                    bl.ContactPersonName = txtContactPersonName.Text;
                    bl.Address = txtAddress.Text;
                    bl.City = txtCity.Text;
                    bl.State = txtState.Text;
                    bl.Country = txtCountry.Text;
                    bl.Pincode = txtPinCode.Text;
                    bl.MobileNumber = txtMobileNumber.Text;
                    bl.OwanerName = txtOwanerName.Text;
                    bl.StartDate = Convert.ToDateTime(txtDate.Text);
                    int i = dl.EmployerRegistration_UpdateData(bl);
                    if (i > 0)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Suucessfully saved";
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
                    lblMsg.Text = "Technincal Error";
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Pincode must be 6 digit";
            }
        }
        else
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Contact  number must be 10 digit";
        }
    }
}