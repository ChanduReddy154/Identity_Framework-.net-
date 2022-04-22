using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Communication.SMS
{
    public interface ISendSMSNotification
    {
        Task<string> SendSMS(string Mobile, string Message);
    }
}
