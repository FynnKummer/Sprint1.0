using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
             emailsenden("Test 2");    

            new ExcelControll();
            {
                Microsoft.Offi
            }
        }

         public static void emailsenden( string text)

        {
            
            string betreff = "Anfrage";
            string server = "mail.gmx.net";
            int port = 587;
            string user = "456263856";
            string passwort = "1Q2w3e4r5t6z7u8_";

            MailMessage Mail = new MailMessage();

            //Absender
            Mail.From = new MailAddress("hsp.anfragen@gmx.net");

            //Empfänger 
            Mail.To.Add("jonathan.rietig@aol.de");

            // Betreff

            Mail.Subject = betreff;

            Mail.Body = text;

          

            // Abseneserver 
            SmtpClient mailClient = new SmtpClient(server);
            
            mailClient.UseDefaultCredentials = false;
            mailClient.EnableSsl = true;
            mailClient.Port = port;
            mailClient.Credentials = new System.Net.NetworkCredential(user, passwort);
            
            mailClient.Send(Mail);

            Console.WriteLine("Fertig");
            Console.ReadKey();

        }

    }

    class ExcelControll
    {
        
    }
}
