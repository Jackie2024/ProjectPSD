using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class AccountController
    {
        private AccountHandler accountHdlr = new AccountHandler();

        public void toggleRemeberMe(Boolean isChecked, String email, String password)
        {
            if (isChecked== true)
            {
                HttpContext.Current.Response.Cookies["email"].Expires = DateTime.Now.AddDays(30);
                HttpContext.Current.Response.Cookies["pass"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                HttpContext.Current.Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies["pass"].Expires = DateTime.Now.AddDays(-1);
            }

            accountHdlr.toggleRememberMe(email, password);
        }

        public String toggleUserRole(int userId, int currLoginUserId)
        {
            String errMsg = validateUserViewToggle(userId, currLoginUserId);
            if (errMsg == null) accountHdlr.toggleUserRole(userId);

            return errMsg;
        }

        public String toggleUserStatus(int userId, int currLoginUserId)
        {
            String errMsg = validateUserViewToggle(userId, currLoginUserId);
            if (errMsg == null) accountHdlr.toggleUserStatus(userId);

            return errMsg;
        }

        public String loginAttempt(String email, String password)
        {
            String errMsg = validateLoginInput(email, password);

            if(errMsg == null)
            {
                Users user = accountHdlr.getLoginUser(email, password);
                errMsg = validateUser(user);
                if (errMsg == null)
                {
                    accountHdlr.logUserIn(user);
                    return errMsg;
                };
            }

            return errMsg;
        }

        public String registerNewMember(Dictionary<String, String> registerInputs)
        {
            String errMsg = validateRegistration(registerInputs);
            if (errMsg == null) accountHdlr.createMember(registerInputs);

            return errMsg;
        }

        public String updateUserProfile(int userId, Dictionary<String, String> updateInputs)
        {
            String errMsg = validateUpdateInput(updateInputs);
            if (errMsg == null) accountHdlr.updateUserProfile(userId, updateInputs);

            return errMsg;
        }

        public String changeUserPassword(int userId, Dictionary<String, String> changePassInputs)
        {
            String errMsg = validateChangePassInput(changePassInputs);
            if (errMsg == null) accountHdlr.updatePassword(userId, changePassInputs["newPassword"]);

            return errMsg;
        }

        public String getPassById(int id)
        {
            return accountHdlr.getPassById(id);
        }

        public List<Users> getUsers()
        {
            return accountHdlr.getUsers();
        }

        private String validateLoginInput(String email, String password)
        {
            String errMsg = null;
            if (email == "")
            {
                errMsg = "Email must be filled";
            }
            else if (password == "")
            {
                errMsg = "Password must be filled";
            }

            return errMsg;
        }

        private String validateUser(Users u)
        {
            String errMsg = null;
            if (u == null)
            {
                errMsg = "User not found";
            }
            else if (u.Status == "Blocked")
            {
                errMsg = "User has been blocked";
            }

            return errMsg;
        }

        private String validateRegistration(Dictionary<String, String> registerInputs)
        {
            String errMsg = null;

            if (registerInputs["email"] == "")
            {
                errMsg = "Email must be filled";
            }
            else if (registerInputs["name"] == "")
            {
                errMsg = "Name must be filled";
            }
            else if (registerInputs["password"] == "")
            {
                errMsg = "Password must be filled";
            }
            else if (!registerInputs["password"].Equals(registerInputs["confPassword"]))
            {
                errMsg = "Confirm Password must be same with Password";
            }
            else if (registerInputs["gender"] == "")
            {
                errMsg = "Gender must be chosen";
            }

            return errMsg ?? validateEmailUniqueness(registerInputs["email"]);
        }

        private String validateUpdateInput(Dictionary<String, String> updateInputs)
        {
            String errMsg = null;

            if (updateInputs["email"] == "")
            {
                errMsg = "Email must be filled";
            }
            else if (updateInputs["name"] == "")
            {
                errMsg = "Name must be filled";
            }
            else if (updateInputs["gender"] == "")
            {
                errMsg = "Gender must be chosen";
            }

            return errMsg ?? validateEmailUniqueness(updateInputs["email"]);
        }

        private String validateChangePassInput(Dictionary<String, String> changePassInputs)
        {
            String errMsg = null;

            if (changePassInputs["oldPassword"] != changePassInputs["currPassword"])
            {
                errMsg = "Old password must match with the password in database";
            }
            else if (changePassInputs["newPassword"].Length <= 5)
            {
                errMsg = "New password must be longer than 5 characters";
            }
            else if (!changePassInputs["newPassword"].Equals(changePassInputs["confPassword"]))
            {
                errMsg = "Confirm Password must be same with Password";
            }

            return errMsg;
        }

        private String validateUserViewToggle(int userId, int currLoginUserId)
        {
            String errMsg = null;

            if (userId.Equals(0))
            {
                errMsg = "User ID must be filled";
            }
            else
            {
                if (userId.Equals(currLoginUserId))
                {
                    errMsg = "Cannot change your own data";
                }
            }

            return errMsg;
        }

        private String validateEmailUniqueness(String email)
        {
            List<Users> listUsers = getUsers();
            String errMsg = null;

            foreach (Users i in listUsers)
            {
                if (i.Email.Equals(email))
                {
                    errMsg = "Email must be unique";
                    break;
                }
            }

            return errMsg;
        }
    }
}