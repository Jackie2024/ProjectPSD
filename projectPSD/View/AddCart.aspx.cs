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
        private CartController cartCtrl = new CartController();

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
            string stockString = BoxStock.Text;
            bool isError = false;
            Products p = productCtrl.getProductById(id);

            String message = cartCtrl.validateCart(stock, stockString, p);
            if (message != null) { ErrorMessage.Text = message; isError = true; }

            if (!isError)
            {
                int quantity = int.Parse(BoxStock.Text);
                int userID = (int)Session["userId"];
                Carts cart = CartFactory.Create(userID,quantity, p);
                Carts checkCart = CartRepository.getItemData(userID, id);
                if (checkCart != null)
                {
                    CartRepository.updateCart(userID, id, quantity);
                }
                else
                {
                    CartRepository.insertCart(userID, quantity, p);
                }
                Response.Redirect("ViewCart.aspx");
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

        public void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}