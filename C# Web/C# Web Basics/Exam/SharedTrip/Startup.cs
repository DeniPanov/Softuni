namespace SharedTrip
{
    using System.Collections.Generic;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Services.Users;
    using SharedTrip.Services.Trips;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.EnsureCreated();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<ITripService, TripService>();
        }
    }
}
