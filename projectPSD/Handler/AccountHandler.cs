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

        public void toggleUserRole(int userId)
        {
            UserRepository.toggleRole(userId);
        }

        public void toggleUserStatus(int userId)
        {
            UserRepository.toggleStatus(userId);
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

        public void createMember(Dictionary<String, String> registerInputs)
        {
            Users user = UserFactory.createUser(registerInputs);
            UserRepository.insertNewUser(user);
        }

        public void updateUserProfile(int userId, Dictionary<String, String> updateInputs)
        {
            UserRepository.updateUsers(userId, updateInputs);
            Session["email"] = updateInputs["email"];
            Session["name"] = updateInputs["name"];
            Session["gender"] = updateInputs["gender"];
        }

        public void updatePassword(int userId, String newPassword)
        {
            UserRepository.updatePass(userId, newPassword);
        }

        public String getPassById(int userId)
        {
            return userRepo.getPassById(userId);
        }

        public List<Users> getUsers()
        {
            return UserRepository.getUsers();
        }
    }
}