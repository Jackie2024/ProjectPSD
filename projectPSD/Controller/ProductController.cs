using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class ProductController
    {
        private ProductHandler productHdlr = new ProductHandler();
        public Products getProductById(int id)
        {
            return productHdlr.getProductById(id);
        }

        public dynamic print()
        {
            return productHdlr.print();
        }

        public dynamic printForMember()
        {
            return productHdlr.printForMember();
        }

        public String gotoUpdateAttempt(String targetId)
        {
            String errMsg = validateInputId(targetId);

            if (errMsg == null)
            {
                List<Products> listProducts = productHdlr.getProduct();
                errMsg = validateProductId(targetId, listProducts);
                if (errMsg == null)
                {
                    productHdlr.gotoUpdateProduct(targetId);
                    return errMsg;
                };
            }

            return errMsg;
        }

        public String deleteAttempt(String targetId)
        {
            String errMsg = validateInputId(targetId);

            if (errMsg == null)
            {
                List<Products> listProducts = productHdlr.getProduct();
                errMsg = validateProductId(targetId, listProducts);
                if (errMsg == null)
                {
                    productHdlr.deleteProduct(targetId);
                    return errMsg;
                };
            }

            return errMsg;
        }

        public String insertAttempt(String name, String stockText, String priceText)
        {
            int stock = toInt(stockText);
            int price = toInt(priceText);
            String errMsg = validateInput(name, stock, price);

            if (errMsg == null)
            {
                productHdlr.insertProduct(name, stock, price);
                return errMsg;
            }

            return errMsg;
        }

        public String updateAttempt(String targetId, String name, String stockText, String priceText)
        {
            int stock = toInt(stockText);
            int price = toInt(priceText);
            String errMsg = validateInput(name, stock, price);

            if (errMsg == null)
            {
                productHdlr.updateProduct(targetId, name, stock, price);
                return errMsg;
            }

            return errMsg;
        }

        private String validateInputId(String targetId)
        {
            String errMsg = null;

            if (targetId == "")
            {
                errMsg = "Product ID must be filled";
            }

            return errMsg;
        }

        private String validateProductId(String targetId, List<Products> listProducts)
        {
            String errMsg = null;

            foreach (Products i in listProducts)
            {
                if (i.ID.Equals(int.Parse(targetId)))
                {
                    errMsg = null;
                    return errMsg;
                }
            }
            errMsg = "Product ID must be exist";

            return errMsg;
        }

        private String validateInput(String name, int stock, int price)
        {
            String errMsg = null;

            if (name == "")
            {
                errMsg = "Name must be filled";
            }
            else if (stock < 1)
            {
                errMsg = "Stock must be 1 or more";
            }
            else if (price < 1000 || price % 1000 != 0)
            {
                errMsg = "Price must be above 1000 and multiply of 1000";
            }

            return errMsg;
        }

        private int toInt(String s)
        {
            int number;
            bool isParsable = Int32.TryParse(s, out number);
            if (isParsable)
                return (number);
            else
                return (0);
        }
    }
}