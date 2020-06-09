using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class UpdateProductType : System.Web.UI.Page
    {
        private ProductTypeController productTypeCtrl = new ProductTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }

            String targetProductId = Request.QueryString["id"];
            labType.Text = productTypeCtrl.getProductTypebyId(targetProductId);
            labDesc.Text = productTypeCtrl.getDescbyId(targetProductId);
        }

        protected void btnUpdateProductType_Click(object sender, EventArgs e)
        {
            String productType = txtProductType.Text;
            String desc = txtDescription.Text;
            String targetProductId = Request.QueryString["id"];
            String errMsg = productTypeCtrl.updateAttempt(targetProductId, productType, desc);

            if (errMsg != null) labErr.Text = errMsg;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductType.aspx");
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}