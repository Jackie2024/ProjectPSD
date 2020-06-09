using ProjectPSD.Factory;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class PaymentTypeRepository
    {
        private static DatabaseEnt db = new DatabaseEnt();

        public List<PaymentTypes> getPaymentTypes()
        {
            return (from i in db.PaymentTypes
                    select i).ToList();
        }

        public String getPaymentTypebyId(int targetId)
        {
            PaymentTypes p = (from i in db.PaymentTypes
                              where i.ID == targetId
                              select i).FirstOrDefault();
            return p.Type;
        }

        public void delPaymentTypes(int targetId)
        {
            PaymentTypes p = (from i in db.PaymentTypes
                              where i.ID == targetId
                              select i).FirstOrDefault();

            db.PaymentTypes.Remove(p);
            db.SaveChanges();
        }

        public void updatePaymentTypes(int targetId, String paymentType)
        {
            PaymentTypes p = (from i in db.PaymentTypes
                              where i.ID == targetId
                              select i).FirstOrDefault();
            p.Type = paymentType;
            db.SaveChanges();
        }

        public void insertPaymentTypes(String paymentType)
        {
            PaymentTypes p = PaymentTypeFactory.createPaymentType(paymentType);

            db.PaymentTypes.Add(p);
            db.SaveChanges();
        }
    }
}