using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace myBlog.API.Models
{
    public class Post
    {
        [BsonId]
        public int PostId { get; set; }

        public int UserId { get; set; }

        [BsonDateTimeOptions]
        public DateTime Post_time { get; set;} = DateTime.Now;

        public string Title { get; set; }

        public int Likes {get; set;} = 0;

        public string Content {get; set;}
    }
}