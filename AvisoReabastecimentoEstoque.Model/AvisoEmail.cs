using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using AvisoReabastecimentoEstoque.Model.Repositories;

namespace AvisoReabastecimentoEstoque.Model
{
    public class AvisoEmail
    {
        public void EnviarEmail()
        {
            List<vw_PendenteAviso> listaAvisos;
            Repository_Produto repository_Produto = new Repository_Produto();
            listaAvisos = repository_Produto.ListaPendencias();
            repository_Produto.Dispose();

            Repository_EmailAuto repository_EmailAuto = new Repository_EmailAuto();
            List<EmailAuto> listaEmail = repository_EmailAuto.SelecionarTodos();
            repository_EmailAuto.Dispose();

            Repository_AvisoReabastecimento repository_AvisoReabastecimento = new Repository_AvisoReabastecimento();

            MailMessage objEmail = new MailMessage();
            objEmail.From = new MailAddress("dev.mail.teste2@gmail.com");
            //objEmail.ReplyTo = "";            
            
            foreach(EmailAuto item in listaEmail)
            {
                MailAddress email = new MailAddress(item.Email, item.Nome);
                objEmail.To.Add(email);
            }

            MailAddress emailOculto = new MailAddress("dev.mail.teste2@gmail.com");
            
            objEmail.Bcc.Add(emailOculto);
            objEmail.Priority = MailPriority.Normal;
            objEmail.IsBodyHtml = true;
            objEmail.Subject = $"Lista de reabastecimentos de estoque {DateTime.Now}";

            StringBuilder mensagemEmail = new StringBuilder();

            mensagemEmail.AppendLine("<h1>Aviso de Reabastecimento de estoque por nível</h1><br>");

            foreach(var item in listaAvisos)
            {
                mensagemEmail.AppendLine($"<p>O produto <b> {item.ProCodigo} - {item.ProdNome} </b> contém a quantidade de {item.ProQtdEstoque} unidades em estoque e está configurado aviso quando atingir a quantidade de {item.ProQtdAvisa}.</p>");
            }

            objEmail.Body = mensagemEmail.ToString();
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            SmtpClient objSmtp = new SmtpClient();
            objSmtp.Host = "smtp.gmail.com";
            objSmtp.EnableSsl = true;
            objSmtp.Port = 587;
            objSmtp.Credentials = new NetworkCredential("dev.mail.teste2@gmail.com", "Open123!");
            objSmtp.Send(objEmail);

            foreach(var item in listaAvisos)
            {
                AvisoReabastecimento avisoReabastecimento = new AvisoReabastecimento();
                avisoReabastecimento.AvCodigoProduto = item.ProCodigo;
                avisoReabastecimento.AvData = DateTime.Now;
                avisoReabastecimento.AvHistorico = false;
                repository_AvisoReabastecimento.Incluir(avisoReabastecimento);
            }
            repository_AvisoReabastecimento.Dispose();
        }
    }
}
