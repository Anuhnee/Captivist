using Captivist.Core.Models;
using Captivist.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Captivist.Infrastructure.Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _dbContext.Comments
                .Include(c => c.User)

                .ToList();
        }

        public Comment Get(int id)
        {
            return _dbContext.Comments
                .Include(c => c.User)

                .FirstOrDefault(c => c.Id == id);
        }

        public Comment Add(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
            return comment;
        }

        public Comment Update(Comment updatedComment)
        {
            var currentComment = _dbContext.Comments.Find(updatedComment.Id);

            if (currentComment == null) return null;
            _dbContext.Entry(currentComment)
                .CurrentValues
                .SetValues(updatedComment);

            return currentComment;
        }

        public void Remove(int id)
        {
            var delComment = _dbContext.Comments.Find(id);

            if(delComment != null)
            {
                _dbContext.Comments.Remove(delComment);
                _dbContext.SaveChanges();
            }
        }
    }
}