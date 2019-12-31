using System.Collections.Generic;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;
using HerbsStore.Libraries.HS.Core.Domain.Products;

namespace HerbsStore.Libraries.HS.Services.ProductServices
{
    public class ProductFilterHelpers
    {
        public static List<Product> ProductType(List<Product> products, int productType)
        {
            // public string HouseType { get; set; }//show all, houses, Flats, Multi-family
            if (productType == 0)//show all
                return products;


            var productList = from prod in products
                where prod.ProductType == productType
                select prod;
            return productList.ToList();

        }   
        
        
        public static List<Product> DiseaseType(List<Product> products, List<ProductDisease> productDiseases, int diseaseId)
        {
            
            if (diseaseId== 0)//show all
                return products;

            var productDisease = from prodDisease in productDiseases
                where prodDisease.DiseaseId == diseaseId
                select prodDisease;

            var productList = from prod in products
                join pd in productDisease on prod.Id equals  pd.ProductId
                select prod;
            return productList.ToList();

        }


        public static List<Product> SearchProductName(List<Product> products, string searchProductName)
        {
            
            if (string.IsNullOrEmpty(searchProductName))
                return products;
            if (products == null) return null;

            var productsList = from prod in products
                where prod.ProductName.ToLower().Contains(searchProductName.ToLower())
                select prod;

            return productsList.ToList();
        }

    
    }
}
