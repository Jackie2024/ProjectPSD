using ProjectPSD.Controller;
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
        private ProductTypeController productTypeCtrl = new ProductTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }
        }
        protected void btnInsertProductType_Click(object sender, EventArgs e)
        {
            String productType = txtProductType.Text;
            String desc = txtDescription.Text;
            String errMsg = productTypeCtrl.insertAttempt(productType, desc);

            if (errMsg != null) labErr.Text = errMsg;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductType.aspx");
        }
    }
}