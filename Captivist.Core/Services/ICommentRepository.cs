using Captivist.Core.Models;
using System.Collections.Generic;

namespace Captivist.Core.Services
{
    public interface ICommentRepository
    {
        Comment Add(Comment comment);
        Comment Get(int id);
        IEnumerable<Comment> GetAll();
        void Remove(int id);
        Comment Update(Comment updatedComment);
    }
}