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
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            if (Session["roleId"].Equals(1))
            {
               
                gridProduct.DataSource = ProductRepository.print();
                gridProduct.DataBind();
            }
            else
            {
                txtProductId.Visible = false;
                labPro.Visible = false;
                btnInsertProduct.Visible = false;
                btnUpdateProduct.Visible = false;
                btnDeleteProduct.Visible = false;

                gridProduct.DataSource = ProductRepository.printForMember();
                gridProduct.DataBind();
            }
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
            List<Products> listProducts = ProductRepository.getProducts();

            if (productId == "")
            {
                labErr.Text = "Product ID must be filled";
            }
            else
            {
                foreach (Products i in listProducts)
                {
                    if (i.ID.Equals(int.Parse(txtProductId.Text)))
                    {
                        Response.Redirect("UpdateProduct.aspx?id=" + productId);
                    }
                }
                labErr.Text = "Product ID must be exist";
            }
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            String productId = txtProductId.Text;
            List<Products> listProducts = ProductRepository.getProducts();

            if (productId == "")
            {
                labErr.Text = "Product ID must be filled";
            }
            else
            {
                foreach (Products i in listProducts)
                {
                    if (i.ID.Equals(int.Parse(txtProductId.Text)))
                    {
                        ProductRepository.delProducts(i.ID);
                        Response.Redirect("ViewProduct.aspx");
                    }
                }
                labErr.Text = "Product ID must be exist";
            }
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