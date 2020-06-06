using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class TransactionController
    {
        public static List<Object> getTransactionDetails(int transactionId)
        {
            return TransactionHandler.getTransactionDetails(transactionId);
        }

        public static HeaderTransactions getHeaderTransactionById(int transactionId)
        {
            return TransactionHandler.getHeaderTransactionById(transactionId);
        }

        public static List<Object> generateTransactionData(int userId, int roleId)
        {
            return roleId == 2 ? TransactionController.getCurrUserTransactions(userId) : TransactionController.getAllUserTransactions();
        }

        private static List<Object> getCurrUserTransactions(int userId)
        {
            return TransactionHandler.getCurrUserTransactions(userId);
        }

        private static List<Object> getAllUserTransactions()
        {
            return TransactionHandler.getAllUserTransactions();
        }

    }
}