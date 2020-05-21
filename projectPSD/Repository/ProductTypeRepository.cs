using ProjectPSD.Factory;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class ProductTypeRepository
    {
        private static DatabaseEnt db = new DatabaseEnt();

        public static List<ProductTypes> getProductTypes()
        {
            return (from i in db.ProductTypes
                    select i).ToList();
        }

        public static void delProductTypes(int targetId)
        {
            ProductTypes p = (from i in db.ProductTypes
                          where i.ID == targetId
                          select i).FirstOrDefault();

            db.ProductTypes.Remove(p);
            db.SaveChanges();
        }

        public static void updateProductTypes(int targetId, String productType, String desc)
        {
            ProductTypes p = (from i in db.ProductTypes
                              where i.ID == targetId
                              select i).FirstOrDefault();
            p.Name = productType;
            p.Description = desc;
            db.SaveChanges();
        }

        public static void insertProductTypes(String productType, String desc)
        {
            ProductTypes p = ProductTypeFactory.createProductType(productType, desc);

            db.ProductTypes.Add(p);
            db.SaveChanges();
        }
    }
}