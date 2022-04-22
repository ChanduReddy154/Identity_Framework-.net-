using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrmsWeb_API.EmailSend
{
   public  interface IMailService
    {

        Task SendEmailAsync(MailRequest mailRequest);
    }
}
