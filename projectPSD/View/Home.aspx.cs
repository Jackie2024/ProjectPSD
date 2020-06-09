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
    public partial class Home : System.Web.UI.Page
    {
        private ProductController productCtrl = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnViewProfile.Visible = false;
            btnViewUser.Visible = false;
            btnViewPaymentType.Visible = false;
            btnInsertPaymentType.Visible = false;
            btnInsertProduct.Visible = false;
            btnViewProductType.Visible = false;
            btnInsertProductType.Visible = false;
            btnLogout.Visible = false;
            btnViewCart.Visible = false;
            btnTransactionHistory.Visible = false;

            if(Session["name"] == null)
            {
                lblName.Text = "Welcome Guest";
                btnLogin.Visible = true;
                btnViewProfile.Visible = false;
                btnLogout.Visible = false;
                Session["roleId"] = 3;
                Reccomendation.Visible = false;
            }
            else if (Session["roleId"].Equals(1))
            {
                lblName.Text = "Welcome " + Session["name"].ToString();
                btnLogin.Visible = false;
                btnViewProfile.Visible = true;
                btnViewUser.Visible = true;
                btnViewPaymentType.Visible = true;
                btnInsertPaymentType.Visible = true;
                btnInsertProduct.Visible = true;
                btnViewProductType.Visible = true;
                btnInsertProductType.Visible = true;
                btnLogout.Visible = true;
                btnViewCart.Visible = true;
                btnTransactionHistory.Visible = true;
                Reccomendation.Visible = false;
            }
            else
            {
                lblName.Text = "Welcome " + Session["name"].ToString();
                btnLogin.Visible = false;
                btnViewProfile.Visible = true;
                btnLogout.Visible = true;
                btnLogout.Visible = true;
                btnViewCart.Visible = true;
                btnTransactionHistory.Visible = true;
                gridProduct.DataSource = productCtrl.printForMember();
                gridProduct.DataBind();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnViewProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
        }

        protected void btnViewProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProfile.aspx");
        }

        protected void btnViewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewUser.aspx");
        }

        protected void btnViewPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPaymentType.aspx");
        }

        protected void btnInsertPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPaymentType.aspx");
        }

        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");
        }

        protected void btnViewProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductType.aspx");
        }

        protected void btnInsertProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["name"] = null;
            Response.Cookies["cookie"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Clear();
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Home.aspx");
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTransactionHistory.aspx");
        }

        protected void gridProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}