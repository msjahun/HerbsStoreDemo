using System.Collections.Generic;

namespace HerbsStore.Libraries.HS.Services.ProductServices
{
    public interface IProductService
    {
        long ProductAdd(ProductCrudVm vm);
        ProductCrudVm GetProductById(long id);
        bool ProductUpdate(ProductCrudVm productVm);
        void DeleteProduct(long productId);
        List<ProductCrudVm> GetProducts();
    }
}