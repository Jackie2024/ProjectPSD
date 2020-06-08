using ProjectPSD.Controller;
using ProjectPSD.Handler;
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
    public partial class ViewCart : System.Web.UI.Page
    {
        protected static List<Carts> carts = new List<Carts>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            carts = (List<Carts>)Session["cart"];
        }

        protected void onUpdate_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            Response.Redirect("UpdateCart.aspx?id=" + id);
        }

        protected void onDelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            //ProductRepository.deleteProduct(id);
            //<%= ((double)carts.Sum(x => x.Product.price * x.Quantity)).ToString("C")
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["userId"].ToString());
            if (carts.Count() < 1)
            {

            }
            TransactionController.CheckOut(userId, carts);
            Response.Redirect("Home.aspx");
        }
    }
}