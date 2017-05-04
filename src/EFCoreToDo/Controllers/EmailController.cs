using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreToDo.Controllers
{
    public class EmailController : Controller
    {
        // GET: /<controller>/
        public IActionResult Form()
        {
            return View();
        }

        //public async Task SendEmailAsync(string email, string subject, string message)
        //{
        //    var emailMessage = new MimeMessage();

        //    emailMessage.From.Add(new MailboxAddress("Joe Bloggs", "jbloggs@example.com"));
        //    emailMessage.To.Add(new MailboxAddress("", email));
        //    emailMessage.Subject = subject;
        //    emailMessage.Body = new TextPart("plain") { Text = message };

        //    using (var client = new SmtpClient())
        //    {
        //        client.LocalDomain = "some.domain.com";
        //        await client.ConnectAsync("smtp.relay.uri", 25, SecureSocketOptions.None).ConfigureAwait(false);
        //        await client.SendAsync(emailMessage).ConfigureAwait(false);
        //        await client.DisconnectAsync(true).ConfigureAwait(false);
        //    }
        //}
    }
}
        //[HttpPost]
//        public ActionResult Form(string Email, string subject, string Message)

//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var senderemail = new MailAddress("nermine.benrebah@gmail.com", "Sender");
//                    //var senderemail = new MailAddress(senderEmail, "Sender");
//                    var receiveremail = new MailAddress(Email, "Receiver");
//                    //var receiveremail = new MailAddress("nermine.benrebah @gmail.com", "Receiver");
//                    //var receiveremail = new MailAddress(receiverEmail, "nermine.benrebah @gmail.com");

//                    var password = "lenovo2016";
//                    var sub = subject;
//                    var body = Message;

//                    var smtp = new SmtpClient
//                    {
//                        Host = "smtp.gmail.com",
//                        Port = 587,
//                        EnableSsl = true,
//                        DeliveryMethod = SmtpDeliveryMethod.Network,
//                        UseDefaultCredentials = false,
//                        Credentials = new NetworkCredential(senderemail.Address, password)
//                        // Credentials = new NetworkCredential(senderemail.Address,senderemail.DisplayName)

//                        //Credentials = new NetworkCredential(senderemail.Address, "azeety")
//                    };

//                    using (var mess = new MailMessage(senderemail, receiveremail)
//                    {
//                        Subject = subject,
//                        Body = body
//                    }
//                    )

//                    { smtp.Send(mess); }

//                    return View();

//                }
//            }
//            catch (Exception)
//            {
//                ViewBag.Error = "there are some problems in sending email";
//            }

//            return View();
//        }
//        //ViewBag.Message = "Your contact page.";

//        //return View();
//    }
//}

