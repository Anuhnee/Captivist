using Captivist.Core;
using Captivist.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaptivistApp.ApiModels
{
    public static class UserMappingExtension
    {
        public static UserModel ToApiModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                Firstname = user.FirstName,
                Lastname = user.LastName
            };
        }

        public static User ToDomainModel(this UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.Firstname,
                LastName = userModel.Lastname,
                Email = userModel.Email
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> Users)
        {
            return Users.Select(u => u.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> Users)
        {
            return Users.Select(u => u.ToDomainModel());
        }
    }
}
