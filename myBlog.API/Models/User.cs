using System;
namespace myBlog.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username {get;set;}

        public byte[] PasswordHash{get;set;}

        public byte[] PasswordSalt{get;set;}

        public DateTime Created {get; set;}

        public string Email { get; set;}

        public string Bio { get; set; }

        public int Level {get; set;}

        public string Avatar {get; set;}

        public string Profession {get; set;}

        public string Status {get; set;}

        public string RealName {get; set;}

        public string RegisterIp {get; set;}
    }
}