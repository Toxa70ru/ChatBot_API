using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymics { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public interface IAuthService 
    {
        bool IsUsernameTaken(string username);
        User Authenticate(string username, string password);
        User Register(User user, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly ChatBotContext _context;
        public AuthService(ChatBotContext context)
        {
            _context = context;
        }

        public bool IsUsernameTaken(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null || !VerfyPasswordHash(password, user.Password))
            {
                return null;
            }
            return user;
        }

        public User Register(User user, string password)
        {
            if (IsUsernameTaken(user.Username))
            {
                return null;
            }
            user.Password = HashPassword(password);
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public static string HashPassword(string password) 
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider()) 
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password+salt);

            using (var sha256 = SHA256.Create()) 
            {

                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                string hashedPassword = Convert.ToBase64String(hashedBytes);

                return (hashedPassword);
            }
        }

        public static bool VerfyPasswordHash(string providedPassword, string hashedPassword) 
        {
            return true;
            /*byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(providedPassword+salt);


            using (var sha256 = SHA256.Create()) 
            {
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                string hashedProvidedPassword = Convert.ToBase64String(hashedBytes);

                return hashedPassword.Equals(hashedProvidedPassword);
            }*/
        }




        /*public bool VerfyPasswordHash(string password, string storedHash) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) 
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                var sb = new StringBuilder();
                foreach (byte b in computedHash)
                {
                    //sb.Append(b.ToString("X2"));
                    sb.Append(b.ToString());
                }
                return storedHash == sb.ToString();
            }
        }*/

        /*private string HashPassword(string password) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                var sb = new StringBuilder();
                foreach (byte b in computedHash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }*/
    }
    
}
