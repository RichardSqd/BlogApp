using AutoMapper;
using myBlog.API.Dtos;
using myBlog.API.Models;
namespace myBlog.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(){
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForUpdateDto>();
        }
    }
}