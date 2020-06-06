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
    }
}