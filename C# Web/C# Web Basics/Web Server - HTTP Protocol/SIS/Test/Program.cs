namespace Test
{
    using System;
    using System.Globalization;
    using System.Net;
    using System.Text;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;

    public class Program
    {
        public static void Main()
        {
            //string request = 
            //    "POST /someUrl/asd?name=pesho&id=1#fragment HTTP/1.1\r\n"
            //    + "Authorization: Basic 23442562\r\n"
            //    + "Date: " + DateTime.UtcNow + "\r\n"
            //    + "Host: localhost:5000\r\n"
            //    + "\r\n"
            //    +"username=peshoGoshov&password=abv";

            //HttpRequest httpRequest = new HttpRequest(request);

            HttpResponseStatusCode statusCode = HttpResponseStatusCode.Created;

            HttpResponse response = new HttpResponse(statusCode);
            response.AddHeader(new HttpHeader("Host", "localhost:5000"));
            response.AddHeader(new HttpHeader("Date", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)));

            response.Content = Encoding.UTF8.GetBytes("<h1>Hello world!</h1>");

            Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes()));
        }
    }
}
