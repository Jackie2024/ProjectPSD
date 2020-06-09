using ProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        private PaymentController paymentCtrl = new PaymentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }
            gridPayment.DataSource = paymentCtrl.getPaymentType();
            gridPayment.DataBind();
        }

        protected void btnInsertPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPaymentType.aspx");
        }

        protected void btnUpdatePaymentType_Click(object sender, EventArgs e)
        {
            String paymentTypeId = txtPaymentTypeId.Text;
            String errMsg = paymentCtrl.gotoUpdateAttempt(paymentTypeId);

            if (errMsg != null) labErr.Text = errMsg;
        }
        
        protected void btnDeletePaymentType_Click(object sender, EventArgs e)
        {
            String paymentTypeId = txtPaymentTypeId.Text;
            String errMsg = paymentCtrl.deleteAttempt(paymentTypeId);

            if (errMsg != null) labErr.Text = errMsg;
        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}