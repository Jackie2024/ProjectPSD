using ProjectPSD.Controller;
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
        private ProductTypeController productTypeCtrl = new ProductTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }
            gridProduct.DataSource = productTypeCtrl.getProductType();
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
            String errMsg = productTypeCtrl.gotoUpdateAttempt(productTypeId);

            if (errMsg != null) labErr.Text = errMsg;
        }

        protected void btnDeleteProductType_Click(object sender, EventArgs e)
        {
            String productTypeId = txtProductTypeId.Text;
            String errMsg = productTypeCtrl.deleteAttempt(productTypeId);

            if (errMsg != null) labErr.Text = errMsg;
        }
    }
}