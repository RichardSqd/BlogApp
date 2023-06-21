using Microsoft.AspNetCore.Mvc;
using myBlog.API.Data;
using System.Threading.Tasks;
using myBlog.API.Models;
using myBlog.API.Dtos;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
namespace myBlog.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repository;
        private readonly IConfiguration configuration;
        public AuthController(IAuthRepository repository, IConfiguration config){
            this.configuration = config;
            this.repository=repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetResult(){
            var values = await this.repository.UserExists("abc");

            Console.WriteLine(values);
            return Ok(200);
        }

        //[HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegister){
            //validation 

            userForRegister.Username = userForRegister.Username.ToLower();
            if( userForRegister.Username.Length>20 ) {
                return BadRequest("UserName/Password too long");
            }
            if(await this.repository.UserExists(userForRegister.Username)){
                return BadRequest("UserName alreay exists");
            }


            var newUser = new User{
                Username = userForRegister.Username,
                Created = userForRegister.Created,
                Bio = userForRegister.Bio,
                Level = userForRegister.Level,
                Status = userForRegister.Status

            };

            var createdUser = await repository.Register(newUser, userForRegister.Password);

            //return CreatedAtRoute()
            return StatusCode(201);
        }

       [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLogin){
            userForLogin.Username = userForLogin.Username.ToLower();
            if(!await this.repository.UserExists(userForLogin.Username)){
                return BadRequest("User not exists");
            }
            
            var loggedInUser = await repository.Login(userForLogin.Username, userForLogin.Password);
            if (loggedInUser==null){
                return Unauthorized();
            }

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, loggedInUser.Id.ToString()),
                new Claim(ClaimTypes.Name, loggedInUser.Username)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.
            GetBytes(this.configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            DateTime expiretime = userForLogin.Remember ? DateTime.Now.AddDays(7) : DateTime.Now.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = expiretime,
                SigningCredentials = creds

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });



        }

        
    }
}