using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;

namespace ProjectPSD.Controller
{
    public class PaymentController
    {
        private PaymentHandler paymentHdlr = new PaymentHandler();

        public String getPaymentTypebyId(String targetId)
        {
            return paymentHdlr.getPaymentTypebyId(targetId);
        }
        public List<PaymentTypes> getPaymentType()
        {
            return paymentHdlr.getPaymentType();
        }

        public String gotoUpdateAttempt(String targetId)
        {
            String errMsg = validateInputId(targetId);

            if (errMsg == null)
            {
                List<PaymentTypes> listPaymentTypes = paymentHdlr.getPaymentType();
                errMsg = validatePaymentTypeId(targetId, listPaymentTypes);
                if (errMsg == null)
                {
                    paymentHdlr.gotoUpdatePaymentType(targetId);
                    return errMsg;
                };
            }

            return errMsg;
        }

        public String deleteAttempt(String targetId)
        {
            String errMsg = validateInputId(targetId);

            if (errMsg == null)
            {
                List<PaymentTypes> listPaymentTypes = paymentHdlr.getPaymentType();
                errMsg = validatePaymentTypeId(targetId, listPaymentTypes);
                if (errMsg == null)
                {
                    paymentHdlr.deletePaymentType(targetId);
                    return errMsg;
                };
            }

            return errMsg;
        }

        public String insertAttempt(String paymentType)
        {
            String errMsg = validateInput(paymentType);

            if (errMsg == null)
            {
                List<PaymentTypes> listPaymentTypes = paymentHdlr.getPaymentType();
                errMsg = validatePaymentType(paymentType, listPaymentTypes);
                if (errMsg == null)
                {
                    paymentHdlr.insertPaymentType(paymentType);
                    return errMsg;
                };
            }

            return errMsg;
        }

        public String updateAttempt(String targetId, String paymentType)
        {
            String errMsg = validateInput(paymentType);

            if (errMsg == null)
            {
                List<PaymentTypes> listPaymentTypes = paymentHdlr.getPaymentType();
                errMsg = validatePaymentType(paymentType, listPaymentTypes);
                if (errMsg == null)
                {
                    paymentHdlr.updatePaymentType(targetId, paymentType);
                    return errMsg;
                };
            }

            return errMsg;
        }

        private String validateInputId(String targetId)
        {
            String errMsg = null;

            if (targetId == "")
            {
                errMsg = "Payment Type ID must be filled";
            }

            return errMsg;
        }

        private String validatePaymentTypeId(String targetId, List<PaymentTypes> listPaymentTypes)
        {
            String errMsg = null;

            foreach (PaymentTypes i in listPaymentTypes)
            {
                if (i.ID.Equals(int.Parse(targetId)))
                {
                    errMsg = null;
                    return errMsg;
                }
            }
            errMsg = "Payment Type ID must be exist";

            return errMsg;
        }

        private String validateInput(String paymentType)
        {
            String errMsg = null;

            if (paymentType == "")
            {
                errMsg = "Payment type must be filled";
            }
            else if (paymentType.Length < 3)
            {
                errMsg = "Payment type must consist of 3 characters or more";
            }

            return errMsg;
        }

        private String validatePaymentType(String paymentType, List<PaymentTypes> listPaymentTypes)
        {
            String errMsg = null;

            foreach (PaymentTypes i in listPaymentTypes)
            {
                if (i.Type.Equals(paymentType))
                {
                    errMsg = "Payment type must be unique";
                    return errMsg;
                }
            }

            return errMsg;
        }
    }
}