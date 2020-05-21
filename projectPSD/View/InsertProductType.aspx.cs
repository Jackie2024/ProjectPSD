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
    public partial class InsertProductType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnInsertProductType_Click(object sender, EventArgs e)
        {
            String productType = txtProductType.Text;
            String desc = txtDescription.Text;
            List<ProductTypes> listProductTypes = ProductTypeRepository.getProductTypes();

            if (productType == "")
            {
                labErr.Text = "Product type must be filled";
            }
            else if (productType.Length < 5)
            {
                labErr.Text = "Product type must consist of 5 characters or more";
            }
            else if (desc == "")
            {
                labErr.Text = "Description must be filled";
            }
            else
            {
                foreach (ProductTypes i in listProductTypes)
                {
                    if (i.Name.Equals(productType))
                    {
                        labErr.Text = "Product type must be unique";
                        return;
                    }
                }
                ProductTypeRepository.insertProductTypes(productType, desc);
                Response.Redirect("ViewProductType.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductType.aspx");
        }
    }
}