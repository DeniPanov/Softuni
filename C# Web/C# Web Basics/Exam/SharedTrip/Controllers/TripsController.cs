namespace SharedTrip.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class TripsController : Controller
    {
        public HttpResponse All()
        {
            return this.View();
        }
    }
}
