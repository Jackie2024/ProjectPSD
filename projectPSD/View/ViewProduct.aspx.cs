using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        private ProductController productCtrl = new ProductController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            if (!Session["roleId"].Equals(1))
            {
                txtProductId.Visible = false;
                labPro.Visible = false;
                btnInsertProduct.Visible = false;
                btnUpdateProduct.Visible = false;
                btnDeleteProduct.Visible = false;
            }
            gridProduct.DataSource = productCtrl.print();
            gridProduct.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProduct.aspx");
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            String productId = txtProductId.Text;
            String errMsg = productCtrl.gotoUpdateAttempt(productId);

            if (errMsg != null) labErr.Text = errMsg;
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            String productId = txtProductId.Text;
            String errMsg = productCtrl.deleteAttempt(productId);

            if (errMsg != null) labErr.Text = errMsg;
        }

        protected void lbRedirect_Click (object sender, EventArgs e)
        {
            int id = Int32.Parse((sender as LinkButton).CommandArgument);
            Response.Redirect("AddCart.aspx?id=" + id);
        }

        protected void gridProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}