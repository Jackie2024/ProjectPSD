using ProjectPSD.Factory;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ProjectPSD.Handler
{
    public class AccountHandler : Page
    {
        private UserRepository userRepo = new UserRepository();

        public void toggleRememberMe(String email, String password)
        {
            HttpContext.Current.Response.Cookies["email"].Value = email;
            HttpContext.Current.Response.Cookies["pass"].Value = password;
        }

        public Users getLoginUser(String email, String password)
        {
            return userRepo.getLoginUser(email, password);
        }

        public void logUserIn(Users u)
        {
            Session["name"] = u.Name;
            Session["roleId"] = u.RoleID;
            Session["userId"] = u.ID;
            Session["email"] = u.Email;
            Session["gender"] = u.Gender;
            HttpContext.Current.Response.Redirect("Home.aspx");
        }

        public List<Users> getUsers()
        {
            return UserRepository.getUsers();
        }

        public void createMember(Dictionary<String, String> registerInputs)
        {
            Users user = UserFactory.createUser(registerInputs);
            UserRepository.insertNewUser(user);
        }
    }
}