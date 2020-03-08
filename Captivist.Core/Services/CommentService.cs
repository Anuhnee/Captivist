using Captivist.Core.Models;
using System.Collections.Generic;

namespace Captivist.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;

        public CommentService(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public Comment Add(Comment newComment)
        {
            return _commentRepo.Add(newComment);
        }

        public Comment Get(int id)
        {
            return _commentRepo.Get(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _commentRepo.GetAll();
        }

        public void Remove(int id)
        {
            _commentRepo.Remove(id);
        }

        public Comment Update(Comment updatedComment)
        {
            return _commentRepo.Update(updatedComment);
        }
    }
}