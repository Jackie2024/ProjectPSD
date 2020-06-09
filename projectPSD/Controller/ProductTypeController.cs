using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;

namespace ProjectPSD.Controller
{
    public class ProductTypeController
    {
        private ProductTypeHandler productTypeHdlr = new ProductTypeHandler();

        public String getProductTypebyId(String targetId)
        {
            return productTypeHdlr.getProductTypebyId(targetId);
        }

        public String getDescbyId(String targetId)
        {
            return productTypeHdlr.getDescbyId(targetId);
        }
        public List<ProductTypes> getProductType()
        {
            return productTypeHdlr.getProductType();
        }

        public String gotoUpdateAttempt(String targetId)
        {
            String errMsg = validateInputId(targetId);

            if (errMsg == null)
            {
                List<ProductTypes> listProductTypes = productTypeHdlr.getProductType();
                errMsg = validateProductTypeId(targetId, listProductTypes);
                if (errMsg == null)
                {
                    productTypeHdlr.gotoUpdateProductType(targetId);
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
                List<ProductTypes> listProductTypes = productTypeHdlr.getProductType();
                errMsg = validateProductTypeId(targetId, listProductTypes);
                if (errMsg == null)
                {
                    productTypeHdlr.deleteProductType(targetId);
                    return errMsg;
                };
            }

            return errMsg;
        }

        public String insertAttempt(String productType, String desc)
        {
            String errMsg = validateInput(productType, desc);

            if (errMsg == null)
            {
                List<ProductTypes> listProductTypes = productTypeHdlr.getProductType();
                errMsg = validateProductType(productType, listProductTypes);
                if (errMsg == null)
                {
                    productTypeHdlr.insertProductType(productType, desc);
                    return errMsg;
                };
            }

            return errMsg;
        }

        public String updateAttempt(String targetId, String productType, String desc)
        {
            String errMsg = validateInput(productType, desc);

            if (errMsg == null)
            {
                List<ProductTypes> listProductTypes = productTypeHdlr.getProductType();
                errMsg = validateProductType(productType, listProductTypes);
                if (errMsg == null)
                {
                    productTypeHdlr.updateProductType(targetId, productType, desc);
                    return errMsg;
                };
            }

            return errMsg;
        }

        private String validateInputId(String targetId)
        {
            String errMsg = null;

            if (targetId == "")
            {
                errMsg = "Product Type ID must be filled";
            }

            return errMsg;
        }

        private String validateProductTypeId(String targetId, List<ProductTypes> listProductTypes)
        {
            String errMsg = null;

            foreach (ProductTypes i in listProductTypes)
            {
                if (i.ID.Equals(int.Parse(targetId)))
                {
                    errMsg = null;
                    return errMsg;
                }
            }
            errMsg = "Product Type ID must be exist";

            return errMsg;
        }

        private String validateInput(String productType, String desc)
        {
            String errMsg = null;

            if (productType == "")
            {
                errMsg = "Product type must be filled";
            }
            else if (productType.Length < 5)
            {
                errMsg = "Product type must consist of 5 characters or more";
            }
            else if (desc == "")
            {
                errMsg = "Description must be filled";
            }

            return errMsg;
        }

        private String validateProductType(String productType, List<ProductTypes> listProductTypes)
        {
            String errMsg = null;

            foreach (ProductTypes i in listProductTypes)
            {
                if (i.Name.Equals(productType))
                {
                    errMsg = "Product type must be unique";
                    return errMsg;
                }
            }

            return errMsg;
        }
    }
}