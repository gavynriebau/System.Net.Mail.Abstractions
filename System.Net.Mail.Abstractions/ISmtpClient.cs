using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Mail.Abstractions
{
    /// <summary>
    /// Abstraction around <see cref="System.Net.Mail.SmtpClient"/> that enables mocking email sending.
    /// </summary>
    public interface ISmtpClient : IDisposable
    {
        void Send(MailMessage message);
        void Send(string from, string recipients, string subject, string body);
        void SendAsync(MailMessage message, object userToken);
        void SendAsync(string from, string recipients, string subject, string body, object userToken);
        void SendAsyncCancel();
        Task SendMailAsync(MailMessage message);
        Task SendMailAsync(string from, string recipients, string subject, string body);
    }
}
