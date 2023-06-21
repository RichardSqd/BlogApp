using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace myBlog.API.Models
{
    public class Tag
    {
        [BsonId]
        public int TagId {get; set;}

        public string TagName {get; set;}

    }
}