using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class TransactionRepository
    {

        private static DatabaseEnt db = new DatabaseEnt();

        public static List<Object> getCurrUserTransactions(int userId)
        {
            return db.HeaderTransactions.Where(x => x.UserID == userId)
                .Select(
                htr => new {
                    htr.ID,
                    PaymentType = htr.PaymentTypes.Type,
                    Date = htr.Date
                }).ToList<Object>();
        }

        public static List<Object> getAllUserTransactions()
        {
            return db.HeaderTransactions
                .Select(
                htr => new {
                    htr.ID,
                    PaymentType = htr.PaymentTypes.Type,
                    Date = htr.Date
                }).ToList<Object>();
        }

        public static List<Object> getTransactionDetails(int transactionId)
        {
            return db.DetailTransactions.Where(dtr => dtr.TransactionID == transactionId)
                .Select(dtr => new {
                    ProductName = dtr.Products.Name,
                    ProductQuantity = dtr.Quantity,
                    Subtotal = dtr.Products.Price * dtr.Quantity
                }).ToList<Object>();
        }

        public static HeaderTransactions getHeaderTransactionById(int transactionId)
        {
            return db.HeaderTransactions.Where(htr => htr.ID == transactionId).First();
        }
    }
}