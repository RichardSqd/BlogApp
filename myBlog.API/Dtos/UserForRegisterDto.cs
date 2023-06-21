using System.ComponentModel.DataAnnotations;
using System;
namespace myBlog.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set;}

        [Required]
        [StringLength(16,MinimumLength=4,ErrorMessage = "Password should have length 4-16")]
        public string Password {get; set;}

        public DateTime Created {get; set;}

        public int Level {get; set; }

        public string Bio {get; set;}

        public string Status {get; set;}

        public UserForRegisterDto(){
            Level = 1;
            Created = DateTime.Now;
            Bio = "fill in here:";
            Status = "inactive";
        }
    }
}