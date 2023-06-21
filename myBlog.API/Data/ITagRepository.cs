using System.Threading.Tasks;
using myBlog.API.Models;
using System;
using System.Collections.Generic;

namespace myBlog.API.Data
{
    public interface ITagRepository
    {
        void Add(Tag tag) ;
        void Delete(int id) ;
        Task<Tag> Get(int TagId);
        
    }

    public interface ITagMapRepository{
        void Add(Tagmap tagmap) ;
        void Delete(int id) ;
        Task<List<Tagmap>> GetTagsByPostId(int PostId);

        Task<List<Tagmap>> GetPostsByTagId(int TagId);

    }





}