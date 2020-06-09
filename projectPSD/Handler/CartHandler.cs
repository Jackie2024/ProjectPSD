using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class CartHandler
    {
        public static double GrandTotal(int userId)
        {
            double GrandTotal;
            if (CartRepository.getCartData(userId) == null)
            {
                return GrandTotal = 0;
            }
            return GrandTotal = CartRepository.GrandTotal(userId);
        }

        public static List<Object> getProductDetails(int productID)
        {
            return ProductRepository.getProductByDetailsId(productID);
        }

        private ProductRepository productRepo = new ProductRepository();
        public Products getProductById(int id)
        {
            
            return productRepo.getProductById(id);
        }
    }
}