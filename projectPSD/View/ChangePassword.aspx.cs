using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            String oldPass = txtOldPassword.Text;
            String newPass = txtNewPassword.Text;
            String confPass = txtConfirmPassword.Text;
            String currPass = UserRepository.getPassById((int)Session["userId"]);
            
            if(oldPass != currPass)
            {
                labErr.Text = "Old password must match with the password in database";
            }
            else if (newPass.Length <= 5)
            {
                labErr.Text = "New password must be longer than 5 characters";
            }
            else if (!newPass.Equals(confPass))
            {
                labErr.Text = "Confirm Password must be same with Password";
            }
            else
            {
                UserRepository.updatePass((int)Session["userId"], newPass);
                Response.Redirect("ViewProfile.aspx");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProfile.aspx");
        }
    }
}