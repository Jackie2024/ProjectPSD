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
    public partial class ViewProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProductTypes> listObject = ProductTypeRepository.getProductTypes();
            gridProduct.DataSource = listObject;
            gridProduct.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnInsertProductType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProductType.aspx");
        }

        protected void btnUpdateProductType_Click(object sender, EventArgs e)
        {
            String productTypeId = txtProductTypeId.Text;
            List<ProductTypes> listProducts = ProductTypeRepository.getProductTypes();

            if (productTypeId == "")
            {
                labErr.Text = "Product Type ID must be filled";
            }
            else
            {
                foreach (ProductTypes i in listProducts)
                {
                    if (i.ID.Equals(int.Parse(txtProductTypeId.Text)))
                    {
                        Response.Redirect("UpdateProductType.aspx?id=" + productTypeId);
                    }
                }
                labErr.Text = "Product Type ID must be exist";
            }
        }

        protected void btnDeleteProductType_Click(object sender, EventArgs e)
        {
            String productTypeId = txtProductTypeId.Text;
            List<ProductTypes> listProducts = ProductTypeRepository.getProductTypes();

            if (productTypeId == "")
            {
                labErr.Text = "Product Type ID must be filled";
            }
            else
            {
                foreach (ProductTypes i in listProducts)
                {
                    if (i.ID.Equals(int.Parse(txtProductTypeId.Text)))
                    {
                        ProductTypeRepository.delProductTypes(i.ID);
                        Response.Redirect("ViewProductType.aspx");
                    }
                }
                labErr.Text = "Product Type ID must be exist";
            }
        }
    }
}