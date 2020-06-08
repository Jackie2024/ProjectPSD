using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Handler
{
    public class ProductHandler
    {
        private ProductRepository productRepo = new ProductRepository();

        public Products getProductById(int id)
        {
            return productRepo.getProductById(id);
        }

        public dynamic print()
        {
            return productRepo.print();
        }

        public dynamic printForMember()
        {
            return productRepo.printForMember();
        }

        public List<Products> getProduct()
        {
            return productRepo.getProducts();
        }

        public void gotoUpdateProduct(String productId)
        {
            HttpContext.Current.Response.Redirect("UpdateProduct.aspx?id=" + productId);
        }

        public void deleteProduct(String productId)
        {
            productRepo.delProducts(int.Parse(productId));
            HttpContext.Current.Response.Redirect("ViewProduct.aspx");
        }

        public void insertProduct(String name, int stock, int price)
        {
            productRepo.insertProducts(name, stock, price);
            HttpContext.Current.Response.Redirect("ViewProduct.aspx");
        }

        public void updateProduct(String targetProductId, String name, int stock, int price)
        {
            productRepo.updateProducts(int.Parse(targetProductId), name, stock, price);
            HttpContext.Current.Response.Redirect("ViewProduct.aspx");
        }
    }
}