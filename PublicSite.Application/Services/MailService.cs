using Microsoft.Extensions.Options;
using PublicSite.Application.Interfaces;
using PublicSite.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PublicSite.Application.Services
{
    public class SmtpSetting
    {
        public string? Server { get; set; }
        public int Port { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Sender { get; set; }
        public string? DisplayName { get; set; }
    }
    public class MailService : IMailService
    {
        private readonly SmtpSetting _smtpSetting;
        private readonly SmtpClient _smtpClient;
        public MailService(IOptions<SmtpSetting> smtpSettings)
        {
            _smtpSetting = smtpSettings.Value;
            _smtpClient = new SmtpClient(_smtpSetting.Server, _smtpSetting.Port)
            {
                Credentials = new NetworkCredential(_smtpSetting.User, _smtpSetting.Password),
                EnableSsl = true
            };
        }
        public async Task SendMailAsync(string toEmail, Contact contact)
        {
            try
            {
                var sender = _smtpSetting.Sender ?? _smtpSetting.User;

                string body = mailBody
                    .Replace("{{lastname}}", contact.Lastname ?? "")
                    .Replace("{{firstname}}", contact.Firstname)
                    .Replace("{{email}}", contact.Email)
                    .Replace("{{phone}}", contact.Phone)
                    .Replace("{{club}}", contact.ClubName ?? "")
                    .Replace("{{organisation}}", contact.OrganisationName ?? "")
                    .Replace("{{subject}}", contact.MailSubject ?? "")
                    .Replace("{{message}}", contact.MailBody ?? "");

                using var mail = new MailMessage
                {
                    From = new MailAddress(sender!, _smtpSetting.DisplayName),
                    Subject = contact.MailSubject,
                    Body = body,
                    IsBodyHtml = true
                };

                mail.To.Add(toEmail);

                await _smtpClient.SendMailAsync(mail);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private string mailBody = @"
<!-- EMAIL BODY - DARK PRO TEMPLATE -->
<!DOCTYPE html>
<html lang=""fr"">
    <head><meta charset=""UTF-8""></head>
    <body style=""margin:0; padding:0; background-color:#0f172a; font-family:Arial, Helvetica, sans-serif;"">

    <table width=""100%"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""background-color:#0f172a; padding:40px 0;"">
        <tr>
        <td align=""center"">

            <!-- CONTAINER -->
            <table width=""600"" cellpadding=""0"" cellspacing=""0"" border=""0"" style=""background-color:#111827; border-radius:12px; overflow:hidden; box-shadow:0 10px 30px rgba(0,0,0,0.5);"">

            <!-- HEADER -->
            <tr>
                <td style=""background:linear-gradient(135deg,#1e293b,#020617); padding:30px; text-align:center;"">
                <h1 style=""margin:0; color:#38bdf8; font-size:26px; letter-spacing:1px;"">
                    Nouveau message reçu
                </h1>
                <p style=""margin:5px 0 0; color:#94a3b8; font-size:13px;"">
                    Un visiteur a envoyé un message depuis le formulaire de contact du site
                </p>
                </td>
            </tr>

            <!-- HERO -->
            <tr>
                <td style=""padding:30px;"">
                <h2 style=""margin:0 0 10px; color:#e2e8f0; font-size:22px;"">
                    {{subject}}
                </h2>
                <p style=""margin:0; color:#94a3b8; line-height:1.6; font-size:14px;"">
                    {{message}} 
                </p>
                </td>
            </tr>

            <!-- INFO BLOCK -->
            <tr>
                <td style=""padding:0 30px 20px;"">
                <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#020617; border-radius:8px;"">
                    <tr>
                    <td style=""padding:20px;"">
                        <p style=""margin:0 0 10px; color:#38bdf8; font-size:14px; font-weight:bold;"">
                        Informations sur l'expéditeur
                        </p>

                        <p style=""margin:5px 0; color:#cbd5f5; font-size:13px;"">
                        • Nom et prénom(s) : {{firstname}} {{lastname}}
                        </p>
                        <p style=""margin:5px 0; color:#cbd5f5; font-size:13px;"">
                        • Email : {{email}}
                        </p>
                        <p style=""margin:5px 0; color:#cbd5f5; font-size:13px;"">
                        • Téléphone : {{phone}}
                        </p>
                        <p style=""margin:5px 0; color:#cbd5f5; font-size:13px;"">
                        • Club/Organisation : {{organisation}} - {{club}}
                        </p>
                    </td>
                    </tr>
                </table>
                </td>
            </tr>
            <!-- FOOTER -->
            <tr>
                <td style=""background-color:#020617; padding:25px; text-align:center;"">
                <p style=""margin:0; color:#64748b; font-size:12px;"">
                    © 2026 Allforone Madagascar — Tous droits réservés
                </p>

                <p style=""margin:5px 0 0; color:#475569; font-size:11px;"">
                    Cet email est généré automatiquement. Merci de ne pas répondre directement.
                </p>
                </td>
            </tr>

            </table>
            <!-- END CONTAINER -->

        </td>
        </tr>
    </table>
    </body>
</html>


";
    }
}
 