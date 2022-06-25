using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Bazaar_Store.Pages.Carts
{
    public class EmailSendModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public bool Mode { get; set; }
        public async Task OnGet()
        {
            Name = HttpContext.Request.Cookies["username"];
            SendGridClient client = new SendGridClient("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");
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("22029784@student.ltuc.com", "Bazzar Store");
            msg.AddTo("alaaalhanene@gmail.com");
            msg.SetSubject(" This is sent from Bazaar Store ");
            msg.AddContent(MimeType.Html, "Hello This is your recipt");
            Response a = await client.SendEmailAsync(msg);

        }

        public void OnPost()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("username", Name, cookieOptions);
            HttpContext.Response.Cookies.Append("Mode", Mode.ToString(), cookieOptions);
        }
    }
}
