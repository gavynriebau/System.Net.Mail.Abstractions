using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public X509CertificateCollection ClientCertificates
        {
            get
            {
                return _smtpClient.ClientCertificates;
            }
        }

        public ICredentialsByHost Credentials
        {
            get
            {
                return _smtpClient.Credentials;
            }
            set
            {
                _smtpClient.Credentials = value;
            }
        }

        public SmtpDeliveryFormat DeliveryFormat
        {
            get
            {
                return _smtpClient.DeliveryFormat;
            }
            set
            {
                _smtpClient.DeliveryFormat = value;
            }
        }

        public SmtpDeliveryMethod DeliveryMethod
        {
            get
            {
                return _smtpClient.DeliveryMethod;
            }
            set
            {
                _smtpClient.DeliveryMethod = value;
            }
        }

        public bool EnableSsl
        {
            get
            {
                return _smtpClient.EnableSsl;
            }
            set
            {
                _smtpClient.EnableSsl = value;
            }
        }

        public string Host
        {
            get
            {
                return _smtpClient.Host;
            }
            set
            {
                _smtpClient.Host = value;
            }
        }

        public string PickupDirectoryLocation
        {
            get
            {
                return _smtpClient.PickupDirectoryLocation;
            }
            set
            {
                _smtpClient.PickupDirectoryLocation = value;
            }
        }

        public int Port
        {
            get
            {
                return _smtpClient.Port;
            }
            set
            {
                _smtpClient.Port = value;
            }
        }

        public ServicePoint ServicePoint
        {
            get
            {
                return _smtpClient.ServicePoint;
            }
        }

        public string TargetName
        {
            get
            {
                return _smtpClient.TargetName;
            }
            set
            {
                _smtpClient.TargetName = value;
            }
        }

        public int Timeout
        {
            get
            {
                return _smtpClient.Timeout;
            }
            set
            {
                _smtpClient.Timeout = value;
            }
        }

        public bool UseDefaultCredentials
        {
            get
            {
                return _smtpClient.UseDefaultCredentials;
            }
            set
            {
                _smtpClient.UseDefaultCredentials = value;
            }
        }

        public event SendCompletedEventHandler SendCompleted
        {
            add
            {
                _smtpClient.SendCompleted += value;
            }
            remove
            {
                _smtpClient.SendCompleted -= value;
            }
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
