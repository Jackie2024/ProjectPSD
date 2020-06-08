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
            Dictionary<String, String> updateInputs = extractUpdateInput();
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

        private Dictionary<String, String> extractUpdateInput()
        {
            Dictionary<string, string> updateInputs = new Dictionary<string, string>();
            updateInputs.Add("email", txtEmail.Text);
            updateInputs.Add("name", txtName.Text);
            updateInputs.Add("gender", radGender.Text);

            return updateInputs;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProfile.aspx");
        }
    }
}