using Microsoft.Office.Interop.Word;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Employer_Home : System.Web.UI.Page
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
    public void bind()
    {
        try
        {
            System.Data.DataTable dt = dl.Vacancy_Display().Tables[0];
            GVVacancyInfo.DataSource = dt;
            GVVacancyInfo.DataBind();
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }
    protected void btnSkillSearch_Click(object sender, EventArgs e)
    {
        try
        {

            string SkillName = "";
            string[] Sk = txtSkillSearch.Text.Split(',');
            int fl = 0;
            foreach (string s in Sk)
            {
                if (fl == 0)
                {
                    SkillName = "(JobSeekerSkillDetail.SkillName like '%" + s.Trim() + "%' ";
                    fl = 1;
                }
                else
                {
                    SkillName += " or JobSeekerSkillDetail.SkillName like '%" + s.Trim() + "%' ";
                }
            }
            SkillName += ")";
            System.Data.DataTable dt = dl.Vacancy_SearchByEmployer_UsingDataBase_Display(bl, SkillName).Tables[0];
           
            string jid = "(0";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jid += "," + dt.Rows[i]["JobSeeker_ID"];
            }
            jid += ")";
            DataSet ds = dl.Vacancy_SearchByEmployer_NotExist_Display(bl, jid);            

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                bl.JobSeeker_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["JobSeeker_ID"].ToString());
                DataSet ds1 = dl.Vacancy_SearchByEmployer_RetriveResumeFileNotExist_Display(bl);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    string resume = ds1.Tables[0].Rows[0]["ResumeFile"].ToString();

                    string filename = Server.MapPath("~/Resume/" + resume);
                    string ext = System.IO.Path.GetExtension(filename);
                    if (ext.ToLower() == ".pdf")
                    {
                        StringBuilder strStreamValue = new StringBuilder();
                        using (PdfReader pr = new PdfReader(filename))
                        {
                            for (int pgno = 1; pgno <= pr.NumberOfPages; pgno++)
                            {
                                strStreamValue.Append(PdfTextExtractor.GetTextFromPage(pr, pgno));
                            }
                        }
                        foreach (string s in Sk)
                        {
                            if (strStreamValue.ToString().ToLower().Contains(s.ToLower()))
                            {
                                bl.JobSeeker_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["JobSeeker_ID"].ToString());
                                System.Data.DataTable dtRes = dl.Vacancy_SearchByEmployer_UsingJobSeeker_ID_Display(bl).Tables[0];
                                dt.Merge(dtRes);

                                break;
                            }
                        }
                    }
                    else if (ext.ToLower() == ".doc" || ext.ToLower() == ".docx")
                    {
                        // create word application
                        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.ApplicationClass();
                        // create object of missing value
                        object miss = System.Reflection.Missing.Value;
                        // create object of selected file path 
                        object path = filename;
                        // set file path mode 
                        object readOnly = true;
                        // open document                 
                        Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                        // select whole data from active window document
                        docs.ActiveWindow.Selection.WholeStory();
                        // handover the data to cllipboard 
                        docs.ActiveWindow.Selection.Copy();
                        // clipboard create reference of idataobject interface which transfer the data
                        // string ttt = Clipboard.GetText();
                        string ttt1 = docs.Content.Text;
                        docs.Close(ref miss, ref miss, ref miss);
                        foreach (string s in Sk)
                        {
                            if (ttt1.ToLower().Contains(s.ToLower()))
                            {
                                bl.JobSeeker_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["JobSeeker_ID"].ToString());
                                System.Data.DataTable dtRes = dl.Vacancy_SearchByEmployer_UsingJobSeeker_ID_Display(bl).Tables[0];
                                dt.Merge(dtRes);

                                break;
                            }
                        }
                    }
                }                
            }
            GVVacancyInfo.DataSource = dt;
            GVVacancyInfo.DataBind(); 
        }
        catch
        {
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Technical error";
        }
    }

    protected void btnSkillReset_Click(object sender, EventArgs e)
    {
        txtSkillSearch.Text = "";
    }


    protected void btnSelect_Click(object sender, EventArgs e)
    {
        try
        {

            

           Button btnE=(Button)sender;
            GridViewRow gr = (GridViewRow)btnE.NamingContainer;

            bl.Employer_ID = Convert.ToInt32(Session["Employer_ID"].ToString());
            bl.JobSeeker_ID = Convert.ToInt32(GVVacancyInfo.DataKeys[gr.RowIndex].Values["JobSeeker_ID"].ToString());
            bl.SearchDate = DateTime.Now;
            bl.SearchSkill = txtSkillSearch.Text;
            bl.SearchStatus = 0;
            int i = dl.SearchResume_InsertData(bl);
            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Successfully Saved";
                
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
}