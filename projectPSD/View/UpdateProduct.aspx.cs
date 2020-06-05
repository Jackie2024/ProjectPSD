using ProjectPSD.Repository;
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
            int stock = toInt(txtStock.Text);
            int price = toInt(txtPrice.Text);
            String targetProductId = Request.QueryString["id"];

            if (name == "")
            {
                labErr.Text = "Name must be filled";
            }
            else if (stock < 1)
            {
                labErr.Text = "Stock must be 1 or more";
            }
            else if (price < 1000 || price % 1000 != 0)
            {
                labErr.Text = "Price must be above 1000 and multiply of 1000";
            }
            else
            {
                ProductRepository.updateProducts(int.Parse(targetProductId), name, stock, price);
                Response.Redirect("ViewProduct.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProduct.aspx");
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