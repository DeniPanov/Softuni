namespace SharedTrip.Services.Users
{
    public interface IUserService
    {
        void Register(string username, string email, string password);

        string GetUserId(string username, string password);

        bool EmailExists(string email);

        bool UsernameExists(string username);
    }
}
