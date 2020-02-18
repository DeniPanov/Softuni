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

        public HttpResponse Add()
        {
            return this.View();
        }

        public HttpResponse Details(string tripId)
        {
            return this.View();
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            return Redirect("/");
        }
    }
}
