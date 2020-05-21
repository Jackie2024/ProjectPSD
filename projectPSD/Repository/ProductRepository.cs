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

        public static List<Object> print()
        {
            List<Object> list = db.Products.Select(i => new
            {
                ProductID = i.ID,
                ProductName = i.Name,
                ProductStock = i.Stock,
                ProductTypeName = i.ProductTypes.Name,
                ProductPrice = i.Price
            }).ToList<Object>();

            return list;
        }

        public static List<Object> printForMember()
        {
            List<Object> list = db.Products.Select(i => new
            {
                ProductID = i.ID,
                ProductName = i.Name,
                ProductStock = i.Stock,
                ProductTypeName = i.ProductTypes.Name,
                ProductPrice = i.Price
            }).OrderBy(i => Guid.NewGuid()).Take(5).ToList<Object>();

            return list;
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
    }
}