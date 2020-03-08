using Captivist.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Captivist.Core.Services
{
   public interface ICommentService
    {
        Comment Add(Comment newComment);
        Comment Update(Comment updatedComment);
        Comment Get(int id);
        IEnumerable<Comment> GetAll();
        void Remove(int id);
    }
}
