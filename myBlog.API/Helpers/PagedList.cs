using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using myBlog.API.Models;




namespace myBlog.API.Helpers
{
    public class PagedList {
        public List<Post> postsTobeListed;
        public int CurrentPage {get; set;}

        public int TotalPages{get; set;}

        public int PageSize { get; set;}

        public long TotalCount { get; set;}

        public PagedList(List<Post> items, long count, int pageNumber, int pageSize){
            TotalCount = count; 
            PageSize = pageSize;
            CurrentPage = pageNumber; 
            TotalPages = (int) Math.Ceiling(count/ (double) PageSize);
            this.postsTobeListed = new List<Post>();
            this.postsTobeListed.AddRange(items);
            // foreach(Post p in postsTobeListed){
            //     Console.WriteLine(p.Content);
            // }
        }

        public static async Task<PagedList> CreateAsync(IMongoCollection<Post> source, int pageNumber, int pageSize){
            source.AsQueryable();

            var count = await source.CountDocumentsAsync(_ => true);
            var postIdStart = count-pageNumber*pageSize;
            var items = await source.Find(post => post.PostId>=postIdStart && post.PostId<postIdStart+pageSize).ToListAsync();
            items.Sort(delegate(Post x, Post y){
                return x.Post_time.CompareTo(y.Post_time);
            });
            // source.AsQueryable<Post>().Skip((pageNumber-1)*pageSize).Take(pageSize);
            //var items = await source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
            //Console.WriteLine((pageNumber-1)*pageSize);
            return new PagedList(items, count, pageNumber, pageSize);
        }

    }
}