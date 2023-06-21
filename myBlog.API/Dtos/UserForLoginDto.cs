namespace myBlog.API.Dtos
{
    public class UserForLoginDto
    {
        public string Username { get; set; }
        public string Password {get; set;}

        public bool Remember {get; set;}
    }
}