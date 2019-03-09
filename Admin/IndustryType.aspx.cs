using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Admin_IndustryType : System.Web.UI.Page
{
    BussinessLayer bl = new BussinessLayer();
    DataLayer dl = new DataLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Administrator_Id"] != null)
            {
                if (!IsPostBack)
                {
                    display();
                }
            }
            else { Response.Redirect("AdminLogin.aspx", false); }
        }
        catch { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            //if (txtIndustryName.Text != "")
            //{
                bl.IndustryName = txtIndustryName.Text;
                int i = dl.IndustryType_InsertData(bl);
                if (i > 0)
                {
                    lblMsg.Text = "Saved Successfully";
                    display();
                    txtIndustryName.Text = "";
                }
                else if (btnSave.Text == "Update")
                {
                    lblMsg.Text = "Failed to save";
                    display();
                }
            //}
            //else {
            //    lblMsg.Text = "Please fill all details";
            //}
        }
        else
        {
            bl.IndustryName = txtIndustryName.Text;
            bl.IndustryType_ID = Convert.ToInt32(ViewState["IndustryType_ID"]);
            int i = dl.IndustryType_UpdateData(bl);
            if (i > 0)
            {
                lblMsg.Text = "Updated Successfully";
                display();
                txtIndustryName.Text = "";
                btnSave.Text = "Save";
            }
            else
            {
                lblMsg.Text = "Failed to update";
                display();
            }
        }
    }
    public void display()
    {
        DataTable dt = dl.IndustryType_Display().Tables[0];
        GVIndustryInfo.DataSource = dt;
        GVIndustryInfo.DataBind();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtIndustryName.Text = "";
        btnSave.Text = "Save";
    }
    protected void GVIndustryInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btnE = (Button)sender;
        GridViewRow gr = (GridViewRow)btnE.NamingContainer;

        ViewState["IndustryType_ID"] = GVIndustryInfo.DataKeys[gr.RowIndex].Values["IndustryType_ID"];
        txtIndustryName.Text = GVIndustryInfo.DataKeys[gr.RowIndex].Values["IndustryName"].ToString();


        btnSave.Text = "Update";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button btnE = (Button)sender;
        GridViewRow gr = (GridViewRow)btnE.NamingContainer;
        ViewState["IndustryType_ID"] = GVIndustryInfo.DataKeys[gr.RowIndex].Values["IndustryType_ID"];
        bl.IndustryType_ID = Convert.ToInt32(ViewState["IndustryType_ID"]);
        dl.IndustryType_DeleteData(bl);
        display();
    }
}