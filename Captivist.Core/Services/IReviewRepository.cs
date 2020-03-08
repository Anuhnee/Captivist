using Captivist.Core.Models;
using System.Collections.Generic;

namespace Captivist.Core.Services
{
    public interface IReviewRepository
    {
        Review Add(Review review);
        Review Get(int id);
        IEnumerable<Review> GetAll();
        void Remove(int id);
        Review Update(Review updatedReview);
    }
}