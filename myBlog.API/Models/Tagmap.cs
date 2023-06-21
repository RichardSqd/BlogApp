using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace myBlog.API.Models
{
    public class Tagmap
    {
        [BsonId]
        public int Id {get; set;}

        public int TagId {get; set;}

        public int PostId {get; set;}
    }
}