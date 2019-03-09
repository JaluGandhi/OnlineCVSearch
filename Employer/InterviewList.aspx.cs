using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employer_InterviewList : System.Web.UI.Page
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
                    GVInterviewInfoNotCame.Visible = false;
                    GVInterviewInfoRejected.Visible = false;
                    GVInterviewInfoSelected.Visible = false;
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
    public void bind()
    {
        try
        {
            GVInterviewInfoPending.Visible = true;
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            DataTable dt = dl.InterviewProcess_InterviewPendingList_Display(bl).Tables[0];
            GVInterviewInfoPending.DataSource = dt;
            GVInterviewInfoPending.DataBind();
        }
        catch { lblMsg.ForeColor = System.Drawing.Color.Red;
        lblMsg.Text = "Technical error";
        }
    }
    protected void LinkBtnPending_Click(object sender, EventArgs e)
    {
        try
        {

            bind();
            GVInterviewInfoNotCame.Visible = false;
            GVInterviewInfoRejected.Visible = false;
            GVInterviewInfoSelected.Visible = false;
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }

    protected void LinkBtnSelected_Click(object sender, EventArgs e)
    {
        try
        {
            GVInterviewInfoSelected.Visible = true;
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            DataTable dt = dl.InterviewProcess_InterviewSelectedList_Display(bl).Tables[0];
            GVInterviewInfoSelected.DataSource = dt;
            GVInterviewInfoSelected.DataBind();
            GVInterviewInfoRejected.Visible = false;
            GVInterviewInfoPending.Visible = false;
            GVInterviewInfoNotCame.Visible = false;
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void LinkBtnReject_Click(object sender, EventArgs e)
    {
        try
        {
            GVInterviewInfoRejected.Visible = true;
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            DataTable dt = dl.InterviewProcess_InterviewRejectedList_Display(bl).Tables[0];
            GVInterviewInfoRejected.DataSource = dt;
            GVInterviewInfoRejected.DataBind();
            GVInterviewInfoSelected.Visible = false;
            GVInterviewInfoPending.Visible = false;
            GVInterviewInfoNotCame.Visible = false;
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void LinkBtnNotCame_Click(object sender, EventArgs e)
    {
        try
        {
            GVInterviewInfoNotCame.Visible = true;
            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            DataTable dt = dl.InterviewProcess_InterviewNotCameList_Display(bl).Tables[0];
            GVInterviewInfoNotCame.DataSource = dt;
            GVInterviewInfoNotCame.DataBind();
            GVInterviewInfoPending.Visible = false;
            GVInterviewInfoRejected.Visible = false;
            GVInterviewInfoSelected.Visible = false;
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
}