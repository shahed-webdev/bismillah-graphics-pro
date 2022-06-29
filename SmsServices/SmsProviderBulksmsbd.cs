using Newtonsoft.Json;
using SmsServices;
using System.Net;
using System.Text;



public class SmsProviderBulksmsbd : ISmsProvider
{
    private const string HostUrl = "http://66.45.237.70/api.php";
    private const string UserId = "01712676781";
    private const string Password = "Hazrat_325";

    public int GetSmsBalance()
    {
        return 100000; // No API for get Balance. So use a fixed number for SMS availability
    }

    private static string ParseResponse(WebResponse r)
    {
        var response = (HttpWebResponse)r;

        var responseStream = response.GetResponseStream();

        if (responseStream == null) throw new Exception("Response stream found null.");

        using (var responseReader = new StreamReader(responseStream))
        {
            var responseString = responseReader.ReadToEnd();

            try
            {
                return responseString;
            }
            catch
            {
                throw new Exception(string.Format("The sms service calling was unsuccessful with code:{0}[{1}]",
                    (int)response.StatusCode, response.StatusCode));
            }
        }
    }

    public string SendSms(string massage, string number)
    {
        var request = HttpWebRequest.Create(HostUrl);
        var smsText = Uri.EscapeDataString(massage);
        
        var dataFormat = "username={0}&password={1}&number={2}&message={3}";


        var urlEncodedData = string.Format(dataFormat, UserId, Password, number, smsText);
        var data = Encoding.ASCII.GetBytes(urlEncodedData);

        request.Method = "post";
        request.Proxy = null;
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;


        using (var requestStream = request.GetRequestStream())
        {
            requestStream.Write(data, 0, data.Length);
        }

        try
        {
            using (var response = request.GetResponse())
            {
                var responseString = ParseResponse(response);
                string[] responseList = responseString.Split("|");
             
                if (responseList[0] == "1101")
                {
                    return responseList[1];
                }
                else if(responseList[0] == "1004")
                {
                    throw new Exception(string.Format("Sms Sending was failed. Because: Invalid number"));
                }
                else if(responseList[0] == "1006")
                {
                    throw new Exception(string.Format("Sms Sending was failed. Because: insufficient Balance"));
                }
                else if (responseList[0] == "1009")
                {
                    throw new Exception(string.Format("Sms Sending was failed. Because: Inactive Account"));
                }
                else
                {
                    throw new Exception(string.Format("Sms Sending was failed"));
                }

            }
        }
        catch (WebException e)
        {
                throw new Exception("Sms Sending was failed. Because: " + e.Message);
        }

    }
}