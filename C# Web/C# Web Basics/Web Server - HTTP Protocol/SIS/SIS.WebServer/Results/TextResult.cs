namespace SIS.WebServer.Results
{
    using System.Text;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Responses;

    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode responseStatusCode,
            string contentType = "text/plain; charset=utf-8")
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("ContentType", contentType));
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponseStatusCode responseStatusCode,
            string contentType = "text/plain; charset=utf-8")
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("ContentType", contentType));
            this.Content = content;
        }
    }
}
