using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Captivist.Core.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public ICollection<int> ProductsId { get; set; } 
        public ICollection<Review> Reviews { get; set; }
    }
}