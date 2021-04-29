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
        static void Main(string[] args)
        {
            
        }

        public void EmailSenden(string text)

        {
            string betreff = "Anfrage";
            string server = "";
            int port = 25;
            string user = "max.Musterman";
            string passwort = "123";

            MailMessage Mail = new MailMessage();

            //Absender
            Mail.From = new MailAddress(//Sender);

            //Empfänger 
            Mail.To.Add(//Empfänger);

            // Betreff

            Mail.Subject = (betreff);

            Mail.Body = text;

            // Abseneserver 
            SmtpClient mailClient = new SmtpClient(server,port);

            mailClient.Credentials = new System.Net.NetworkCredential(user,passwort);

            mailClient.Send(Mail);


        }   

    }
}
