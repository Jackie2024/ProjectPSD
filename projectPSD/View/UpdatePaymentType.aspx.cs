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
    public partial class UpdatePaymentType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int role = Int32.Parse(Session["roleId"].ToString());
            if (Session["name"] == null) { Response.Redirect("Login.aspx"); }
            else if (role == 2 || role == 3) { Response.Redirect("Home.aspx"); }
        }

        protected void btnUpdatePaymentType_Click(object sender, EventArgs e)
        {
            String paymentType = txtPaymentType.Text;
            String targetPaymentId = Request.QueryString["id"];
            List<PaymentTypes> listPaymentTypes = PaymentTypeRepository.getPaymentTypes();

            if (paymentType == "")
            {
                labErr.Text = "Payment type must be filled";
            }
            else if (paymentType.Length < 3)
            {
                labErr.Text = "Payment type must consist of 3 characters or more";
            }
            else
            {
                foreach (PaymentTypes i in listPaymentTypes)
                {
                    if (i.Type.Equals(paymentType))
                    {
                        labErr.Text = "Payment type must be unique";
                        return;
                    }
                }
                PaymentTypeRepository.updatePaymentTypes(int.Parse(targetPaymentId), paymentType);
                Response.Redirect("ViewPaymentType.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPaymentType.aspx");
        }
    }
}