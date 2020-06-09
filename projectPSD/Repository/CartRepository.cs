using ProjectPSD.Factory;
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

        public static void insertCart(int userId, int quantity, Products p)
        {
            Carts c = CartFactory.Create(userId, quantity, p);
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

        public static void deleteCart(int userId, int cartId)
        {
            Carts c = db.Carts.Where(x => x.ProductID == cartId && x.UserID == userId).FirstOrDefault();

            db.Carts.Remove(c);
            db.SaveChanges();
        }

        public static Carts getCartData(int id)
        {
            return db.Carts.Where(x => x.UserID == id).FirstOrDefault();
        }

        public static Carts getItemData(int userId, int id)
        {
            return db.Carts.Where(x => x.ProductID == id && x.UserID == userId).FirstOrDefault();
        }

        public static void updateCart(int userId, int prodID, int quantity)
        {
            Carts cart = db.Carts.Where(C => C.UserID == userId && C.ProductID == prodID).FirstOrDefault();
            cart.Quantity += quantity;

            db.SaveChanges();
        }
    }
}