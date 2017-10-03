using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Web.Hosting;

namespace DemoTest.Utilities
{
    public class Common
    {
        public static void SendEmail(string fromAddress, string toAddress, string attachmentFilePath, string subject, string userName)
        {
            string SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
            string SMTPUserName = ConfigurationManager.AppSettings["FromEmailAddress"];
            string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
            string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"];

            int portNo = 0;
            if (!string.IsNullOrEmpty(SMTPPort))
                portNo = Convert.ToInt32(SMTPPort);

            if (!string.IsNullOrEmpty(SMTPServer) && !string.IsNullOrEmpty(SMTPPassword) && portNo > 0 && !string.IsNullOrEmpty(subject))
            {
                MailMessage mailObj = new MailMessage();
                mailObj.From = new MailAddress(fromAddress);
                //var toAddressList = toAddress.Split(';');
                //foreach (string bccEmailId in toAddressList)
                //{
                //    mailObj.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id
                //}
                mailObj.To.Add(toAddress);
                SmtpClient smtpClient = new SmtpClient(SMTPServer, portNo);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(SMTPUserName, SMTPPassword);
                mailObj.IsBodyHtml = true;
                mailObj.Subject = subject;
                string bodytemplate = string.Empty;
                using (var sr = new StreamReader(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["EmailTemplate"])))
                {
                    bodytemplate = sr.ReadToEnd();
                }

                mailObj.Body = string.Format(bodytemplate, userName);

                try
                {
                    smtpClient.Send(mailObj);
                }
                catch (Exception ex)
                {
                    Common.LogError("SendEmail", "", "SendEmail", "EXCEPTION OCCURED", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                    throw new Exception(ex.Message);
                }
            }

        }

        public static void LogError(string Controller, string PageUrl, string Action, string ErrorMessage = null, string InnerException = null, string userCode = null, string UserIp = null)
        {

            string LOG_FILE = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory) + "Log\\" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt";
            //set up a filestream
            FileStream fs = new FileStream(LOG_FILE, FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text
            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream
            sw.BaseStream.Seek(0, SeekOrigin.End);

            //add the text
            sw.WriteLine("==================================================================\r\nDateTime" + DateTime.Now.ToString() + "\r\n Controller: " +
                Controller + "\r\n URL: " + PageUrl + "\r\n Action: " + Action + "\r\n Error Message: " + ErrorMessage + "\r\n Inner Exception: " + InnerException + "\r\n User: " + userCode + "\r\n UserIP: " + UserIp + "\r\n==================================================================");
            //add the text to the underlying filestream

            sw.Flush();
            //close the writersw.Close();

            sw.Close();
        }
    }
}