﻿namespace SIS.HTTP.Requests.Contracts
{
    using System.Collections.Generic;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Headers.Contracts;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }
    }
}
