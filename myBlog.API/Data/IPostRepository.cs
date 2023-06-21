using System.Threading.Tasks;
using myBlog.API.Models;
using myBlog.API.Helpers;
namespace myBlog.API.Data
{
    public interface IPostRepository
    {
        void Add(Post p) ;
        void Delete(int id) ;

        Task<PagedList> Get(PostParams postParams);

        Task<Post> Get(int id);


    } 
    
}
