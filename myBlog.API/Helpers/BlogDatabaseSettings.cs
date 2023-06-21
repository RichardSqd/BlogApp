using myBlog.API.Models;

namespace myBlog.API.Helpers
{
    public interface IBlogDatabaseSettings
    {
        string BlogCollectionName {get; set;}

        string TagCollectionName {get; set;}

        string TagMapCollectionName {get; set;}


        string ConnectionString {get; set;}

        string DatabaseName {get; set;} 
        
        
    }
    public class BlogDatabaseSettings: IBlogDatabaseSettings
    {
        public string BlogCollectionName {get; set;}

        public string TagCollectionName {get; set;}

        public string TagMapCollectionName {get; set;}

        public string ConnectionString {get; set;}

        public string DatabaseName {get; set;} 
    }


}