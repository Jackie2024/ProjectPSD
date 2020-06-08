using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class TransactionFactory
    {
        public static HeaderTransactions CreateHeader(int ID)
        {
            return new HeaderTransactions()
            {
                UserID = ID,
                Date = DateTime.Now
            };
        }

        public static DetailTransactions CreateDetail(int headerTransactionId, Carts cart)
        {
            DetailTransactions detailTransaction = new DetailTransactions()
            {
                TransactionID = headerTransactionId,
                ProductID = cart.Products.ID,
                Quantity = cart.Quantity
            };

            return detailTransaction;
        }
    }
}