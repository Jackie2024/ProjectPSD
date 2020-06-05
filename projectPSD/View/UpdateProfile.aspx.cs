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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            txtEmail.Attributes.Add("placeholder", (String)Session["email"]);
            txtName.Attributes.Add("placeholder", (String)Session["name"]);
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text;
            String name = txtName.Text;
            String gender = radGender.Text;
            List<Users> listUsers = UserRepository.getUsers();

            if (email == "")
            {
                labErr.Text = "Email must be filled";
            }
            else if (name == "")
            {
                labErr.Text = "Name must be filled";
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
                UserRepository.updateUsers((int)Session["userId"], email, name, gender);
                Session["email"] = email;
                Session["name"] = name;                
                Session["gender"] = gender;
                Response.Redirect("ViewProfile.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProfile.aspx");
        }
    }
}