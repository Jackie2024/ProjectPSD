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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private AccountController accountCtrl = new AccountController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            txtEmail.Attributes.Add("placeholder", (String)Session["email"]);
            txtName.Attributes.Add("placeholder", (String)Session["name"]);
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> updateInputs = extractRegInput();
            String errMsg = accountCtrl.updateUserProfile((int)Session["userId"] ,updateInputs);

            if (errMsg != null)
            {
                labErr.Text = errMsg;
            }
            else
            {
                Response.Redirect("ViewProfile.aspx");
            }
        }

        private Dictionary<String, String> extractRegInput()
        {
            Dictionary<string, string> registerInputs = new Dictionary<string, string>();
            registerInputs.Add("email", txtEmail.Text);
            registerInputs.Add("name", txtName.Text);
            registerInputs.Add("gender", radGender.Text);

            return registerInputs;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProfile.aspx");
        }
    }
}