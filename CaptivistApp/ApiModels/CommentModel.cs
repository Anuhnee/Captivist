using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaptivistApp.ApiModels
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }
        public string CommentDescription { get; set; }
        public int ReviewId { get; set; }
    }
}
