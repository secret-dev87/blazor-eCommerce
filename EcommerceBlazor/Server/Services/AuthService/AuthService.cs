using System.Security.Cryptography;

namespace EcommerceBlazor.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            //check if user exists
            if(await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                { 
                    Success = false,
                    Message = "User already exists."
                };
            }

            //if doesn't - create passwordHash value 
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            //add user to the Db
            _context.Users.Add(user);
            //save changes in Db
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id };
        }

        //checks if user exists 
        public async Task<bool> UserExists(string email)
        {
            if(await _context.Users.AnyAsync(user => user.Email.ToLower()
                .Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        //encrypt users password using special cryptography method
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.
                    ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
