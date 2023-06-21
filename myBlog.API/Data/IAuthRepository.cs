using System.Threading.Tasks;
using myBlog.API.Models;

namespace myBlog.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);

         Task<User> Login(string username, string password);

         Task<bool> UserExists(string username);

         //TODO: ADD DELETE
    }
}