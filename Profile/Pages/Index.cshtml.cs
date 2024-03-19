using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;

namespace Profile.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Subject { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            string message;
            try
            {
                
                MailMessage mail = new MailMessage();

                //set the addresses 
                mail.From = new MailAddress("contact@onwuka.com.ng"); //IMPORTANT: This must be same as your smtp authentication address.
                mail.To.Add("contact@onwuka.com.ng");

                //set the content 

                mail.Subject = "Contact from Website";

                string mess = "Name: " + Name + "(" + Phone + ")" + ", Email Address: " + Email + ", subject: " + Subject + ", Message: " + Message;
                mail.Body = mess;
                //send the message 
                SmtpClient smtp = new SmtpClient("mail.onwuka.com.ng");

                //IMPORANT:  Your smtp login email MUST be same as your FROM address. 
                NetworkCredential Credentials = new NetworkCredential("contact@onwuka.com.ng", "Nation@123");
                smtp.Credentials = Credentials;
                smtp.Send(mail);
                TempData["mssg"] = message = "Mail Sent Successfull. We will get back to you soon";
            }
            catch (Exception ex)
            {

                TempData["mssg"] = message = "Mail not Sent. Try Again.";
            }
            return RedirectToPage();




        }

    }
}
