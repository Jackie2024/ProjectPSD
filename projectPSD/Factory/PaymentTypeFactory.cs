using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class PaymentTypeFactory
    {
        public static PaymentTypes createPaymentType(String paymentType)
        {
            return new PaymentTypes()
            {
                Type = paymentType
            };
        }
    }
}