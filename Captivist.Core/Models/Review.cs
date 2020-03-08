using System;
using System.Collections.Generic;

namespace Captivist.Core.Models
{
    public class Review 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateAdded { get; set; }
        public string FoodId { get; set; }
        public int UserScore { get; set; }
        public string ReviewDescription { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}