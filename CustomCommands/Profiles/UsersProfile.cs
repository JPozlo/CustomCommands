using AutoMapper;
using CustomCommands.Entities;
using CustomCommands.Models.User;

namespace CustomCommands.Profiles
{
    public class UsersProfile: Profile
    {
         public UsersProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}