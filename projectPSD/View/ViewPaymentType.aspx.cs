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
    public partial class ViewPaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }
            List<PaymentTypes> listObject = PaymentTypeRepository.getPaymentTypes();
            gridPayment.DataSource = listObject;
            gridPayment.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnInsertPaymentType_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPaymentType.aspx");
        }

        protected void btnUpdatePaymentType_Click(object sender, EventArgs e)
        {
            String paymentTypeId = txtPaymentTypeId.Text;
            List<PaymentTypes> listProducts = PaymentTypeRepository.getPaymentTypes();

            if (paymentTypeId == "")
            {
                labErr.Text = "Payment Type ID must be filled";
            }
            else
            {
                foreach (PaymentTypes i in listProducts)
                {
                    if (i.ID.Equals(int.Parse(txtPaymentTypeId.Text)))
                    {
                        Response.Redirect("UpdatePaymentType.aspx?id=" + paymentTypeId);
                    }
                }
                labErr.Text = "Payment Type ID must be exist";
            }
        }
        
        protected void btnDeletePaymentType_Click(object sender, EventArgs e)
        {
            String paymentTypeId = txtPaymentTypeId.Text;
            List<PaymentTypes> listPayments = PaymentTypeRepository.getPaymentTypes();

            if (paymentTypeId == "")
            {
                labErr.Text = "Payment Type ID must be filled";
            }
            else
            {
                foreach (PaymentTypes i in listPayments)
                {
                    if (i.ID.Equals(int.Parse(txtPaymentTypeId.Text)))
                    {
                        PaymentTypeRepository.delPaymentTypes(i.ID);
                        Response.Redirect("ViewPaymentType.aspx");
                    }
                }
                labErr.Text = "Payment Type ID must be exist";
            }
        }
    }
}