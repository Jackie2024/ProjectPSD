using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Repository
{
    public class CartRepository
    {
        private static DatabaseEnt db = new DatabaseEnt();
        public static void insertCart(Carts cart)
        {
            Carts c = cart;
            db.Carts.Add(c);
            db.SaveChanges();
        }

        public static List<Object> getCurrUserCarts(int userId)
        {
            return db.Carts.Where(c => c.UserID == userId)
                .Select(
                crt => new {
                    ID = crt.Products.ID,
                    Name = crt.Products.Name,
                    Price = crt.Products.Price,
                    Quantity = crt.Quantity,
                    Subtotal = crt.Quantity * crt.Products.Price
                }).ToList<Object>();
        }

        public static double GrandTotal(int userId)
        {
            double GrandTotal = db.Carts.Where(x => x.UserID == userId).Sum(x => x.Products.Price * x.Quantity);
            return GrandTotal;
        }

        public static void deleteCart(int cartId)
        {
            Carts c = db.Carts.Where(x => x.ProductID == cartId).FirstOrDefault();

            db.Carts.Remove(c);
            db.SaveChanges();
        }
    }
}