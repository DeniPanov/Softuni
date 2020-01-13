namespace Test.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class HomeController : BaseController
    {
        public IHttpResponse Home(IHttpRequest request)
        {
            return this.View();
        }
    }
}
