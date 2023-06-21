using System.Threading.Tasks;
using myBlog.API.Models;

namespace myBlog.API.Data
{
    public interface IUserInfo
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();

        Task<User> GetUser(int id);


    }
}