namespace SharedTrip.Controllers
{
    using SharedTrip.Services.Users;
    using SharedTrip.Services.Models;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View(); 
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserFormDataInputModel inputModel)
        {
            //TODO:Validate all properties..

            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            this.userService.Register(inputModel);

            return Redirect("/Users/Login");
        }
    }
}
