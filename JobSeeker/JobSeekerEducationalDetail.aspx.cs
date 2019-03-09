using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobSeeker_JobSeekerEducationalDetail : System.Web.UI.Page
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
                    dataBind();
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
            }
            else { Response.Redirect("~/Login.aspx", false); }
        }
        catch
        {
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
    
    public void dataBind()
    {
        try
        {
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            DataTable dt = dl.JobSeekerEducationalBy_JobSeekerId_Display(bl).Tables[0];
            GVEducationalInfo.DataSource = dt;
            GVEducationalInfo.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                if (txtPercentage.Text.Length == 2)
                {
                    bl.Board = txtBoard.Text;
                    bl.Result = txtResult.SelectedItem.Text;
                    bl.University = txtUniversity.Text;
                    bl.Percentage = Convert.ToDouble(txtPercentage.Text);
                    bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
                    int i = dl.JobSeekerEducational_InsertData(bl);
                    if (i > 0)
                    {
                        txtBoard.Text = txtResult.Text = txtUniversity.Text = txtPercentage.Text = "";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Successfully save";
                        dataBind();
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
                        lblMsg.Text = "Fail to save";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                    }
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Percentage must be only 2 digit"; 
                }
            }
            catch
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Technical error";
            }
        }
        else {
            try
            {
                if (txtPercentage.Text.Length == 2)
                {
                    bl.Board = txtBoard.Text;
                    bl.Result = txtResult.SelectedItem.Text;
                    bl.University = txtUniversity.Text;
                    bl.Percentage = Convert.ToDouble(txtPercentage.Text);
                    bl.Educational_ID = Convert.ToInt32(ViewState["Educational_ID"]);
                    int i = dl.JobSeekerEducational_UpdateData(bl);
                    if (i > 0)
                    {
                        txtBoard.Text = txtResult.Text = txtUniversity.Text = txtPercentage.Text = "";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Successfully Updated";
                        dataBind();
                        btnSave.Text = "Save";
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Failed to Update";
                    }
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Percentage must be only 2 digit";
                }
            }
            
            catch
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Technical error";
            }
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnE = (Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;
            ViewState["Educational_ID"] = GVEducationalInfo.DataKeys[gr.RowIndex].Values["Educational_ID"];
            txtBoard.Text = GVEducationalInfo.DataKeys[gr.RowIndex].Values["Board"].ToString();
            txtPercentage.Text = GVEducationalInfo.DataKeys[gr.RowIndex].Values["Percentage"].ToString();
            txtResult.SelectedValue = GVEducationalInfo.DataKeys[gr.RowIndex].Values["Result"].ToString();
            txtUniversity.Text = GVEducationalInfo.DataKeys[gr.RowIndex].Values["University"].ToString();
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
        try
        {
            Button btnE = (Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;
            //Session["Educational_ID"] = GVEducationalInfo.DataKeys[gr.RowIndex].Values["Educational_ID"];
            bl.Educational_ID = Convert.ToInt32(GVEducationalInfo.DataKeys[gr.RowIndex].Values["Educational_ID"].ToString());
            int i = dl.JobSeekerEducational_DeleteData(bl);
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Successfully Deleted";
                dataBind();
            }
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtBoard.Text = txtPercentage.Text = txtUniversity.Text = "";
            txtResult.SelectedIndex = 0;
            btnSave.Text = "Save";
            lblMsg.Text = "";
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}