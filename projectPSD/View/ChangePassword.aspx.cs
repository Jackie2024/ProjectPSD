using ProjectPSD.Controller;
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
        private AccountController accountCtrl = new AccountController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> changePassInputs = extractChangePassInput((int)Session["userId"]);
            String errMsg = accountCtrl.changeUserPassword((int)Session["userId"], changePassInputs);

            if(errMsg != null)
            {
                labErr.Text = errMsg;
            }
            else
            {
                Response.Redirect("ViewProfile.aspx");
            }
        }

        private Dictionary<String, String> extractChangePassInput(int userId)
        {
            Dictionary<string, string> changePassInputs = new Dictionary<string, string>();
            changePassInputs.Add("oldPassword", txtOldPassword.Text);
            changePassInputs.Add("newPassword", txtNewPassword.Text);
            changePassInputs.Add("confPassword", txtConfirmPassword.Text);
            changePassInputs.Add("currPassword", accountCtrl.getPassById(userId));

            return changePassInputs;
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProfile.aspx");
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}