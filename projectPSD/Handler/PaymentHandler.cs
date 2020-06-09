using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace ProjectPSD.Handler
{
    public class PaymentHandler : Page
    {
        private PaymentTypeRepository paymentRepo = new PaymentTypeRepository();

        public String getPaymentTypebyId(String targetId)
        {
            return paymentRepo.getPaymentTypebyId(int.Parse(targetId));
        }

        public List<PaymentTypes> getPaymentType()
        {
            return paymentRepo.getPaymentTypes();
        }

        public void gotoUpdatePaymentType(String paymentTypeId)
        {
            HttpContext.Current.Response.Redirect("UpdatePaymentType.aspx?id=" + paymentTypeId);
        }

        public void deletePaymentType(String paymentTypeId)
        {
            paymentRepo.delPaymentTypes(int.Parse(paymentTypeId));
            HttpContext.Current.Response.Redirect("ViewPaymentType.aspx");
        }

        public void insertPaymentType(String paymentType)
        {
            paymentRepo.insertPaymentTypes(paymentType);
            HttpContext.Current.Response.Redirect("ViewPaymentType.aspx");
        }

        public void updatePaymentType(String targetPaymentId, String paymentType)
        {
            paymentRepo.updatePaymentTypes(int.Parse(targetPaymentId), paymentType);
            HttpContext.Current.Response.Redirect("ViewPaymentType.aspx");
        }
    }
}