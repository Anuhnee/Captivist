using Captivist.Core.Models;
using System.Collections.Generic;

namespace Captivist.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public Review Add(Review newReview)
        {
            return _reviewRepo.Add(newReview);
        }

        public Review Get(int id)
        {
            return _reviewRepo.Get(id);
        }

        public IEnumerable<Review> GetAll()
        {
            return _reviewRepo.GetAll();
        }

        public void Remove(int id)
        {
            _reviewRepo.Remove(id);
        }

        public Review Update(Review updatedReview)
        {
            return _reviewRepo.Update(updatedReview);
        }
    }
}