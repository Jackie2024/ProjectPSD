using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class UpdatePaymentType : System.Web.UI.Page
    {
        private PaymentController paymentCtrl = new PaymentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }

            String targetPaymentId = Request.QueryString["id"];
            labType.Text = paymentCtrl.getPaymentTypebyId(targetPaymentId);
        }

        protected void btnUpdatePaymentType_Click(object sender, EventArgs e)
        {
            String paymentType = txtPaymentType.Text;
            String targetPaymentId = Request.QueryString["id"];
            String errMsg = paymentCtrl.updateAttempt(targetPaymentId, paymentType);

            if (errMsg != null) labErr.Text = errMsg;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPaymentType.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}