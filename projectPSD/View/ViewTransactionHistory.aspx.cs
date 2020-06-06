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
    public partial class ViewTransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                TransactionGridView.DataSource = TransactionController.generateTransactionData((int)Session["userId"], (int)Session["roleId"]);
                TransactionGridView.DataBind();

                if ((int)Session["roleId"] == 2) viewTransactionReportBtn.Visible = false;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        public void onClickViewTransactionDetailBtn(Object sender, EventArgs e)
        {
            Button viewDetailTrBtn = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)viewDetailTrBtn.NamingContainer;
            string transactionId = TransactionGridView.Rows[selectedRow.RowIndex].Cells[1].Text;

            Response.Redirect("ViewTransactionDetail.aspx" + "?id=" + transactionId);
        }

        public void onClickViewTransactionReportBtn(Object sender, EventArgs e)
        {
            //TODO Add redirect destination
            Response.Redirect("");
        }
    }
}