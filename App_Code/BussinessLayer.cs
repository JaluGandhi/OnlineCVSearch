using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BussinessLayer
/// </summary>
public class BussinessLayer
{
    public int IndustryType_ID { get; set; }
    public string IndustryName { get; set; }

    public int Employer_ID { get; set; }
    public int Employer_IsActive { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password{ get; set; }
    public string CompanyName{ get; set; }
    public string ContactPersonName{ get; set; }
    public string Address{ get; set; }
    public string City{ get; set; }
    public string State{ get; set; }
    public string Country{ get; set; }
    public string Pincode{ get; set; }
    public string MobileNumber{ get; set; }
    public string OwanerName { get; set; }
    public DateTime StartDate { get; set; }

    

    public int JobSeeker_ID { get; set; }
    public int JobSeeker_IsActive { get; set; }
    public string FirstName{ get; set; }
    public string MiddleName{ get; set; }
    public string LastName{ get; set; }
    //public string { get; set; }

    public int Educational_ID{ get; set; }
    public string Board{ get; set; }
    public string University{ get; set; }
    public string Result{ get; set; }
    public double Percentage{ get; set; }

    public int Experience_ID{ get; set; }
    public DateTime EndDate{ get; set; }
    public int NumberOfYear{ get; set; }
    public int IsContinue{ get; set; }

    public int Hobby_ID{ get; set; }
    public string HobbyName{ get; set; }

    public int Personal_ID{ get; set; }
    public string Gender{ get; set; }
     public DateTime DateOfBirth{ get; set; }
    public string MariatailStatus{ get; set; }
     public string Passport{ get; set; }
    public string ResumeFile{ get; set; }

     public int Skill_ID{ get; set; }
    public string SkillName{ get; set; }
    public string Discription { get; set; }
	

    public int Vacancy_ID{ get; set; }
    public int Experience{ get; set; }
    public int NumberOfPost { get; set; }
    public int IsClose { get; set; }

    public int Contact_ID { get; set; }
    public string ContactNumber { get; set; }

    public int AppliedVacancy_ID { get; set; }
    public DateTime AppliedDate { get; set; }
    public int AppliedVancayStatus { get; set; }


    public int InterviewProcess_ID { get; set; }
    public string InterviewTime { get; set; }
    public DateTime InterviewDate { get; set; }
    public string Location { get; set; }
    public int InterviewStatus { get; set; }
    public int IsDone { get; set; }


    public int Administrator_Id { get; set; }
    public string AdministratorName { get; set; }
    public string  AdministratorEmail { get; set; }
    public string AdministratorPassword { get; set; }
    public DateTime AdministratorJoinDate { get; set; }
    public int AdministratorIsActive { get; set; }


    public int Search_ID { get; set; }
    public DateTime SearchDate { get; set; }
    public string SearchSkill { get; set; }
    public int SearchStatus { get; set; }
    public BussinessLayer()
	{
		//
		// TODO: Add constructor logic here
		//
	}

}