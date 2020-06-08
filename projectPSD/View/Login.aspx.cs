using ProjectPSD.Controller;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class Login : System.Web.UI.Page
    {

        private AccountController accountCtrl = new AccountController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["email"] != null && Request.Cookies["pass"] != null)
                {
                    txtEmail.Text = Request.Cookies["email"].Value;
                    txtPass.Attributes["value"] = Request.Cookies["pass"].Value;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text;
            String pass = txtPass.Text;
            String errMsg = accountCtrl.loginAttempt(email, pass);

            if (errMsg != null) labErr.Text = errMsg;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnRememberMe(object sender, EventArgs e)
        {
            Boolean isChecked = cheRemember.Checked;
            accountCtrl.toggleRemeberMe(isChecked, txtEmail.Text.Trim(), txtPass.Text.Trim());
        }
    }
}