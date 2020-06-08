using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class ProductController
    {
        public static Products getProductById(int id)
        {
            return ProductRepository.getProductById(id);
        }
    }
}