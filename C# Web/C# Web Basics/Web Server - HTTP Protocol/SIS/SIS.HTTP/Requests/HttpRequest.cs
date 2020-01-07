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
                .Split(GlobalConstants.HttpNewLine, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries); //new[] { ' ' }?

            if (this.IsValidRequestLine(requestLine) == false)
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseRequestHeaders(this.ParsePlainRequestHeaders(splitRequestContent).ToArray());
            //this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[^1]);
            this.ParseQueryParameters();
        }

        private void ParseRequestHeaders(string[] headersToSplit)
        {
            headersToSplit
                .Select(hts => hts
                .Split(": ", StringSplitOptions.RemoveEmptyEntries))
                .ToList();

            foreach (var kvp in headersToSplit)
            {
                HttpHeader header = new HttpHeader(kvp[0].ToString(), kvp[1].ToString());
                Headers.AddHeader(header);
            }

        }

        private void ParseRequestPath()
        {
            this.Path = Url.Split('?')[0];
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            HttpRequestMethod outParam;
            bool parseResult = Enum.TryParse(requestLine[0], true, out outParam);

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
            var queryParams = this.Url.Split('?', '#')[1]
                 .Split('&')
                 .Select(queryParam => queryParam.Split('='))
                 .ToList();

            foreach (var param in queryParams)
            {
                this.QueryData.Add(param[0], param[1]);
            }
        }

        private void ParseRequestParameters(string requestBody)
        {
            ParseQueryParameters();
            ParseFormDataParameters(requestBody);
        }

        private void ParseFormDataParameters(string requestBody)
        {
            //TODO:Parse multiple parameters by name
            var formDataParams = requestBody
                //.Split('?')[1]
                    .Split('&')
                    .Select(dataParam => dataParam.Split('='))
                    .ToList();

            foreach (var param in formDataParams)
            {
                this.QueryData.Add(param[0], param[1]);
            }
        }

        private IEnumerable<string> ParsePlainRequestHeaders(string[] requestLines)
        {
            for (int i = 1; i < requestLines.Length; i++)
            {
                if (string.IsNullOrEmpty(requestLines[i]) == false)
                {
                    yield return requestLines[i];
                }
            }
        }
    }
}
