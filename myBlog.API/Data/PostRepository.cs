using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myBlog.API.Models;
using myBlog.API.Helpers;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
namespace myBlog.API.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> _posts;


        public PostRepository( IBlogDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);
            
            _posts = database.GetCollection<Post>(settings.BlogCollectionName);



        }

        public void Add(Post p) {
            //Console.WriteLine("writing to database"+p.PostId);
           this._posts.InsertOne(p);
        }


        public void Delete(int id) {
            this._posts.DeleteOne(p =>p.PostId==id);
        }

        public async Task<PagedList> Get(PostParams postParams){
            
               
            return await PagedList.CreateAsync(_posts,postParams.PageNumber,postParams.PageSize );

            
        }

        public async Task<Post> Get(int id){
            // var user = await this.context.Posts.FirstOrDefaultAsync(p=>p.PostId == id);
            // return user;
            
            return await _posts.Find(p =>p.PostId==id).SingleOrDefaultAsync();

        }
    }
}