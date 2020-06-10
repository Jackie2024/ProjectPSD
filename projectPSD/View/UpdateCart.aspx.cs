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
    public partial class UpdateCart : System.Web.UI.Page
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["name"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            String GetProductID = Request.QueryString["id"];
            id = Convert.ToInt32(GetProductID); 
            productGdv.DataSource = CartController.generateProductData(Int32.Parse(GetProductID));
            productGdv.DataBind();

        }


        protected void BackViewCartBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCart.aspx");
        }

        protected void UpdateCartBtn_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            p = CartController.getProductByID(id);
            int quantity = Int32.Parse(NewQuantityBox.Text);
            
            
            int stock = p.Stock;
            String Notvalid = CartController.updateValidation(quantity, stock, p.ID);

            if (!Notvalid.Equals(""))
            {
                ErrorMsg.Text = Notvalid;
            }else if(quantity == 0)
            {
                //delete
                int userId = Convert.ToInt32(Session["userId"].ToString());
                CartRepository.deleteItem(userId, p.ID);
                Response.Redirect("ViewCart.aspx");

            }
            else
            {
                int userId = Convert.ToInt32(Session["userId"].ToString());
                CartRepository.updateCarts(userId, p.ID, quantity);
                Response.Redirect("ViewCart.aspx");
            }

        }
    }
}