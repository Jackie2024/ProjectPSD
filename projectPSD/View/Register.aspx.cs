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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text;
            String name = txtName.Text;
            String pass = txtPass.Text;
            String confPass = txtConfPass.Text;
            String gender = radGender.Text;
            List<Users> listUsers = UserRepository.getUsers();

            if (email == ""){
                labErr.Text = "Email must be filled";
            }
            else if (name == ""){
                labErr.Text = "Name must be filled";
            }
            else if (pass == ""){
                labErr.Text = "Password must be filled";
            }
            else if (!pass.Equals(confPass))
            {
                labErr.Text = "Confirm Password must be same with Password";
            }
            else if (gender == "")
            {
                labErr.Text = "Gender must be chosen";
            }
            else
            {
                foreach (Users i in listUsers)
                {
                    if (i.Email.Equals(email))
                    {
                        labErr.Text = "Email must be unique";
                        return;
                    }
                }
                UserRepository.registUser(2, email, name, pass, gender, "Active");
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}