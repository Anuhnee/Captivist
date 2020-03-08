using System;

namespace Captivist.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
        public string CommentDescription { get; set; }
        public int ReviewId { get; set; }

    }
}