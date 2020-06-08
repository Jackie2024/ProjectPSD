using ProjectPSD.Controller;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class AddCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            int id = Int32.Parse(Request.QueryString["id"]);

            Products p = ProductController.getProductById(id);
            ProductName.Text = p.Name;
            ProductPrice.Text = p.Price.ToString();
            ProductStock.Text = p.Stock.ToString();
            ProductType.Text = p.ProductTypeID.ToString();
        }

        protected void addToCart_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.QueryString["id"]);
            int stock = toInt(BoxStock.Text);
            int myInt;
            Products p = ProductController.getProductById(id);

            string stockString = BoxStock.Text;
            bool isNumerical = int.TryParse(stockString, out myInt);
            if (stock < 1)
            {
                ErrorMessage.Text = "Stock Must be more than 0";
            }
            else if (stock > p.Stock)
            {
                ErrorMessage.Text = "Stock must be less than or equals to current stock";
            }
            else if (!isNumerical)
            {
                ErrorMessage.Text = "Input must be numeric";
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