using System;
using System.Net;
using System.IO;

namespace VDIAZ.Semana6.Clase.Utils
{
    public class RestExecutor
    {
        private readonly WebClient client = new WebClient();

        public String Execute(string resourceUri, string method, string payload = null)
        {
            string response = null;
            try
            {
                Console.WriteLine("URL: " + resourceUri);
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers.Add("Accept", "application/json");
                Console.WriteLine(payload);
                if ("DELETE".Equals(method))
                {
                    response = ExecDelete(resourceUri);
                } else
                {
                    response = client.UploadString(resourceUri, method, payload);
                }
                Console.WriteLine("RESULT:-------------");
                Console.WriteLine(response);
            } catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw exception;
            }
            return response;
        }

        private string ExecDelete(string resourceUri)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(resourceUri);
            httpRequest.Method = "DELETE";

            httpRequest.Accept = "application/json";

            string result = null;

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            Console.WriteLine(httpResponse.StatusCode);
            return result;
        }


    }
}
