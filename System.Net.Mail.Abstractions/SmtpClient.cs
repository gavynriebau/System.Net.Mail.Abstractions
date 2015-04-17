using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Mail.Abstractions
{
    /// <summary>
    /// Very simple implementation of ISmtpClient that forwards implementation logic to <see cref="System.Net.Mail.SmtpClient"/>
    /// </summary>
    public class SmtpClient : ISmtpClient
    {
        private System.Net.Mail.SmtpClient _smtpClient;

        public SmtpClient() : this(new Mail.SmtpClient())
        {
        }

        public SmtpClient(Mail.SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public void Send(MailMessage message)
        {
            _smtpClient.Send(message);
        }

        public void Send(string from, string recipients, string subject, string body)
        {
            _smtpClient.Send(from, recipients, subject, body);
        }

        public void SendAsync(MailMessage message, object userToken)
        {
            _smtpClient.SendAsync(message, userToken);
        }

        public void SendAsync(string from, string recipients, string subject, string body, object userToken)
        {
            _smtpClient.SendAsync(from, recipients, subject, body, userToken);
        }

        public void SendAsyncCancel()
        {
            _smtpClient.SendAsyncCancel();
        }

        public Task SendMailAsync(MailMessage message)
        {
            return _smtpClient.SendMailAsync(message);
        }

        public Task SendMailAsync(string from, string recipients, string subject, string body)
        {
            return _smtpClient.SendMailAsync(from, recipients, subject, body);
        }

        public void Dispose()
        {
            _smtpClient.Dispose();
        }

    }
}
