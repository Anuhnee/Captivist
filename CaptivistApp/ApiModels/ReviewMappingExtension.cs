using CaptivistApp.ApiModels;
using System.Collections.Generic;
using System.Linq;

namespace Captivist.Core.Models
{
    public static class ReviewMappingExtension
    {
        public static ReviewModel ToApiModel(this Review item)
        {
            return new ReviewModel
            {
                Id = item.Id,
                UserId = item.UserId,
                DateAdded = item.DateAdded,
                FoodId = item.FoodId,
                UserScore = item.UserScore,
                ReviewDescription = item.ReviewDescription,
                Comments = item.Comments?.ToApiModels().ToList()
            };
        }

        public static Review ToDomainModel(this ReviewModel item)
        {
            return new Review
            {
                Id = item.Id,
                UserId = item.UserId,
                DateAdded = item.DateAdded,
                FoodId = item.FoodId,
                UserScore = item.UserScore,
                ReviewDescription = item.ReviewDescription,
                Comments = item.Comments?.ToDomainModels().ToList()
            };
        }

        public static IEnumerable<ReviewModel> ToApiModels(this IEnumerable<Review> items)
        {
            return items.Select(a => a.ToApiModel());
        }

        public static IEnumerable<Review> ToDomainModels(this IEnumerable<ReviewModel> items)
        {
            return items.Select(a => a.ToDomainModel());
        }

        
    }
}
