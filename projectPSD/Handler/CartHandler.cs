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
        public static List<Object> getProductDetails(int productID)
        {
            return ProductRepository.getProductByDetailsId(productID);
        }

        public static Products getProductById(int id)
        {
            return ProductRepository.getProductId(id);
        }
    }
}