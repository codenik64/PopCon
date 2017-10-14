using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PopsConfectionary14.LogicLayer
{
    public class EmailLogic
    {
        public void Index(string To, string Subject, string Message)
        {
           
               
                    var SenderEmail = new MailAddress("appdevproject.nik@gmail.com", "Pops Confectionary");
                    var recieverEmail = new MailAddress(To, "Reciever");

                    var Password = $"6587558Nik*";
                    var sub = Subject;
                    var body = Message;

                    var smtp = new SmtpClient
                    {
                        Host = $"smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(SenderEmail.Address, Password)

                    };


                    using (var mess = new MailMessage(SenderEmail, recieverEmail)
                    {
                        Subject = Subject,
                        Body = body
                    }
                        )
                    {
                        smtp.Send(mess);
                    }
                   
                
            }
           
        
        
    }
}