﻿using BookManager.Domain.Services;
using MimeKit;
using System.Net.Mail;
using MimeKit.Text;
using System.Net;
using Microsoft.Extensions.Configuration;


namespace BookManager.Application.ServicesEmails
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public Task SendEmailService(string subject, string message, string userEmail, string userName)
        {
            // Configure as credenciais do servidor SMTP
            var smtpServer = _config.GetValue<string>("SmtpSettings:Server"); //"smtp.gmail.com"; // Substitua pelo seu servidor SMTP
            var smtpPort = 587; // Substitua pela porta do seu servidor SMTP
            var smtpUsername = _config.GetValue<string>("SmtpSettings:User");//"f.santosdev1992@gmail.com"; // Substitua pelo seu email
            var smtpPassword = _config.GetValue<string>("SmtpSettings:Pass");//"ruzm otfz iwde ddej"; // Substitua pela sua senha


            // Crie um novo email
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(smtpUsername));
            mimeMessage.To.Add(MailboxAddress.Parse(userEmail));
            mimeMessage.Subject = subject;

            // Crie o corpo do email
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message; // Use HtmlBody para obter o corpo em HTML
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            // Converta o MimeMessage para MailMessage
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mimeMessage.From.ToString());
            mailMessage.To.Add(new MailAddress(mimeMessage.To.ToString()));
            mailMessage.Subject = mimeMessage.Subject;
            mailMessage.Body = mimeMessage.HtmlBody; // Use HtmlBody para definir o corpo do email

            // Envie o email
            var client = new SmtpClient(smtpServer, smtpPort);
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            client.EnableSsl = true; // Ative o SSL para o Gmail
            client.Send(mailMessage);

            return Task.CompletedTask;
        }
    }
}
