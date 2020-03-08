using Captivist.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaptivistApp.ApiModels
{
    public static class CommentMappingExtension
    {
        public static CommentModel ToApiModel(this Comment item)
        {
            return new CommentModel
            {
                Id = item.Id,
                UserId = item.UserId,
                DateAdded = item.DateAdded,
                CommentDescription = item.CommentDescription,
                ReviewId = item.ReviewId
            };
        }

        public static Comment ToDomainModel(this CommentModel item)
        {
            return new Comment
            {
                Id = item.Id,
                UserId = item.UserId,
                DateAdded = item.DateAdded,
                CommentDescription = item.CommentDescription,
                ReviewId = item.ReviewId
            };
        }

        public static IEnumerable<CommentModel> ToApiModels(this IEnumerable<Comment> items)
        {
            return items.Select(c => c.ToApiModel());
        }

        public static IEnumerable<Comment> ToDomainModels(this IEnumerable<CommentModel> items)
        {
            return items.Select(c => c.ToDomainModel());
        }
    }
}
