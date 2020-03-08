using Captivist.Core.Models;
using Captivist.Core.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Captivist.Infrastructure.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _dbContext;
        public ReviewRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Review> GetAll()
        {
            //TODO: make sure each Review doesn't have every single comment 
            return _dbContext.Reviews
                .Include(r => r.Comments)

                .ToList();

        }

        public Review Get(int id)
        {
            return _dbContext.Reviews
                .Include(r => r.User)
                .SingleOrDefault(r => r.Id == id);
        }

        public Review Add(Review review)
        {
            _dbContext.Reviews.Add(review);
            _dbContext.SaveChanges();
            return review;
        }

        public Review Update(Review updatedReview)
        {
            var currentReview = _dbContext.Reviews.Find(updatedReview.Id);

            if (currentReview == null) return null;

            _dbContext.Entry(currentReview)
                .CurrentValues
                .SetValues(updatedReview);

            _dbContext.Reviews.Update(currentReview);
            _dbContext.SaveChanges();
            return currentReview;
        }
        public void Remove(int id)
        {
            var delReview = _dbContext.Reviews.Find(id);

            if (delReview != null)
            {
                _dbContext.Reviews.Remove(delReview);
                _dbContext.SaveChanges();
            }
        }
    }
}