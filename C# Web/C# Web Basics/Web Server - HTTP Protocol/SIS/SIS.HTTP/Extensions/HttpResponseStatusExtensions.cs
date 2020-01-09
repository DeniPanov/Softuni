namespace SIS.HTTP.Extensions
{
    using SIS.HTTP.Enums;

    public class HttpResponseStatusExtensions
    {
        public static string GetStatusLine(HttpResponseStatusCode statusCode)
        {
            return statusCode switch
            {
                HttpResponseStatusCode.Ok => "200 Ok",
                HttpResponseStatusCode.Created => "201 Created",
                HttpResponseStatusCode.Found => "302 Founf",
                HttpResponseStatusCode.SeeOther => "303 SeeOther",
                HttpResponseStatusCode.BadRequest => "400 BadRequest",
                HttpResponseStatusCode.Unauthorized => "401 Unauthorized",
                HttpResponseStatusCode.Forbidden => "403 Forbidden",
                HttpResponseStatusCode.NotFound => "404 NotFound",
                HttpResponseStatusCode.InternalServerError => "500 InternalServerError",
                _ => null,
            };
        }
    }
}
