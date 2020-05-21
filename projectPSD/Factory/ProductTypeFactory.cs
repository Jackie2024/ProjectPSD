using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class ProductTypeFactory
    {
        public static ProductTypes createProductType(String productType, String desc)
        {
            return new ProductTypes()
            {
                Name = productType,
                Description = desc
            };
        }
    }
}