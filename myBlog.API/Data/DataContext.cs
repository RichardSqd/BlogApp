using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

using myBlog.API.Models;

namespace myBlog.API.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
            });
            

            //modelBuilder.Entity<Post>().HasOne<User>().WithMany().HasForeignKey(p => p.UserId);
        }
        
        public DbSet<Value> Values { get; set; }
        
        //add migration to database
        public DbSet<User> Users { get; set; }

    }
}