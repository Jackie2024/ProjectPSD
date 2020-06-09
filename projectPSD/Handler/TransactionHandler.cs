using ProjectPSD.Factory;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class TransactionHandler
    {
        public static void Checkout(int userId, int paymentTypeID, List<Carts> carts)
        {
            HeaderTransactions headerTransaction = TransactionFactory.CreateHeader(userId, paymentTypeID);
            int headerTransactionId = TransactionRepository.InsertHeaderTransaction(headerTransaction).ID;

            foreach (var item in carts)
            {
                DetailTransactions detailTransaction = TransactionFactory.CreateDetail(headerTransactionId, item);
                TransactionRepository.InsertDetailTransaction(detailTransaction);
            }
        }

        public static List<Object> getCurrUserTransactions(int userId)
        {
            return TransactionRepository.getCurrUserTransactions(userId);
        }

        public static List<Object> getAllUserTransactions()
        {
            return TransactionRepository.getAllUserTransactions();
        }

        public static List<Object> getTransactionDetails(int transactionId)
        {
            return TransactionRepository.getTransactionDetails(transactionId);
        }

        public static HeaderTransactions getHeaderTransactionById(int transactionId)
        {
            return TransactionRepository.getHeaderTransactionById(transactionId);
        }

        public static List<HeaderTransactions> GetTransactions()
        {
            return TransactionRepository.GetTransactions();
        }
    }
}