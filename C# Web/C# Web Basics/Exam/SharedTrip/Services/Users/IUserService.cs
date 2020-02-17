namespace SharedTrip.Services.Users
{
    using SharedTrip.Services.Models;

    public interface IUserService
    {
        void Register(UserFormDataInputModel model);
    }
}
