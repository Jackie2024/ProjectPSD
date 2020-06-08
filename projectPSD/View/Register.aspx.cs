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
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Register Jalan" + "')", true);

            String errMsg = accountCtrl.registerNewMember(registerInputs);

            if (errMsg != null)
            {
                labErr.Text = errMsg;
            }
            else
            {
                Response.Redirect("Login.aspx");
            };

            //List<Users> listUsers = UserRepository.getUsers();

            //if (email == ""){
            //    labErr.Text = "Email must be filled";
            //}
            //else if (name == ""){
            //    labErr.Text = "Name must be filled";
            //}
            //else if (pass == ""){
            //    labErr.Text = "Password must be filled";
            //}
            //else if (!pass.Equals(confPass))
            //{
            //    labErr.Text = "Confirm Password must be same with Password";
            //}
            //else if (gender == "")
            //{
            //    labErr.Text = "Gender must be chosen";
            //}
            //else
            //{
            //    foreach (Users i in listUsers)
            //    {
            //        if (i.Email.Equals(email))
            //        {
            //            labErr.Text = "Email must be unique";
            //            return;
            //        }
            //    }
            //    UserRepository.registUser(2, email, name, pass, gender, "Active");
            //    Response.Redirect("Login.aspx");
            //}
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