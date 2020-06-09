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
            return db.HeaderTransactions.Where(htr => htr.ID == transactionId).FirstOrDefault();
        }

        public static HeaderTransactions InsertHeaderTransaction(HeaderTransactions headerTransaction)
        {
            using (DatabaseEnt db = new DatabaseEnt())
            {
                db.HeaderTransactions.Add(headerTransaction);
                db.SaveChanges();

                return headerTransaction;
            }
        }

        public static DetailTransactions InsertDetailTransaction(DetailTransactions detailTransaction)
        {
            DatabaseEnt db = new DatabaseEnt();
            db.DetailTransactions.Add(detailTransaction);
            db.SaveChanges();

            int productId = detailTransaction.ProductID;
            int quantity = detailTransaction.Quantity;
            ProductRepository.decreaseStock(productId, quantity);

            return detailTransaction;
        }

        public static List<HeaderTransactions> FindByUsername(int ID)
        {
            using (DatabaseEnt db = new DatabaseEnt())
            {
                db.Configuration.ProxyCreationEnabled = false;

                return db.HeaderTransactions.Where(x => x.ID == ID)
                    .Select(x => x)
                    .ToList();
            }
        }

        public static List<DetailTransactions> FindDetailByTransactionId(int transactionId)
        {
            using (DatabaseEnt db = new DatabaseEnt())
            {
                db.Configuration.ProxyCreationEnabled = false;

                return db.DetailTransactions.
                    Where(x => x.TransactionID == transactionId)
                    .Select(x => x)
                    .ToList();
            }
        }

        public static List<HeaderTransactions> GetTransactions()
        {
            return db.HeaderTransactions.ToList();
        }
    }
}