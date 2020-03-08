using Captivist.Core.Models;
using Captivist.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaptivistApp
{
    public class DbInitializer
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly ICommentRepository _commentRepo;
        private readonly UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IReviewRepository reviewRepo, ICommentRepository commentRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _reviewRepo = reviewRepo;
            _commentRepo = commentRepo;
        }

        public void Initialize()
        {
            AddAdminUser();
            AddTestUsers();
            AddTestReviews();
        }

        public void AddTestUsers()
        {
            var testUsers = new[]
            {
                new
                {
                    Email = "john.smith@test.com",
                    FirstName = "John",
                    LastName = "Smith"
                },
                new
                {
                    Email = "jane.doe@test.com",
                    FirstName = "Jane",
                    LastName = "Doe"
                }
            };

            foreach (var user in testUsers)
            {
                CreateUser(user.Email, user.FirstName, user.LastName);
            }
        }

        private User CreateUser(string email, string firstName, string lastName)
        {
            if (_userManager.FindByNameAsync(email).Result == null)
            {
                User user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };
                // add user
                var result = _userManager.CreateAsync(user, "Testing123!").Result;
                if (result.Succeeded) return user;
            }
            return null;
        }

        public void AddTestReviews()
        {
            if (_reviewRepo.GetAll().Count() > 0) return;

            var john = _userManager.FindByNameAsync("john.smith@test.com").Result;
            var jane = _userManager.FindByNameAsync("jane.doe@test.com").Result;
            var johnReview1 = CreateTestReview(1, john, 1, "Green Apple", 100, "Super delicious!");
            var janeReview1 = CreateTestReview(2, jane, 2, "Coca-cola", 0, "Everything about this product sucks...");
            _reviewRepo.Add(johnReview1);
            _reviewRepo.Add(janeReview1);
        }

        private Review CreateTestReview(int userId, User user, int reviewId, string foodId, int rating, string description)
        {
            return new Review
            {
                
                Id = reviewId,
                FoodId = foodId,
                UserScore = rating,
                ReviewDescription = description,
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        UserId = 1,
                        CommentDescription = "Wow, super cool!",
                        DateAdded = DateTime.Now

                    },
                    new Comment
                    {
                        UserId = 2,
                        CommentDescription = "I agree that this is something I could implement into my daily life! ",
                        DateAdded = DateTime.Now
                    },
                }
            };
        }

        private void AddAdminUser()
        {
            // create an Admin role, if it doesn't already exist
            if (_roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = _roleManager.CreateAsync(adminRole).Result;
            }

            var user = CreateUser("admin@test.com", "admin", "admin");
            if (user != null)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}