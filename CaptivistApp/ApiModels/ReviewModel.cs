using Captivist.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaptivistApp.ApiModels
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int  UserId {get; set;}
        public DateTime DateAdded { get; set; }
        public string FoodId { get; set; }
        public int UserScore { get; set; }
        public string ReviewDescription { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }

    }
}
