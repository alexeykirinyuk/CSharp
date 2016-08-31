using MvcEntityTask.Managers;
using System.Web.Mvc;

namespace MvcEntityTask.Controllers.Api
{
    public class ReviewsController : Controller
    {
        public string GetReviews()
        {
            return ReviewManager.Instance.GetJsonReviews();
        }

        public string GetUserReviews(string userKey)
        {
            return ReviewManager.Instance.GetJsonReviews(userKey);
        }

        public string AddReview(string userKey, string comment)
        {
            if(!UserManager.Instance.HasKey(userKey))
            {
                return "user not found";
            }

            UserManager.Instance.AddUser(userKey, comment);
            return "review adding success";
        }

        public string RemoveReview(string userKey, int reviewId)
        {
            if (!UserManager.Instance.HasKey(userKey))
            {
                return "user not found";
            }
                
            if(!ReviewManager.Instance.IsExist(userKey, reviewId))
            {
                return "review not found";
            }

            ReviewManager.Instance.Remove(userKey, reviewId);

            return "review was success removed";
        }
    }
}