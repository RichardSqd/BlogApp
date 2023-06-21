using System;
using System.Threading.Tasks;
using myBlog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace myBlog.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        //inject data context 
        private readonly DataContext context;
        public AuthRepository(DataContext context){
            this.context = context;
        }

        private bool CheckHash(string password, byte[] hashed, byte[] salt){
            using(var hmac = new System.Security.Cryptography.HMACSHA256(salt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i =0; i<computedHash.Length; i++){
                    if(computedHash[i]!=hashed[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Login(string username, string password){
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if(user == null) {
                return null;
            }
            if(!CheckHash(password,user.PasswordHash,user.PasswordSalt)){
                return null;
            }

            return user;
        }


        public async Task<User> Register (User user, string password){
            byte[] hashed, salt;
            createPass(password, out hashed, out salt);
            user.PasswordHash = hashed;
            user.PasswordSalt = salt;


            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        private void createPass(string password,out byte[] hashed,out byte[] salt){
            using(var hmac = new System.Security.Cryptography.HMACSHA256()){
                salt = hmac.Key;
                hashed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }

        public async Task<bool> UserExists(string username){
            
            if(username!=null && await context.Users.AnyAsync(x => x.Username == username)){
                return true;
            }
            return false;
        }
    }

}