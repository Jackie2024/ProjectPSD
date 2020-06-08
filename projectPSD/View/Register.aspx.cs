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
    public partial class Register : System.Web.UI.Page
    {
        private AccountController accountCtrl = new AccountController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> registerInputs = extractRegInput();
            String errMsg = accountCtrl.registerNewMember(registerInputs);

            if (errMsg != null)
            {
                labErr.Text = errMsg;
            }
            else
            {
                Response.Redirect("Login.aspx");
            };
        }

        private Dictionary<String, String> extractRegInput()
        {
            Dictionary < string, string> registerInputs= new Dictionary<string, string>();
            registerInputs.Add("email", txtEmail.Text);
            registerInputs.Add("name", txtName.Text);
            registerInputs.Add("password", txtPass.Text);
            registerInputs.Add("confPassword", txtConfPass.Text);
            registerInputs.Add("gender", radGender.Text);

            return registerInputs;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}