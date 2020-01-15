namespace SIS.WebServer
{
    using System;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    using SIS.HTTP.Enums;
    using SIS.HTTP.Common;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Exceptions;
    using SIS.WebServer.Results;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Routing.Contracts;

    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public async Task ProcessRequestAsync()
        {
            try
            {
                var httpRequest = await this.ReadRequestAsync();

                if (httpRequest != null)
                {
                    Console.WriteLine($"Processing: {httpRequest.RequestMethod} {httpRequest.Path}...");
                }

                var httpResponse = this.HandleRequest(httpRequest);

                this.PrepareResponse(httpResponse);
            }

            catch (BadRequestException bre)
            {

                this.PrepareResponse(new TextResult(bre.Message, HttpResponseStatusCode.BadRequest));
            }

            catch (Exception e)
            {
                this.PrepareResponse(new TextResult(e.Message, HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpRequest> ReadRequestAsync()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int redBytesCount = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (redBytesCount == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, redBytesCount);
                result.Append(bytesAsString);

                if (redBytesCount < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            if (this.serverRoutingTable.Contains(httpRequest.RequestMethod, httpRequest.Path) == false)
            {
                return new TextResult(
                    $"Route with {httpRequest.RequestMethod} and path \"{httpRequest.Path}\" not found.",
                    HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Get(httpRequest.RequestMethod, httpRequest.Path)
                .Invoke(httpRequest);
        }

        private void PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();

            this.client.Send(byteSegments, SocketFlags.None);
        }
    }
}
