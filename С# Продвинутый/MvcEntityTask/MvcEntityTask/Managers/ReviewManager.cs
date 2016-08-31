using MvcEntityTask.Models;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MvcEntityTask.Managers
{
    public class ReviewManager
    {
        private static ReviewManager _manager;
        private static object _lockObject = new object();

        public static ReviewManager Instance
        {
            get
            {
                if(_manager == null)
                {
                    lock(_lockObject)
                    {
                        if(_manager == null)
                        {
                            _manager = new ReviewManager();
                        }
                    }
                }
                return _manager;
            }
        }

        public string GetJsonReviews()
        {
            using (var dbContext = new UserContext())
            {
                var list = dbContext.Reviews
                    .Select(review => new
                {
                    Id = review.ReviewId,
                    Comment = review.Comment,
                    User = review.User.Name,
                    Date = review.Date
                });
                return JsonConvert.SerializeObject(list);
            }
        }

        public string GetJsonReviews(string userKey)
        {
            using (var dbContext = new UserContext())
            {
                var list = dbContext.Reviews.Where(review => review.User.Key == userKey)
                    .Select(review => new
                    {
                        Id = review.ReviewId,
                        Comment = review.Comment,
                        UserId = review.User.UserId,
                        Date = review.Date
                    });
                return JsonConvert.SerializeObject(list);
            }
        }

        public void Add(string userKey, string comment)
        {
            using (var dbContext = new UserContext())
            {
                var foundUser = dbContext.Users.Where(user => user.Key == userKey).FirstOrDefault();

                var addingReview = new Review()
                {
                    Comment = comment,
                    Date = DateTime.Now,
                    User = foundUser
                };
                dbContext.Reviews.Add(addingReview);
                dbContext.SaveChanges();
            }
        }

        public void Remove(string userKey, int reviewId)
        {
            using (var dbContext = new UserContext())
            {
                dbContext.Reviews.Remove(GetReview(userKey, reviewId));
                dbContext.SaveChanges();
            }
        }

        public bool IsExist(string userKey, int reviewId)
        {
            using (var dbContext = new UserContext())
            {
                return GetReview(userKey, reviewId) != null;
            }
        }

        private Review GetReview(string userKey, int reviewId)
        {
            using (var dbContext = new UserContext())
            {
                var user = dbContext.Users.Where(lUser => lUser.Key == userKey).FirstOrDefault();
                return user.Reviews.Where(r => r.ReviewId == reviewId).FirstOrDefault();
            }
        }
    }
}