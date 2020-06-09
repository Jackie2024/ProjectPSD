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

        public dynamic print()
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

        public dynamic printForMember()
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

        public List<Products> getProducts()
        {
            return (from i in db.Products
                    select i).ToList();
        }

        public void delProducts(int targetId)
        {
            Products p = (from i in db.Products
                          where i.ID == targetId
                          select i).FirstOrDefault();

            db.Products.Remove(p);
            db.SaveChanges();
        }

        public void updateProducts(int id, String name, int stock, int price)
        {
            Products p = (from i in db.Products
                          where i.ID == id
                          select i).FirstOrDefault();
            p.Name = name;
            p.Stock = stock;
            p.Price = price;
            db.SaveChanges();
        }

        public void insertProducts(String name, int stock, int price)
        {
            Products p = ProductFactory.createProduct(name, stock, price);

            db.Products.Add(p);
            db.SaveChanges();
        }

        public static void decreaseStock(int id, int quantity)
        {
            Products product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            product.Stock -= quantity;
            db.SaveChanges();
        }

        public Products getProductById(int id)
        {
            Products p = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return p;
        }


        public static List<Object> getProductByDetailsId(int productID)
        {

            return db.Products.Where(p => p.ID == productID).ToList<Object>();

        }
    }
}