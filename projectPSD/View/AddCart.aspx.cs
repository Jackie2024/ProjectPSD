using ProjectPSD.Controller;
using ProjectPSD.Factory;
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
    public partial class AddCart : System.Web.UI.Page
    {
        protected static Products product;

        private ProductController productCtrl = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
                int id = Int32.Parse(Request.QueryString["id"]);
                Products p = productCtrl.getProductById(id);
                ProductName.Text = p.Name;
                ProductPrice.Text = p.Price.ToString();
                ProductStock.Text = p.Stock.ToString();
                ProductType.Text = p.ProductTypeID.ToString();
            }
        }

        protected void addToCart_Click(object sender, EventArgs e)
        {
            List<Carts> carts = new List<Carts>();
            int id = Int32.Parse(Request.QueryString["id"]);
            int stock = toInt(BoxStock.Text);
            int myInt;
            bool isError = false;
            Products p = productCtrl.getProductById(id);

            string stockString = BoxStock.Text;
            bool isNumerical = int.TryParse(stockString, out myInt);

            if (!isNumerical)
            {
                ErrorMessage.Text = "Input must be numeric";
                isError = true;
            }
            else if (stock < 1)
            {
                ErrorMessage.Text = "Stock Must be more than 0";
                isError = true;
            }
            else if (stock > p.Stock)
            {
                ErrorMessage.Text = "Stock must be less than or equals to current stock";
                isError = true;
            }

            if (!isError)
            {
               
                Carts cart = CartFactory.Create(int.Parse(BoxStock.Text), p);
                CartRepository.insertCart(cart);
            }

            /*if (Session["cart"] != null) {
                carts = (List<Carts>)Session["cart"];
                foreach (Carts item in carts) {
                    if (item.Products == product) {
                        item.Quantity += int.Parse(BoxStock.Text);
                        isExist = true;
                        break;
                    }
                }
            }

            if (!isExist || Session["cart"] == null) {
                Carts cart = CartFactory.Create(int.Parse(BoxStock.Text), product);
                carts.Add(cart);
            }
            */
            Response.Redirect("Home.aspx");

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