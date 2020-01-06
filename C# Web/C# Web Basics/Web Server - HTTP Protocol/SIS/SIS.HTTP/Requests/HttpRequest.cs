namespace SIS.HTTP.Requests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Common;
    using SIS.HTTP.Headers;
    using SIS.HTTP.Exceptions;
    using SIS.HTTP.Headers.Contracts;
    using SIS.HTTP.Requests.Contracts;

    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(GlobalConstants.HttpNewLine, System.StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries); //new[] { ' ' }?

            if (this.IsValidRequestLine(requestLine) == false)
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            //this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[^1]);
            this.ParseQueryParameters();
        }        

        private void ParseHeaders(string[] v)
        {
            throw new NotImplementedException();
        }

        private void ParseRequestPath()
        {
            throw new NotImplementedException();
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            HttpRequestMethod outParam;
            bool parseResult = Enum.TryParse(requestLine[0], out outParam);

            if (parseResult == false)
            {
                throw new BadRequestException(
                    string.Format(GlobalConstants.UnsopportedHttpMethodExceptionMessage, requestLine[0]));
            }

            this.RequestMethod = outParam;
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length != 3 ||
                requestLine[2] != GlobalConstants.HttpOneProtocolFragment)
            {
                return false;
            }

            return true;
        }

        private void ParseQueryParameters()
        {
            throw new NotImplementedException();
        }

        private void ParseRequestParameters(string v)
        {
            ParseQueryParameters();
            ParseFormDataParameters();
        }

        private void ParseFormDataParameters()
        {

        }
    }
}
