using System.Threading.Tasks;
using myBlog.API.Models;
using myBlog.API.Helpers;
using MongoDB.Driver;
using System;

namespace myBlog.API.Data
{

    public class TagReposotory : ITagRepository
    {

        private readonly IMongoCollection<Models.Tag> _tags;

        public TagReposotory(IBlogDatabaseSettings settings){
            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _tags = database.GetCollection<Models.Tag>(settings.TagCollectionName);

        }


        public void Add(Models.Tag tag){
            this._tags.InsertOne(tag);


        }

        public void Delete(int id) {
            this._tags.DeleteOne(t =>t.TagId==id);

        }

        public async Task<Models.Tag> Get(int TagId){
            return await _tags.Find(t =>t.TagId==TagId).SingleOrDefaultAsync();

        }


    }
}