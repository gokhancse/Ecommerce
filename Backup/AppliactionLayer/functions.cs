
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace AppliactionLayer
{
    public class functions
    {
        public void sendMail(string baslik, string icerik, string mail)
        {
            MailMessage mm = new MailMessage("mail adrees", mail);
            mm.IsBodyHtml = true;
            mm.Body = icerik;
            mm.Subject = baslik;

            SmtpClient sm = new SmtpClient("smtp.gmail.com");
            sm.Port = 587;
            NetworkCredential nc = 
            new NetworkCredential("mail adresi", "sifre");
            sm.UseDefaultCredentials = false;
            sm.Credentials = nc;

            sm.Send(mm);
        }


    }
}