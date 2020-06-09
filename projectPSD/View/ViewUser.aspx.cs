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
    public partial class ViewUser : System.Web.UI.Page
    {
        private AccountController accountCtrl = new AccountController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int role = Int32.Parse(Session["roleId"].ToString());

                if (Session["name"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else if (role == 2 || role == 3)
                {
                    Response.Redirect("Home.aspx");
                }

                if (!Page.IsPostBack)
                {
                    List<Users> listUsers = accountCtrl.getUsers();
                    gridUser.DataSource = listUsers;
                    gridUser.DataBind();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnToggleRole_Click(object sender, EventArgs e)
        {
            int userId = toInt(txtUserId.Text);
            String errMsg = accountCtrl.toggleUserRole(userId, (int)Session["userId"]);

            if(errMsg != null)
            {
                labErr.Text = errMsg;
            }
            else
            {
                Response.Redirect("ViewUser.aspx");
            }
        }

        protected void btnToggleStatus_Click(object sender, EventArgs e)
        {
            int userId = toInt(txtUserId.Text);

            String errMsg = accountCtrl.toggleUserStatus(userId, (int)Session["userId"]);

            if (errMsg != null)
            {
                labErr.Text = errMsg;
            }
            else
            {
                Response.Redirect("ViewUser.aspx");
            }
        }

        protected int toInt(String s)
        {
            int number;
            bool isParsable = Int32.TryParse(s, out number);
            if (isParsable)
                return (number);
            else
                return (0);
        }
    }
}