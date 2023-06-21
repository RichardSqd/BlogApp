using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using myBlog.API.Dtos;
using myBlog.API.Models;
using myBlog.API.Data;
using myBlog.API.Helpers;
using System.Threading.Tasks;
using System;
using System.IO;
using Markdig;

namespace myBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController: ControllerBase
    {
        private readonly PostRepository postRepository;
        private readonly IConfiguration Configuration;

        public PostController( PostRepository postRepository, IConfiguration configuration){
            this.Configuration = configuration;
            this.postRepository = postRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id){
            //Console.WriteLine("accepting"+id.ToString());
            var post = await this.postRepository.Get(id);
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().ConfigureNewLine("\r\n").Build();
            post.Content= Markdown.ToHtml(post.Content, pipeline);
            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery]PostParams postParams){
            //Console.WriteLine("accepting all");

            //Console.WriteLine("in post get");
            //Console.WriteLine(postParams.PageNumber.ToString(),postParams.PageSize.ToString());
            //var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().ConfigureNewLine("\r\n").Build();
            var posts = await this.postRepository.Get(postParams);
            
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().ConfigureNewLine("\r\n").Build();
        
            posts.postsTobeListed.ForEach(delegate(Post post){
                post.Content= MarkdownStrip.HtmlToPlainText(Markdown.ToHtml(post.Content, pipeline)).TrimStart().Substring(0,50);
            });
            
            Response.AddPagination(posts.CurrentPage,posts.PageSize,Convert.ToInt32( posts.TotalCount),posts.TotalPages);

            return Ok(posts.postsTobeListed);
        }

       
        [HttpPost("{id}")]
        public async Task<IActionResult> Add(int id, [FromQuery(Name = "title")] string title, [FromQuery(Name = "date")] int date=1){
            Post post = new Post();
            var postpath = Configuration.GetSection("PostPath").Get<string[]>()[0];
            postpath += "note" + (id+1) + ".md";
            var fileStream = new FileStream(postpath, FileMode.Open);
         
            string content;
            if(fileStream==null) return BadRequest();
            try{
                using (StreamReader reader = new StreamReader(fileStream)){
                    content = await reader.ReadToEndAsync();
                }
            }catch(Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return BadRequest();
            }

            if(await this.postRepository.Get(id)!=null){
                return BadRequest();
            }
            
            
            post.PostId = id;
            post.UserId = 0;
            post.Title = title==null ? new StringReader(content).ReadLine() : title;
            post.Likes = 0;
            post.Content = content;
            post.Post_time=new DateTime(2020, 8, date, 0, 0, 0);
            
            
            postRepository.Add(post);
            return Ok();
        }
        
        
    }
}