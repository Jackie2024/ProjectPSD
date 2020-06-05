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
            Users u = UserRepository.getLogin(email, pass);

            if (email == "")
            {
                labErr.Text = "Email must be filled";
            }
            else if (pass == "")
            {
                labErr.Text = "Password must be filled";
            }
            else if (u == null)
            {
                labErr.Text = "User not found";
            }
            else if (u.Status == "Blocked")
            {
                labErr.Text = "User has been blocked";
            }
            else
            {
                Session["name"] = u.Name;
                Session["roleId"] = u.RoleID;
                Session["userId"] = u.ID;
                Session["email"] = u.Email;
                Session["gender"] = u.Gender;
                Response.Redirect("Home.aspx");
            }
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
            if (cheRemember.Checked == true)
            {
                Response.Cookies["email"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["pass"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies["email"].Value = txtEmail.Text.Trim();
            Response.Cookies["pass"].Value = txtPass.Text.Trim();
        }
    }
}