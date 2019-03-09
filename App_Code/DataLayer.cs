using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer
{
    BussinessLayer bl;
    SqlCommand cmd;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    SqlConnection con;
    SqlDataAdapter sda;

    public DataLayer()
    {
        con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\INFO_STO\Project\CV_Search\App_Data\CV_Search_DB.mdf;Integrated Security=True");
    }


    public int Administrator_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into Administrator values(@Name,@Email,@Password,@JoinDate,@IsActive)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Name", bl.AdministratorName);
            cmd.Parameters.AddWithValue("@Email", bl.AdministratorEmail);
            cmd.Parameters.AddWithValue("@Password", bl.AdministratorPassword);
            cmd.Parameters.AddWithValue("@JoinDate", bl.AdministratorJoinDate);
            cmd.Parameters.AddWithValue("@IsActive", bl.AdministratorIsActive);
            con.Close();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int Administrator_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update Administrator set Name=@Name,Email=@Email,Password=@Password,JoinDate=@JoinDate,IsActive=@IsActive";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Name", bl.AdministratorName);
            cmd.Parameters.AddWithValue("@Email", bl.AdministratorEmail);
            cmd.Parameters.AddWithValue("@Password", bl.AdministratorPassword);
            cmd.Parameters.AddWithValue("@JoinDate", bl.AdministratorJoinDate);
            cmd.Parameters.AddWithValue("@IsActive", bl.AdministratorIsActive);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet Administrator_Display()
    {
        try
        {
            string s = "select * from Administrator";
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Administrator_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select * from Administrator where Administrator_Id";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Administrator_Id", bl.Administrator_Id);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Administrator__Email_Password_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select Administrator_Id,Email,Password from Administrator where Email='"+bl.AdministratorEmail+"' and Password='"+bl.AdministratorPassword+"'";
            cmd = new SqlCommand(s, con);
           
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Administrator_JobSeekerBasic_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select *,FirstName+' '+MiddleName+' '+LastName as Name from JobSeeker";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public int Administrator_JobSeeker_IsActive_Update(BussinessLayer  bl)
    {
        int i=0;
        try
        {
            string s = "update JobSeeker set IsActive=@IsActive where JobSeeker_ID=@JobSeeker_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@IsActive", bl.JobSeeker_IsActive);
            cmd.Parameters.AddWithValue("@JobSeeker_ID", bl.JobSeeker_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch{}
        con.Close();
        return i;
    }
    public DataSet Administrator_EmplyerBasic_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select Employer.Employer_ID,Employer.OwanerName,Employer.CompanyName,Employer.MobileNumber,Employer.Email,IndustryType.IndustryName from Employer" +
                " inner join IndustryType on IndustryType.IndustryType_ID=Employer.IndustryType_ID "+
                "where Employer.IndustryType_ID= "+bl.IndustryType_ID;
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Administrator_EmployerFullDTL_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select Employer.Employer_ID,Employer.OwanerName,Employer.CompanyName,Employer.MobileNumber,"+
                "convert(nvarchar(max),Employer.StartDate,103) as StartDate1," +
                "Employer.Email,Employer.City+'-'+Employer.State+'-'+Employer.Country as Address,Employer.Pincode,"+
                "IndustryType.IndustryName from Employer " +
                " inner join IndustryType on IndustryType.IndustryType_ID=Employer.IndustryType_ID "+
                "where Employer.Employer_ID="+bl.Employer_ID;
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Administrator_EmployerFullDTL_ContactDTL_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select EmployerContactDetail.ContactPersonName,EmployerContactDetail.ContactNumber"+
                " from EmployerContactDetail "+
                " where Employer_ID="+bl.Employer_ID;
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public int Administrator_Employer_IsActive_Update(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update Employer set IsActive=@IsActive where Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@IsActive", bl.Employer_IsActive);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }

    public int IndustryType_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into  IndustryType values(@IndustryName)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@IndustryName", bl.IndustryName);

            con.Open();
            i = cmd.ExecuteNonQuery();


        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet IndustryType_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select * from IndustryType";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);

        }
        catch { }
        return ds;
    }
    public int IndustryType_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update IndustryType set IndustryName=@IndustryName where IndustryType_ID=@IndustryType_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@IndustryName", bl.IndustryName);
            cmd.Parameters.AddWithValue("@IndustryType_ID", bl.IndustryType_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch
        {

        }
        con.Close();
        return i;
    }
    public int IndustryType_DeleteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from IndustryType where IndustryType_ID=@IndustryType_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@IndustryType_ID", bl.IndustryType_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }



    public int EmployerRegistration_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into Employer values(@Name,@Email, @Password,@CompanyName,@IndustryType_ID,@ContactPersonName,@Address, @City, @State, @Country, @Pincode, @MobileNumber, @OwanerName, @StartDate,@IsActive)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Name", bl.Name);
            cmd.Parameters.AddWithValue("@Email", bl.Email);
            cmd.Parameters.AddWithValue("@Password", bl.Password);
            cmd.Parameters.AddWithValue("@CompanyName", bl.CompanyName);
            cmd.Parameters.AddWithValue("@IndustryType_ID", bl.IndustryType_ID);
            cmd.Parameters.AddWithValue("@ContactPersonName", bl.ContactPersonName);
            cmd.Parameters.AddWithValue("@Address", bl.Address);
            cmd.Parameters.AddWithValue("@City", bl.City);
            cmd.Parameters.AddWithValue("@State", bl.State);
            cmd.Parameters.AddWithValue("@Country", bl.Country);
            cmd.Parameters.AddWithValue("@Pincode", bl.Pincode);
            cmd.Parameters.AddWithValue("@MobileNumber", bl.MobileNumber);
            cmd.Parameters.AddWithValue("@OwanerName", bl.OwanerName);
            cmd.Parameters.AddWithValue("@StartDate", bl.StartDate);
            cmd.Parameters.AddWithValue("@IsActive", bl.Employer_IsActive);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int EmployerRegistration_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update Employer set Name=@Name,CompanyName=@CompanyName,IndustryType_ID=@IndustryType_ID,ContactPersonName=@ContactPersonName,Address=@Address, City=@City, State=@State, Country=@Country, Pincode=@Pincode, MobileNumber=@MobileNumber, OwanerName=@OwanerName, StartDate=@StartDate where Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Name", bl.Name);
            cmd.Parameters.AddWithValue("@CompanyName", bl.CompanyName);
            cmd.Parameters.AddWithValue("@IndustryType_ID", bl.IndustryType_ID);
            cmd.Parameters.AddWithValue("@ContactPersonName", bl.ContactPersonName);
            cmd.Parameters.AddWithValue("@Address", bl.Address);
            cmd.Parameters.AddWithValue("@City", bl.City);
            cmd.Parameters.AddWithValue("@State", bl.State);
            cmd.Parameters.AddWithValue("@Country", bl.Country);
            cmd.Parameters.AddWithValue("@Pincode", bl.Pincode);
            cmd.Parameters.AddWithValue("@MobileNumber", bl.MobileNumber);
            cmd.Parameters.AddWithValue("@OwanerName", bl.OwanerName);
            cmd.Parameters.AddWithValue("@StartDate", bl.StartDate);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int EmployerRegistration_DeletetData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from Employer where @Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet EmployerRegistration_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select * from Employer";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet EmployerRegistrationByEmailPassword_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from Employer where Email=@Email and Password=@Password and IsActive='1'";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Email", bl.Email);
            cmd.Parameters.AddWithValue("@Password", bl.Password);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet EmployerRegistrationByEmail_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from Employer where Email=@Email ";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Email", bl.Email);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet EmployerRegistration_EmployerID_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from Employer where Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public int EmployerContactDetail_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into EmployerContactDetail values(@Employer_ID,@ContactPersonName,@ContactNumber)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            cmd.Parameters.AddWithValue("@ContactPersonName", bl.ContactPersonName);
            cmd.Parameters.AddWithValue("@ContactNumber", bl.ContactNumber);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int EmployerContactDetail_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update EmployerContactDetail set ContactPersonName=@ContactPersonName,ContactNumber=@ContactNumber where Contact_ID=@Contact_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ContactPersonName", bl.ContactPersonName);
            cmd.Parameters.AddWithValue("@ContactNumber", bl.ContactNumber);
            cmd.Parameters.AddWithValue("@Contact_ID", bl.Contact_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int EmployerContactDetail_DeleteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from EmployerContactDetail where Contact_ID=@Contact_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Contact_ID", bl.Contact_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet EmployerContactDetail_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select * from EmployerContactDetail";
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet EmployerContactDetail_ContactID_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select * from EmployerContactDetail where Contact_ID=@Contact_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Contact_ID", bl.Contact_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet EmployerContactDetail_EmployerID_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select * from EmployerContactDetail where Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }




    public int JobSeekerRegistration_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into JobSeeker values(@FirstName,@MiddleName,@LastName,@MobileNumber,@Email,@Password,@Address,@Pincode,@IsActive)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@FirstName", bl.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", bl.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", bl.LastName);
            cmd.Parameters.AddWithValue("@MobileNumber", bl.MobileNumber);
            cmd.Parameters.AddWithValue("@Email", bl.Email);
            cmd.Parameters.AddWithValue("@Password", bl.Password);
            cmd.Parameters.AddWithValue("@Address", bl.Address);
            cmd.Parameters.AddWithValue("@Pincode", bl.Pincode);
            cmd.Parameters.AddWithValue("@IsActive", bl.JobSeeker_IsActive);
            con.Open();
            i = cmd.ExecuteNonQuery();

        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerRegistration_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update JobSeeker set FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,MobileNumber=@MobileNumber,Address=@Address, Pincode=@Pincode where JobSeeker_ID=@JobSeeker_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@FirstName", bl.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", bl.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", bl.LastName);
            cmd.Parameters.AddWithValue("@MobileNumber", bl.MobileNumber);
            cmd.Parameters.AddWithValue("@Address", bl.Address);
            cmd.Parameters.AddWithValue("@Pincode", bl.Pincode);
            cmd.Parameters.AddWithValue("@JobSeeker_ID", bl.JobSeeker_ID);
            //cmd.Parameters.AddWithValue("@",);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerRegistration_DeletetData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from JobSeeker where @JobSeeker_ID=@JobSeeker_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_ID", bl.JobSeeker_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet JobSeekerRegistration_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeeker";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }

    public DataSet JobSeekerRegistrationByEmailPassword_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeeker where Email=@Email and Password=@Password and IsActive='1'";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Email", bl.Email);
            cmd.Parameters.AddWithValue("@Password", bl.Password);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);

        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerRegistrationByEmail_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeeker where Email=@Email";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Email", bl.Email);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerRegistrationBy_JobSeekerID_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeeker where JobSeeker_ID=@JobSeeker_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_ID", bl.JobSeeker_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }






    public int JobSeekerEducational_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into JobSeekerEducational values(@JobSeeker_id,@Board,@University,@Result,@Percentage)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Board", bl.Board);
            cmd.Parameters.AddWithValue("@University", bl.University);
            cmd.Parameters.AddWithValue("@Result", bl.Result);
            cmd.Parameters.AddWithValue("@Percentage", bl.Percentage);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerEducational_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update JobSeekerEducational set Board=@Board, University=@University, Result=@Result, Percentage=@Percentage where Educational_ID=@Educational_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Board", bl.Board);
            cmd.Parameters.AddWithValue("@University", bl.University);
            cmd.Parameters.AddWithValue("@Result", bl.Result);
            cmd.Parameters.AddWithValue("@Percentage", bl.Percentage);
            cmd.Parameters.AddWithValue("@Educational_ID", bl.Educational_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerEducational_DeleteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from JobSeekerEducational where Educational_ID=@Educational_ID";
            cmd = new SqlCommand(s, con);

            cmd.Parameters.AddWithValue("@Educational_ID", bl.Educational_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet JobSeekerEducationalBy_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerEducational";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerEducationalBy_JobSeekerId_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerEducational where JobSeeker_id=@JobSeeker_id";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerEducationalBy_EducationalID_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerEducational where Educational_ID=@Educational_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Educational_ID", bl.Educational_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }





    public int JobSeekerExperienceDetail_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into JobSeekerExperienceDetail values(@JobSeeker_id,@CompanyName,@StartDate,@EndDate,@NumberOfYear,@IsContinue)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@CompanyName", bl.CompanyName);
            cmd.Parameters.AddWithValue("@StartDate", bl.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", bl.EndDate);
            cmd.Parameters.AddWithValue("@NumberOfYear", bl.NumberOfYear);
            cmd.Parameters.AddWithValue("@IsContinue", bl.IsContinue);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerExperienceDetail_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update JobSeekerExperienceDetail set CompanyName=@CompanyName,StartDate=@StartDate,EndDate=@EndDate,NumberOfYear=@NumberOfYear,IsContinue=@IsContinue where Experience_ID=@Experience_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@CompanyName", bl.CompanyName);
            cmd.Parameters.AddWithValue("@StartDate", bl.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", bl.EndDate);
            cmd.Parameters.AddWithValue("@NumberOfYear", bl.NumberOfYear);
            cmd.Parameters.AddWithValue("@IsContinue", bl.IsContinue);
            cmd.Parameters.AddWithValue("@Experience_ID", bl.Experience_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerExperienceDetail_DeleteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from JobSeekerExperienceDetail where Experience_ID=@Experience_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Experience_ID", bl.Experience_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet JobSeekerExperienceDetail_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerExperienceDetail ";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerExperienceDetail_ByJobSeekerId_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select *,convert(nvarchar(max),StartDate,103) as StartDate1,convert(nvarchar(max),EndDate,103) as EndDate1,iif(IsContinue='True','Yes','No') as ISContinue1 from JobSeekerExperienceDetail where JobSeeker_id=@JobSeeker_id";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerExperienceDetail_ByExperienceID_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerExperienceDetail where Experience_ID=@Experience_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Experience_ID", bl.Experience_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }




    public int JobSeekerHobbyDetail_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into JobSeekerHobbyDetail values(@JobSeeker_id,@HobbyName)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@HobbyName", bl.HobbyName);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerHobbyDetail_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update JobSeekerHobbyDetail set HobbyName=@HobbyName where Hobby_ID=@Hobby_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@HobbyName", bl.HobbyName);
            cmd.Parameters.AddWithValue("@Hobby_ID", bl.Hobby_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerHobbyDetail_DeleteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from JobSeekerHobbyDetail where Hobby_ID=@Hobby_ID";
            cmd = new SqlCommand(s, con);

            cmd.Parameters.AddWithValue("@Hobby_ID", bl.Hobby_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet JobSeekerHobbyDetailBy_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerHobbyDetail";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerHobbyDetailBy_JobSeekerId_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerHobbyDetail where JobSeeker_id=@JobSeeker_id";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerHobbyDetailBy_HobbyID_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerHobbyDetail where Hobby_ID=@Hobby_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Hobby_ID", bl.Hobby_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }




    public int JobSeekerPersonalDetail_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into JobSeekerPersonalDetail values(@JobSeeker_id,@City,@State,@Country,@Gender,@DateOfBirth,@MariatailStatus,@Passport,@ResumeFile)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@City", bl.City);
            cmd.Parameters.AddWithValue("State", bl.State);
            cmd.Parameters.AddWithValue("Country", bl.Country);
            cmd.Parameters.AddWithValue("Gender", bl.Gender);
            cmd.Parameters.AddWithValue("DateOfBirth", bl.DateOfBirth);
            cmd.Parameters.AddWithValue("MariatailStatus", bl.MariatailStatus);
            cmd.Parameters.AddWithValue("Passport", bl.Passport);
            cmd.Parameters.AddWithValue("ResumeFile", bl.ResumeFile);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerPersonalDetail_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update JobSeekerPersonalDetail set City=@City,State=@State,Country=@Country,Gender=@Gender,DateOfBirth=@DateOfBirth,MariatailStatus=@MariatailStatus,Passport=@Passport,ResumeFile=@ResumeFile where Personal_ID=@Personal_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@City", bl.City);
            cmd.Parameters.AddWithValue("@State", bl.State);
            cmd.Parameters.AddWithValue("@Country", bl.Country);
            cmd.Parameters.AddWithValue("@Gender", bl.Gender);
            cmd.Parameters.AddWithValue("@DateOfBirth", bl.DateOfBirth);
            cmd.Parameters.AddWithValue("@MariatailStatus", bl.MariatailStatus);
            cmd.Parameters.AddWithValue("@Passport", bl.Passport);
            cmd.Parameters.AddWithValue("@ResumeFile", bl.ResumeFile);
            cmd.Parameters.AddWithValue("@Personal_ID", bl.Personal_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerPersonalDetail_ResumeFile_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update JobSeekerPersonalDetail set ResumeFile=@ResumeFile where JobSeeker_ID=@JobSeeker_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@ResumeFile",bl.ResumeFile);
            cmd.Parameters.AddWithValue("@JobSeeker_ID",bl.JobSeeker_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerPersonalDetail_DeleteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from JobSeekerPersonalDetail where Personal_ID=@Personal_ID";
            cmd = new SqlCommand(s, con);

            cmd.Parameters.AddWithValue("@Personal_ID", bl.Personal_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet JobSeekerPersonalDetailBy_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerPersonalDetail ";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerPersonalDetailBy_JobSeekerId_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select *,convert(nvarchar(max),DateOfBirth,103) as DateOfBirth1 from JobSeekerPersonalDetail where JobSeeker_id=@JobSeeker_id";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerPersonalDetailBy_PersonalID_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerPersonalDetail where Personal_ID=@Personal_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Personal_ID", bl.Personal_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }




    public int JobSeekerSkillDetail_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into JobSeekerSkillDetail values(@JobSeeker_id,@SkillName,@Discription)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@SkillName", bl.SkillName);
            cmd.Parameters.AddWithValue("Discription", bl.Discription);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerSkillDetail_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update JobSeekerSkillDetail set SkillName=@SkillName,Discription=@Discription where Skill_ID=@Skill_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@SkillName", bl.SkillName);
            cmd.Parameters.AddWithValue("@Discription", bl.Discription);
            cmd.Parameters.AddWithValue("@Skill_ID", bl.Skill_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int JobSeekerSkillDetail_DeleteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from JobSeekerSkillDetail where Skill_ID=@Skill_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Skill_ID", bl.Skill_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet JobSeekerSkillDetailBy_Display()
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerSkillDetail";
            cmd = new SqlCommand(s, con);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerSkillDetailBy_JobSeekerId_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerSkillDetail where JobSeeker_id=@JobSeeker_id";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_id", bl.JobSeeker_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet JobSeekerPersonalDetailBy_SkillID_Display(BussinessLayer bl)
    {
        ds = new DataSet();
        try
        {
            string s = "select * from JobSeekerSkillDetail where Skill_ID=@Skill_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Skill_ID", bl.Skill_ID);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }

    public int Vacancy_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into Vacancy values(@Employer_ID,@Experience,@StartDate,@EndDate,@Skill,@NumberOfPost,@IsClose)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("Employer_ID", bl.Employer_ID);
            cmd.Parameters.AddWithValue("Experience", bl.Experience);
            cmd.Parameters.AddWithValue("StartDate", bl.StartDate);
            cmd.Parameters.AddWithValue("EndDate", bl.EndDate);
            cmd.Parameters.AddWithValue("Skill", bl.SkillName);
            cmd.Parameters.AddWithValue("NumberOfPost", bl.NumberOfPost);
            cmd.Parameters.AddWithValue("IsClose", bl.IsClose);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int Vacancy_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update Vacancy set Experience=@Experience,StartDate=@StartDate,EndDate=@EndDate,Skill=@Skill,NumberOfPost=@NumberOfPost,IsClose=@IsClose where Vacancy_ID=@Vacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Experience", bl.Experience);
            cmd.Parameters.AddWithValue("@StartDate", bl.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", bl.EndDate);
            cmd.Parameters.AddWithValue("@Skill", bl.SkillName);
            cmd.Parameters.AddWithValue("@NumberOfPost", bl.NumberOfPost);
            cmd.Parameters.AddWithValue("@IsClose", bl.IsClose);
            cmd.Parameters.AddWithValue("@Vacancy_ID", bl.Vacancy_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int Vacancy_DeleteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from Vacancy where Vacancy_ID=@Vacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Vacancy_ID", bl.Vacancy_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch
        {
        }
        con.Close();
        return i;
    }
    public DataSet Vacancy_Display()
    {
        try
        {

            string s = "select Vacancy.Vacancy_ID,Vacancy.Experience,convert(nvarchar(max),Vacancy.StartDate,103) as StartDate,convert(nvarchar(max),Vacancy.EndDate,103) as EndDate,Vacancy.Skill,Vacancy.NumberOfPost,iif(Vacancy.IsClose = 'True','Yes','NO') as IsClose,Employer.CompanyName" +
                " from Vacancy inner join Employer on Vacancy.Employer_Id=Employer.Employer_Id" +
                " where Vacancy.IsClose='False' and  getdate() between Vacancy.StartDate and Vacancy.EndDate";
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Vacancy_SearchByJobSeeker_Display(BussinessLayer bl,string Skill="")
    {
        try
        {
            string s = "select Vacancy.Vacancy_ID,Vacancy.Experience,convert(nvarchar(max),Vacancy.StartDate,103) as StartDate,convert(nvarchar(max),Vacancy.EndDate,103) as EndDate,Vacancy.Skill,Vacancy.NumberOfPost,iif(Vacancy.IsClose = 'True','Yes','NO') as IsClose,Employer.CompanyName" +
                " from Vacancy inner join Employer on Vacancy.Employer_Id=Employer.Employer_Id" +
                " where Vacancy.IsClose='False' and  getdate() between Vacancy.StartDate and Vacancy.EndDate and " +
                " "+Skill;
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Vacancy_SearchByEmployer_UsingDataBase_Display(BussinessLayer bl, string Skill = "")
    {
        try
        {
            string s = "select JobSeeker.JobSeeker_ID,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,JobSeeker.MobileNumber,JobSeeker.Email,JobSeekerSkillDetail.SkillName" +
               " from JObSeeker " +
               " inner join JobSeekerSkillDetail on JobSeeker.JobSeeker_ID=JobSeekerSkillDetail.JobSeeker_ID" +
               " where " +
               " " + Skill;
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Vacancy_SearchByEmployer_NotExist_Display(BussinessLayer bl, string jid = "")
    {
        try
        {
            string s = "select JobSeeker.JobSeeker_ID" +
               " from JobSeeker" +
               " where JobSeeker_ID not in " + jid;
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Vacancy_SearchByEmployer_RetriveResumeFileNotExist_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select ResumeFile from JobSeekerPersonalDetail where JobSeeker_ID = " + bl.JobSeeker_ID;
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }

    public DataSet Vacancy_SearchByEmployer_UsingJobSeeker_ID_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select JobSeeker.JobSeeker_ID,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,JobSeeker.MobileNumber,JobSeeker.Email,'' as SkillName" +
               " from JObSeeker " +
               " where JobSeeker.JobSeeker_ID=" + bl.JobSeeker_ID;
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }

    public DataSet Vacancy_VacancyID_Disaplay(BussinessLayer bl)
    {
        try
        {
            string s = "select * from Vacancy where Vacancy_ID=@Vacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Vacancy_ID", bl.Vacancy_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet Vacancy_EmployerID_Disaplay(BussinessLayer bl)
    {
        try
        {
            string s = "select *,convert(nvarchar(max),StartDate,103) as StartDate1,convert(nvarchar(max),EndDate,103) as EndDate1,iif(IsClose = 'True','Yes','NO') as IsClose1  from Vacancy where Employer_Id=@Employer_Id";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_Id", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }

    public int AppliedVacancy_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into AppliedVacancy values(@Vacancy_ID,@JobSeeker_ID,@AppliedDate,@Status)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Vacancy_ID", bl.Vacancy_ID);
            cmd.Parameters.AddWithValue("@JobSeeker_ID", bl.JobSeeker_ID);
            cmd.Parameters.AddWithValue("@AppliedDate", bl.AppliedDate);
            cmd.Parameters.AddWithValue("@Status", bl.AppliedVancayStatus);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;

    }
    public int AppliedVacancy_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update AppliedVacancy set AppliedDate=@AppliedDate,Status=@Status where AppliedVacancy_ID=@AppliedVacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@AppliedDate", bl.AppliedDate);
            cmd.Parameters.AddWithValue("@Status", bl.AppliedVancayStatus);
            cmd.Parameters.AddWithValue("@AppliedVacancy_ID", bl.AppliedVacancy_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch
        { }
        con.Close();
        return i;
    }
    public int AppliedVacancy_StatusChance_Employer(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update AppliedVacancy set Status=@Status where AppliedVacancy_ID=@AppliedVacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Status", bl.AppliedVancayStatus);
            cmd.Parameters.AddWithValue("@AppliedVacancy_ID", bl.AppliedVacancy_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch
        { }
        con.Close();
        return i;
    }
    public DataSet AppliedVacancy_Display()
    {
        try
        {

            string s = "select * from AppliedVacancy";
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_AppliedVacancy_ID_Disaplay(BussinessLayer bl)
    {
        try
        {
            string s = "select * from AppliedVacancy where AppliedVacancy_ID=@AppliedVacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@AppliedVacancy_ID", bl.AppliedVacancy_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_Vacancy_ID_Disaplay(BussinessLayer bl)
    {
        try
        {
            string s = "select * from AppliedVacancy where Vacancy_ID=@Vacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Vacancy_ID", bl.Vacancy_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_JobSeeker_ID_Disaplay(BussinessLayer bl)
    {
        try
        {
            string s = "select * from AppliedVacancy where JobSeeker_ID=@JobSeeker_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_ID", bl.JobSeeker_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_JobSeeker_ID_Vacancy_ID_Disaplay(BussinessLayer bl)
    {
        try
        {
            string s = "select * from AppliedVacancy  where JobSeeker_ID=@JobSeeker_ID and Vacancy_ID=@Vacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_ID", bl.JobSeeker_ID);
            cmd.Parameters.AddWithValue("@Vacancy_ID", bl.Vacancy_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_Employer_Disaplay()
    {

        try
        {
            string s = "select AppliedVacancy.AppliedVacancy_ID,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,JobSeeker.MobileNumber,JobSeeker.Email,convert(nvarchar(max),AppliedVacancy.AppliedDate,103) as AppliedDate,AppliedVacancy.Status from AppliedVacancy inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID  ";
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_Approval_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select Vacancy.Vacancy_ID,JobSeeker.JobSeeker_ID,AppliedVacancy.AppliedVacancy_ID,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,JobSeeker.MobileNumber,JobSeeker.Email,convert(nvarchar(max),AppliedVacancy.AppliedDate,103) as AppliedDate,AppliedVacancy.Status" +
                " from AppliedVacancy inner join Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID" +
                " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
                " where  AppliedVacancy.Status=1 and Vacancy.Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_Reject_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select AppliedVacancy.AppliedVacancy_ID,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,JobSeeker.MobileNumber,JobSeeker.Email,convert(nvarchar(max),AppliedVacancy.AppliedDate,103) as AppliedDate,AppliedVacancy.Status" +
                " from AppliedVacancy inner join Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID" +
                " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
                " where  AppliedVacancy.Status=2 and Vacancy.Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_Pending_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select AppliedVacancy.AppliedVacancy_ID,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,JobSeeker.MobileNumber,JobSeeker.Email,convert(nvarchar(max),AppliedVacancy.AppliedDate,103) as AppliedDate,AppliedVacancy.Status" +
                " from AppliedVacancy inner join Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID" +
                " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
                " where  AppliedVacancy.Status=0 and Vacancy.Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet AppliedVacancy_EmailSend_Details(BussinessLayer bl)
    {
        try
        {
            string s = "select JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,JobSeeker.Email as JobSeekerEmail,(select CompanyName from Employer where Employer_ID=Vacancy.Employer_Id)as CompanyName,(select Email from Employer where Employer_ID=Vacancy.Employer_Id)as Email " +
                " from AppliedVacancy" +
                " inner join Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID" +
                " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
                " where AppliedVacancy.Vacancy_ID=@Vacancy_ID and" +
                " AppliedVacancy.JobSeeker_ID=@JobSeeker_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@JobSeeker_ID", bl.JobSeeker_ID);
            cmd.Parameters.AddWithValue("@Vacancy_ID", bl.Vacancy_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }



    public int InterviewProcess_InsertData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "insert into InterviewProcess values(@AppliedVacancy_ID,@InterviewTime,@InterviewDate,@ContactPersonName,@Location,@Status,@IsDone)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@AppliedVacancy_ID", bl.AppliedVacancy_ID);
            cmd.Parameters.AddWithValue("@InterviewTime", bl.InterviewTime);
            cmd.Parameters.AddWithValue("@InterviewDate", bl.InterviewDate);
            cmd.Parameters.AddWithValue("@ContactPersonName", bl.ContactPersonName);
            cmd.Parameters.AddWithValue("@Location", bl.Location);
            cmd.Parameters.AddWithValue("@Status", bl.InterviewStatus);
            cmd.Parameters.AddWithValue("@IsDone", bl.IsDone);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int InterviewProcess_UpdateData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "update InterviewProcess set InterviewTime=@InterviewTime,InterviewDate=@InterviewDate,ContactPersonName=@ContactPersonName,Location=@Location,Status=@Status,IsDone=@IsDone where InterviewProcess_ID=@InterviewProcess_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@InterviewTime", bl.InterviewTime);
            cmd.Parameters.AddWithValue("@InterviewDate", bl.InterviewDate);
            cmd.Parameters.AddWithValue("@ContactPersonName", bl.ContactPersonName);
            cmd.Parameters.AddWithValue("@Location", bl.Location);
            cmd.Parameters.AddWithValue("@Status", bl.InterviewStatus);
            cmd.Parameters.AddWithValue("@IsDone", bl.IsDone);
            cmd.Parameters.AddWithValue("@InterviewProcess_ID", bl.InterviewProcess_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public int InterviewProcess_DelteData(BussinessLayer bl)
    {
        int i = 0;
        try
        {
            string s = "delete from InterviewProcess where InterviewProcess_ID=@InterviewProcess_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@InterviewProcess_ID", bl.InterviewProcess_ID);
            con.Open();
            i = cmd.ExecuteNonQuery();
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet InterviewProcess_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select * from InterviewProcess";
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet InterviewProcess_InterviewProcess_ID_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select * from InterviewProcess where InterviewProcess_ID=@InterviewProcess_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@InterviewProcess_ID", bl.InterviewProcess_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;

    }
    public DataSet InterviewProcess_AppliedVacancy_ID_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select * from InterviewProcess where AppliedVacancy_ID=@AppliedVacancy_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@AppliedVacancy_ID", bl.AppliedVacancy_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;

    }
    public DataSet InterviewProcess_AllDetails_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select JobSeeker.FirstName +' '+ JobSeeker.MiddleName +' '+ JobSeeker.LastName as Name,JobSeeker.MobileNumber,JobSeeker.Email,JobSeeker.Address,Vacancy.Skill,Vacancy.StartDate,Vacancy.EndDate,Vacancy.NumberOfPost,Vacancy.Experience " +
                "from AppliedVacancy" +
                " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
                " inner join  Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID where JobSeeker.JobSeeker_ID="+bl.JobSeeker_ID+
                " and Vacancy.Vacancy_ID="+bl.Vacancy_ID;
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch
        {
        }
        return ds;
    }
    public DataSet InterviewProcess_InterviewPendingList_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select convert(nvarchar(max),InterviewProcess.InterviewDate,103) as InterviewDate,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,Vacancy.Skill from InterviewProcess " +
                " inner join AppliedVacancy on InterviewProcess.AppliedVacancy_ID=AppliedVacancy.AppliedVacancy_ID" +
            " inner join Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID" +
            " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
            " where InterviewProcess.Status=0 and Vacancy.Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet InterviewProcess_InterviewSelectedList_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select convert(nvarchar(max),InterviewProcess.InterviewDate,103) as InterviewDate,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,Vacancy.Skill from InterviewProcess " +
                " inner join AppliedVacancy on InterviewProcess.AppliedVacancy_ID=AppliedVacancy.AppliedVacancy_ID" +
            " inner join Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID" +
            " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
            " where InterviewProcess.Status=1 and Vacancy.Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet InterviewProcess_InterviewRejectedList_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select convert(nvarchar(max),InterviewProcess.InterviewDate,103) as InterviewDate,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,Vacancy.Skill from InterviewProcess " +
                " inner join AppliedVacancy on InterviewProcess.AppliedVacancy_ID=AppliedVacancy.AppliedVacancy_ID" +
            " inner join Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID" +
            " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
            " where InterviewProcess.Status=2 and Vacancy.Employer_ID=@Employer_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet InterviewProcess_InterviewNotCameList_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select convert(nvarchar(max),InterviewProcess.InterviewDate,103) as InterviewDate,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,Vacancy.Skill from InterviewProcess " +
                " inner join AppliedVacancy on InterviewProcess.AppliedVacancy_ID=AppliedVacancy.AppliedVacancy_ID" +
            " inner join Vacancy on AppliedVacancy.Vacancy_ID=Vacancy.Vacancy_ID" +
            " inner join JobSeeker on AppliedVacancy.JobSeeker_ID=JobSeeker.JobSeeker_ID" +
            " where InterviewProcess.Status=3 and Vacancy.Employer_ID=@Employer_ID ";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Employer_ID", bl.Employer_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }


    public int SearchResume_InsertData(BussinessLayer bl)
    {
        int i=0;
        try {
            string q = "insert into SearchResume values(@Employer_ID,@JobSeeker_ID,@SearchDate,@SearchSkill,@Status)";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@Employer_ID",bl.Employer_ID);
            cmd.Parameters.AddWithValue("@JobSeeker_ID",bl.JobSeeker_ID);
            cmd.Parameters.AddWithValue("@SearchDate",bl.SearchDate);
            cmd.Parameters.AddWithValue("@SearchSkill",bl.SearchSkill);
            cmd.Parameters.AddWithValue("@Status",bl.SearchStatus);
            con.Open();
            i=cmd.ExecuteNonQuery();
        
        }
        catch { }
        con.Close();
        return i;
    }
    public DataSet SearchResume_Search_ID_Display(BussinessLayer bl)
    {
        try
        {
            string s = "select * from SearchResume where Search_ID=@Search_ID";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Search_ID", bl.Search_ID);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }
    public DataSet SearchResume_SearchedResume_Display(BussinessLayer bl)
    {
        try
        {

            string s = "select JobSeeker.JobSeeker_ID,JobSeeker.FirstName+' '+JobSeeker.MiddleName+' '+JobSeeker.LastName as Name,JobSeeker.MobileNumber,JobSeeker.Email,convert(nvarchar(max),SearchResume.SearchDate,103) as SearchDate,SearchResume.SearchSkill" +
               " from JObSeeker " +
               " inner join SearchResume on JobSeeker.JobSeeker_ID=SearchResume.JobSeeker_ID "+
               "where Employer_ID="+bl.Employer_ID;
            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }


    public DataSet JobSeekerFullDetail_Profile_Display(BussinessLayer bl)
    {

        try
        {

            string s = "select FirstName+' '+MiddleName+' '+LastName as Name,MobileNumber,Email,Address,Pincode" +
               " from JObSeeker where JobSeeker_ID="+bl.JobSeeker_ID ;

            cmd = new SqlCommand(s, con);
            sda = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sda.Fill(ds);
        }
        catch { }
        return ds;
    }


}