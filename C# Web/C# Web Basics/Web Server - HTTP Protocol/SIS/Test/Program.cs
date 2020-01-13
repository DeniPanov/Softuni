namespace Test
{
    using System;
    using System.Net;
    using System.Text;
    using System.Globalization;

    using SIS.WebServer;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using Test.Controllers;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;
    using SIS.WebServer.Routing;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Routing.Contracts;

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

            //HttpResponseStatusCode statusCode = HttpResponseStatusCode.Created;

            //HttpResponse response = new HttpResponse(statusCode);
            //response.AddHeader(new HttpHeader("Host", "localhost:5000"));
            //response.AddHeader(new HttpHeader("Date", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)));

            //response.Content = Encoding.UTF8.GetBytes("<h1>Hello world!</h1>");

            //Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes()));

            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Add(HttpRequestMethod.Get, "/", httpRequest
                => new HomeController().Home(httpRequest));

            Server server = new Server(32000, serverRoutingTable);
            server.Run();
        }
    }
}
