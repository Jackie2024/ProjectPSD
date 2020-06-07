using ProjectPSD.Factory;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class ProductRepository
    {
        private static DatabaseEnt db = new DatabaseEnt();

        public static dynamic print()
        {
            
            return (from p in db.Products
                    select new
                    {
                        p.ID,
                        p.Name,
                        p.Stock,
                        ProductType = p.ProductTypes.Name,
                        p.Price
                    }).ToList();
           
        }

        public static dynamic printForMember()
        {
            return (from p in db.Products
                    select new
                    {
                        p.ID,
                        p.Name,
                        p.Stock,
                        ProductType = p.ProductTypes.Name,
                        p.Price
                    }).OrderBy(y => Guid.NewGuid()).Take(5).ToList();
        }

        public static List<Products> getProducts()
        {
            return (from i in db.Products
                    select i).ToList();
        }

        public static void delProducts(int targetId)
        {
            Products p = (from i in db.Products
                          where i.ID == targetId
                          select i).FirstOrDefault();

            db.Products.Remove(p);
            db.SaveChanges();
        }

        public static void updateProducts(int id, String name, int stock, int price)
        {
            Products p = (from i in db.Products
                          where i.ID == id
                          select i).FirstOrDefault();
            p.Name = name;
            p.Stock = stock;
            p.Price = price;
            db.SaveChanges();
        }

        public static void insertProducts(String name, int stock, int price)
        {
            Products p = ProductFactory.createProduct(name, stock, price);

            db.Products.Add(p);
            db.SaveChanges();
        }

       
        public static List<Object> getProductByDetailsId(int productID)
        {

            return db.Products.Where(p => p.ID == productID).ToList<Object>();

        }

        public static Products getProductId(int id)
        {
            return db.Products.Where(p => p.ID == id).FirstOrDefault();
        }
    }
}