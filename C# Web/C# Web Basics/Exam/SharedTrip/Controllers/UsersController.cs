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
                return Redirect("/");
            }

            return this.View(); 
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            var userId = this.userService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return Redirect("/Trips/All");
            }

            return Redirect("/Users/Login");
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
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return Redirect("/");
            }

            if (input.Username.Length < 5
             || input.Username.Length > 20
             || string.IsNullOrWhiteSpace(input.Username))
            {
                return Redirect("/Users/Register");
            }

            if(string.IsNullOrWhiteSpace(input.Email))
            {
                return Redirect("/Users/Register");
            }

            if (input.Password.Length < 6
             || input.Password.Length > 20
             || string.IsNullOrWhiteSpace(input.Password))
            {
                return Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return Redirect("/Users/Register");
            }                       

            this.userService.Register(input.Username, input.Email, input.Password);

            return Redirect("/Users/Login");
        }
    }
}
