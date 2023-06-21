using System;
namespace myBlog.API.Dtos
{
    public class UserForListDto
    {
        public int Id {get; set;}
        public string UserName {get; set;}

        public string Avatar{get; set;}

        public DateTime Created{get; set;}

        public string Email { get; set;}

        public string Bio { get; set; }

        public string Profession {get; set;}



    }
}