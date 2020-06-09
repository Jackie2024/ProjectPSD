using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class UpdateCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["name"] == null || Convert.ToInt32(Session["roleId"]) == 1)
            {
                Response.Redirect("Login.aspx");
            }

            String GetProductID = Request.QueryString["id"];

            productGdv.DataSource = CartController.generateProductData(Int32.Parse(GetProductID));
            productGdv.DataBind();

        }

        protected void BackViewCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void UpdateCartBtn_Click(object sender, EventArgs e)
        {
            int quantity = Int32.Parse(NewQuantityBox.Text);


        }
    }
}