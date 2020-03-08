using Captivist.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Captivist.Core.Services
{
    public interface IReviewService
    {
        Review Add(Review newReview);
        Review Update(Review updatedReview);
        Review Get(int id);
        IEnumerable<Review> GetAll();
        void Remove(int id);
    }
}
