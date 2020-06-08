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

        public List<ProductTypes> getProductTypes()
        {
            return (from i in db.ProductTypes
                    select i).ToList();
        }

        public String getProductTypebyId(int targetId)
        {
            ProductTypes p = (from i in db.ProductTypes
                              where i.ID == targetId
                              select i).FirstOrDefault();
            return p.Name;
        }

        public String getDescbyId(int targetId)
        {
            ProductTypes p = (from i in db.ProductTypes
                              where i.ID == targetId
                              select i).FirstOrDefault();
            return p.Description;
        }

        public void delProductTypes(int targetId)
        {
            ProductTypes p = (from i in db.ProductTypes
                          where i.ID == targetId
                          select i).FirstOrDefault();

            db.ProductTypes.Remove(p);
            db.SaveChanges();
        }

        public void updateProductTypes(int targetId, String productType, String desc)
        {
            ProductTypes p = (from i in db.ProductTypes
                              where i.ID == targetId
                              select i).FirstOrDefault();
            p.Name = productType;
            p.Description = desc;
            db.SaveChanges();
        }

        public void insertProductTypes(String productType, String desc)
        {
            ProductTypes p = ProductTypeFactory.createProductType(productType, desc);

            db.ProductTypes.Add(p);
            db.SaveChanges();
        }
    }
}