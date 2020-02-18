namespace SharedTrip.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SharedTrip.Services.Users;
    using SharedTrip.ViewModels.Users;

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
                return this.Redirect("/");
            }

            return this.View(); 
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.userService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Username.Length < 5
             || input.Username.Length > 20
             || string.IsNullOrWhiteSpace(input.Username))
            {
                return this.Redirect("/Users/Register");
            }

            if(string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password.Length < 6
             || input.Password.Length > 20
             || string.IsNullOrWhiteSpace(input.Password))
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }                       

            this.userService.Register(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
