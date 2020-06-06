using ProjectPSD.Controller;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPSD.View
{
    public partial class ViewTransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("login.aspx");
            } else
            {
                int trId = Convert.ToInt32(Request.QueryString["id"]);

                setLabelText(trId);
                TransactionDetailGridView.DataSource = getTransactionDetails(Convert.ToInt32(Request.QueryString["id"]));
                TransactionDetailGridView.DataBind();
            }
        }

        private void setLabelText(int transactionId)
        {
            HeaderTransactions htr = TransactionController.getHeaderTransactionById(transactionId);
            trIdLabel.Text += transactionId;
            trDateLabel.Text += htr.Date.ToString("dd/MM/yyyy");
            trPaymentLabel.Text += htr.PaymentTypes.Type;
        }

        private List<Object> getTransactionDetails(int transactionId)
        {
            return TransactionController.getTransactionDetails(transactionId);
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTransactionHistory.aspx");
        }
    }
}