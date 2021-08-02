using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace AvisoReabastecimentoEstoque.Model
{
    public class AvisoEmail
    {
        public void EnviarEmail()
        {
            MailMessage objEmail = new MailMessage();
            objEmail.From = new MailAddress("");
            //objEmail.ReplyTo = "";
            MailAddress email = new MailAddress("bruno.almeida.developer@gmail.com");

            objEmail.To.Add(email);
            //objEmail.Bcc.Add("Cópia oculta");
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = "Assunto";
            objEmail.Body = "<p>Mensagem</p>";
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Host = "smtp.gmail.com";
            objSmtp.EnableSsl = true;
            objSmtp.Port = 587;
            objSmtp.Credentials = new NetworkCredential("dev.mail.teste2@gmail.com", "Open123!");
            objSmtp.Send(objEmail);

        }
    }
}
