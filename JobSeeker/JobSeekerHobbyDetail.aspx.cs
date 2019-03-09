using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobSeeker_JobSeekerHobbyDeatil : System.Web.UI.Page
{
    DataLayer dl = new DataLayer();
    BussinessLayer bl = new BussinessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["JobSeeker_ID"] != null)
            {
                if (!IsPostBack)
                {
                    bind();
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
                bl.HobbyName = txtHobby.Text;
                int i = dl.JobSeekerHobbyDetail_InsertData(bl);
                if (i > 0)
                {
                    txtHobby.Text = "";
                    bind();
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Successfully Saved";
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
                    lblMsg.Text = "Failed to Save";
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
                bl.HobbyName = txtHobby.Text;
                bl.Hobby_ID = Convert.ToInt32(Session["Hobby_ID"].ToString());
                int i=dl.JobSeekerHobbyDetail_UpdateData(bl);

                if (i > 0)
                {
                    txtHobby.Text = "";
                    bind();
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Successfully Upadatd";
                    btnSave.Text = "Save";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Failed to Update";
                }
            }
            catch
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Technical error"; 
            }
        }
    }

    public void bind()
    {
        try
        {
            bl.JobSeeker_ID = Convert.ToInt32(Session["JobSeeker_ID"].ToString());
            DataTable dt = dl.JobSeekerHobbyDetailBy_JobSeekerId_Display(bl).Tables[0];
            GVHobbyInfo.DataSource = dt;
            GVHobbyInfo.DataBind();

        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnE = (Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;
            txtHobby.Text = GVHobbyInfo.DataKeys[gr.RowIndex].Values["HobbyName"].ToString();
            Session["Hobby_ID"] = GVHobbyInfo.DataKeys[gr.RowIndex].Values["Hobby_ID"];
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
            bl.Hobby_ID = Convert.ToInt32(GVHobbyInfo.DataKeys[gr.RowIndex].Values["Hobby_ID"].ToString());
            int i = dl.JobSeekerHobbyDetail_DeleteData(bl);
            if (i > 0)
            {
                bind();
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Successfully Deleted";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Failed to Delete";
            }
        }
        catch {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            txtHobby.Text = "";
        }
        catch { }
    }
}