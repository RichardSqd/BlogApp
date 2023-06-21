using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myBlog.API.Models;
using myBlog.API.Helpers;
using System.Collections.Generic;




namespace myBlog.API.Data
{


    public class TagmapRepository: ITagMapRepository
    {

        private readonly IMongoCollection<Models.Tagmap> _tagmap;


        public TagmapRepository( IBlogDatabaseSettings settings){

            var client = new MongoClient(settings.ConnectionString);

            var database = client.GetDatabase(settings.DatabaseName);

            _tagmap = database.GetCollection<Models.Tagmap>(settings.TagMapCollectionName);

        }



        public void Add(Tagmap tagmap) {
           this._tagmap.InsertOne(tagmap);

        }
        public void Delete(int id) {
            this._tagmap.DeleteOne(tm =>tm.Id==id);

        }
        public async Task<List<Tagmap>> GetTagsByPostId(int PostId){
            return await this._tagmap.Find(tm =>tm.PostId==PostId).ToListAsync();

        }

        public async Task<List<Tagmap>> GetPostsByTagId(int TagId){
            return await this._tagmap.Find(tm =>tm.TagId==TagId).ToListAsync();

        }

    }
    
}