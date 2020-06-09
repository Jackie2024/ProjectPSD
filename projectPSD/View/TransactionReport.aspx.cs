using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectPSD.Controller;
namespace ProjectPSD.View
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransactionsReport newTR = new TransactionsReport();
            CrystalReportViewer1.ReportSource = newTR;
            newTR.SetDataSource(GenerateData(TransactionController.GetTransactions()));
        }

        private DataSet1 GenerateData(List<HeaderTransactions> transactionList)
        {
            DataSet1 newDataset = new DataSet1();
            var htTable = newDataset.HeaderTransactions;
            var dtTable = newDataset.DetailTransactions;
            
            foreach(var ht in transactionList)
            {
                var headerTransactionRow = htTable.NewRow();
                headerTransactionRow["TransactionID"] = ht.ID;
                headerTransactionRow["Name"] = ht.Users.Name;
                headerTransactionRow["PaymentType"] = ht.PaymentTypes.Type;
                headerTransactionRow["Date"] = ht.Date;
                htTable.Rows.Add(headerTransactionRow);

                foreach(var dt in ht.DetailTransactions)
                {
                    var detailTransactionRow = dtTable.NewRow();
                    detailTransactionRow["TransactionID"] = dt.TransactionID;
                    detailTransactionRow["ProductName"] = dt.Products.Name;
                    detailTransactionRow["Quantity"] = dt.Quantity;
                    detailTransactionRow["Price"] = dt.Products.Price;
                    dtTable.Rows.Add(detailTransactionRow);
                }
            }
            return newDataset;
        }

        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}