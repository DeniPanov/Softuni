namespace SIS.HTTP.Responses
{
    using System.Text;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Common;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Extensions;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
        }

        public HttpResponse(HttpResponseStatusCode statusCode)
            : this()
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }

        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            Headers.AddHeader(header);
        }

        public byte[] GetBytes()
        {
            byte[] httpResponseWithoutBody = Encoding.UTF8.GetBytes(this.ToString());

            byte[] httpResponseWithBody = new byte[httpResponseWithoutBody.Length + Content.Length];
            
            for (int i = 0; i < httpResponseWithoutBody.Length; i++)
            {
                httpResponseWithBody[i] = httpResponseWithoutBody[i];
            }

            for (int i = 0; i < httpResponseWithBody.Length - httpResponseWithoutBody.Length; i++)
            {
                httpResponseWithBody[i + httpResponseWithoutBody.Length - 1] = Content[i];
            }

            return httpResponseWithBody;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .Append($"{GlobalConstants.HttpOneProtocolFragment} {HttpResponseStatusExtensions.GetStatusLine(this.StatusCode)}")
                .Append(GlobalConstants.HttpNewLine)
                .Append(this.Headers)
                .Append(GlobalConstants.HttpNewLine);

            result.Append(GlobalConstants.HttpNewLine);

            return result.ToString();
        }
    }
}
