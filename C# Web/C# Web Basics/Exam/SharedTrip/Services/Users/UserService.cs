namespace SharedTrip.Services.Users
{
    using System.Text;
    using System.Security.Cryptography;
    using SharedTrip.Models;
    using SharedTrip.Services.Models;

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext db)
        {
            this.dbContext = db;
        }

        public void Register(UserFormDataInputModel model)
        {

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.Hash(model.Password),
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
