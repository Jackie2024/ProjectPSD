using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        private ProductController productCtrl = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }

            String targetProductId = Request.QueryString["id"];
            labProductId.Text = targetProductId;
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String stockText = txtStock.Text;
            String priceText = txtPrice.Text;
            String targetProductId = Request.QueryString["id"];
            String errMsg = productCtrl.updateAttempt(targetProductId, name, stockText, priceText);

            if (errMsg != null) labErr.Text = errMsg;
            }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
        }
    }
}