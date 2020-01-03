namespace SIS.HTTP.Headers
{
    using System.Linq;
    using System.Collections.Generic;

    using SIS.HTTP.Common;
    using SIS.HTTP.Headers.Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private Dictionary<string, HttpHeader> httpHeaders;

        public HttpHeaderCollection()
        {
            this.httpHeaders = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            CoreValidator.ThrowIfNull(header, nameof(header));
            this.httpHeaders.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            return this.httpHeaders.ContainsKey(key);           
        }

        public HttpHeader GetHeader(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (this.httpHeaders.ContainsKey(key) == false) //consider commenting this check
            {
                return null;
            }

            return this.httpHeaders[key];
        }

        public override string ToString()
        {
            return string.Join(GlobalConstants.HttpNewLine,
                this.httpHeaders.Values.
                Select(header => header.ToString()));
        }
    }
}
