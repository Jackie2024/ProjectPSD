using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace ProjectPSD.Handler
{
    public class ProductTypeHandler : Page
    {
        private ProductTypeRepository productTypeRepo = new ProductTypeRepository();

        public String getProductTypebyId(String targetId)
        {
            return productTypeRepo.getProductTypebyId(int.Parse(targetId));
        }

        public String getDescbyId(String targetId)
        {
            return productTypeRepo.getDescbyId(int.Parse(targetId));
        }

        public List<ProductTypes> getProductType()
        {
            return productTypeRepo.getProductTypes();
        }

        public void gotoUpdateProductType(String productTypeId)
        {
            HttpContext.Current.Response.Redirect("UpdateProductType.aspx?id=" + productTypeId);
        }

        public void deleteProductType(String productTypeId)
        {
            productTypeRepo.delProductTypes(int.Parse(productTypeId));
            HttpContext.Current.Response.Redirect("ViewProductType.aspx");
        }

        public void insertProductType(String productType, String desc)
        {
            productTypeRepo.insertProductTypes(productType, desc);
            HttpContext.Current.Response.Redirect("ViewProductType.aspx");
        }

        public void updateProductType(String targetProductId, String productType, String desc)
        {
            productTypeRepo.updateProductTypes(int.Parse(targetProductId), productType, desc);
            HttpContext.Current.Response.Redirect("ViewProductType.aspx");
        }
    }
}