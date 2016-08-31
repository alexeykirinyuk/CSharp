using MvcEntityTask.Managers;
using System.Web.Mvc;

namespace MvcEntityTask.Controllers.Api
{
    public class UsersController : Controller
    {
        public string SingUp(string name, string password)
        {
            if (UserManager.Instance.HasName(name))
            {
                return "generate new login";
            }
            var key = UserManager.Instance.AddUser(name, password);

            return key;
        }

        public string SingIn(string name, string password)
        {
            if (!UserManager.Instance.HasName(name))
            {
                return "user not found";
            }

            return UserManager.Instance.GetKey(name, password);
        }
    }
}