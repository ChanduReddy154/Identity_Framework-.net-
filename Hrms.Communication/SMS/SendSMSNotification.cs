using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HRMS.Communication.SMS
{
    public class SendSMSNotification : ISendSMSNotification
    {
        public Task<string> SendSMS(string Mobile, string Message)
        {
            String message = HttpUtility.UrlEncode("Dear customer, OTP for your request on Salestrek is " + Message + " and do not share this OTP to anyone for security reasons.");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "NTg2NDU3Nzk2NjMwNGI1NjY1NzQ2ZjY2NTM2NDcyNjM="},
                {"numbers" , Mobile},
                {"message" , message},
                {"sender" , "saltrk"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return Task.FromResult(result);
                //return result;
            }



            //var client = new WebClient();
            //var result =  client.DownloadString(string.Format("http://onlinebulksmslogin.com/spanelv2/api.php?username=mretail&password=mretail@1234&to={0}&from=MRETAL&message={1}", Mobile, Message));
            //return Task.FromResult(result);
        }

        public static Dictionary<String, Object> parse(byte[] json)
        {
            string jsonStr = Encoding.UTF8.GetString(json);
            return JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonStr);
        }
    }
}
