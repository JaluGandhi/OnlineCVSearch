using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for clsMail
/// </summary>
public class clsMail
{
	public clsMail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void mailSend(string to, string subject, string msg)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("jaygandhi933@gmail.com");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = msg;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("jaygandhi933@gmail.com", "9033344995jalu");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        catch
        {

        }
    }
   
}