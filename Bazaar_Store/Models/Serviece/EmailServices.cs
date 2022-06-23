using Bazaar_Store.Models.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar_Store.Models.Serviece
{
    public class EmailServices :IEmail
    {
        public string CartCookie { get; set; }

        public async Task SendMail(string email, List<Product> products)
        {
            SendGridClient client = new SendGridClient("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");
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("henno_hamdan@yahoo.com", "Cashier");
            msg.AddTo(email);
            msg.SetSubject("Amount required on the invoice");
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine(string.Format("Name: {0}\n", product.Name));
                sb.AppendLine(string.Format("Price: {0}\n", product.Price));
                sb.AppendLine(string.Format("BarCode: {0}\n", product.BarCode));
                sb.AppendLine(string.Format("--------------------"));

            }
            string body = sb.ToString();
            msg.AddContent(MimeType.Html, $"Thank you for shopping \n {body}");


            SendGridMessage msgSales = new SendGridMessage();
            msgSales.SetFrom("henno_hamdan@yahoo.com", "Cashier");
            msgSales.AddTo("hennoadam@gmail.com");
            msgSales.SetSubject("Sales Recite");
            msgSales.AddContent(MimeType.Html, $"Customer Recite \n {body}");

            SendGridMessage msgWarehouse = new SendGridMessage();
            msgWarehouse.SetFrom("henno_hamdan@yahoo.com", "Cashier");
            msgWarehouse.AddTo("22029713@student.ltuc.com");
            msgWarehouse.SetSubject("WareHouse Recite");
            msgWarehouse.AddContent(MimeType.Html, $"Customer Order \n {body}");


            await client.SendEmailAsync(msg);
            await client.SendEmailAsync(msgSales);
            await client.SendEmailAsync(msgWarehouse);

        }

    }
}
