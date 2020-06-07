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

        public String loginAttempt(String email, String password)
        {
            String errMsg = validateInput(email, password);

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

        private String validateInput(String email, String password)
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
    }
}