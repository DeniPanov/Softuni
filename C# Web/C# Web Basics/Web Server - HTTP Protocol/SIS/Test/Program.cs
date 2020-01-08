namespace Test
{
    using System;

    using SIS.HTTP.Requests;

    public class Program
    {
        public static void Main()
        {
            string request = 
                "POST /someUrl/asd?name=pesho&id=1#fragment HTTP/1.1\r\n"
                + "Authorization: Basic 23442562\r\n"
                + "Date: " + DateTime.UtcNow + "\r\n"
                + "Host: localhost:5000\r\n"
                + "\r\n"
                +"username=peshoGoshov&password=abv";

            HttpRequest httpRequest = new HttpRequest(request);

            ;
        }
    }
}
