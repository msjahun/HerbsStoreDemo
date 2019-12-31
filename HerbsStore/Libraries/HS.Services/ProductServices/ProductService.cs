using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;
using HerbsStore.Libraries.HS.Core.Domain.Products;
using HerbsStore.Libraries.HS.Data.Repository;
using HerbsStore.Libraries.HS.Services.DiseaseServices;
using HerbsStore.Libraries.HS.Services.ImageServices;

namespace HerbsStore.Libraries.HS.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productsRepo;
        private readonly IImageService _imageService;
        private readonly IRepository<ProductDisease> _productDiseaseRepo;
        private readonly IDiseaseService _diseaseService;
        private readonly IRepository<Disease> _diseaseRepo;

        public ProductService(IRepository<Product> productsRepo,
            IImageService imageService,
            IRepository<ProductDisease> productDiseaseRepo,
            IDiseaseService diseaseService,
            IRepository<Disease> diseaseRepo)
        {
            _productsRepo = productsRepo;
            _imageService = imageService;
            _productDiseaseRepo = productDiseaseRepo;
            _diseaseService = diseaseService;
            _diseaseRepo = diseaseRepo;
        }
        public long ProductAdd(ProductCrudVm vm)
        {
            var product = new Product
            {
                ProductName = vm.ProductName,
                ProductType = vm.ProductType,
                Price = vm.Price,
                OldPrice =vm.OldPrice,
                Description = vm.ProductDescription,
                Feature = vm.ProductFeature,
                PrimaryCare= vm.PrimaryCare,
                SecondaryCare  = vm.SecoundaryCare,
                ImageUrl = _imageService.UploadProductImage()
            };

           var productId = _productsRepo.Insert(product);
            //take list of disease and add to db
            foreach (var item in vm.DiseaseListIds)
            {
           
                _productDiseaseRepo.Insert(new ProductDisease
                    {
                        ProductId = productId,
                        DiseaseId = item
                    });

            }

            return productId;
        }

        public ProductCrudVm GetProductById(long id)
        {
            var product = _productsRepo.GetById(id);
            if (product == null) return null;

            var model = new ProductCrudVm
            {
                Id= product.Id,
                ProductName= product.ProductName,
                ProductDescription = product.Description,
                ProductFeature = product.Feature,
                ProductType = product.ProductType,
                PrimaryCare = product.PrimaryCare,
                SecoundaryCare = product.SecondaryCare,
                Price = product.Price,
                OldPrice = product.OldPrice,
                CreatedOn = product.CreatedOn.ToString(CultureInfo.InvariantCulture),
                ImageUrl = string.IsNullOrEmpty(product.ImageUrl)? "/images/default-image_100.png" : product.ImageUrl,
                DiseaseListIds = GetProductDiseaseIdsByProductId(product.Id),
                ProductDiseases =_diseaseService.FlattenDiseasesList(GetProductDiseaseByProductId(product.Id))

            };

            return model;
        }


        public List<string> GetProductDiseaseByProductId(long id)
        {
            var product = _productsRepo.GetById(id);
            if (product == null) return null;

            var productDisease = from d in _diseaseRepo.List()
                join prodDis in _productDiseaseRepo.List() on d.Id equals prodDis.DiseaseId
                                 where prodDis.ProductId == product.Id
                select d.DiseaseName;
            return productDisease.ToList();


        }      
        
        public List<long> GetProductDiseaseIdsByProductId(long id)
        {
            var product = _productsRepo.GetById(id);
            if (product == null) return null;

            var productDisease = from d in _diseaseRepo.List()
                join prodDis in _productDiseaseRepo.List() on d.Id equals prodDis.DiseaseId
                                 where prodDis.ProductId == product.Id
                select d.Id;
            return productDisease.ToList();


        }
        public bool ProductUpdate(ProductCrudVm vm)
        {
            var product = _productsRepo.GetById(vm.Id);
            if (product == null) return false;

            product.ProductName = vm.ProductName;
            product.ProductType = vm.ProductType;
            product.Price = vm.Price;
            product.OldPrice = vm.OldPrice;
            product.Description = vm.ProductDescription;
            product.Feature = vm.ProductFeature;
            product.PrimaryCare = vm.PrimaryCare;
            product.SecondaryCare = vm.SecoundaryCare;

            var updatedImageUrl = _imageService.UploadProductImage();
            if (!string.IsNullOrEmpty(updatedImageUrl))
                product.ImageUrl = updatedImageUrl;

            _productsRepo.Update(product);

            //take list of disease and clear existing and add new to list
            var productDiseases = _productDiseaseRepo.List().Where(c => c.ProductId == product.Id).ToList();
            foreach (var item in productDiseases)
            {
                _productDiseaseRepo.Delete(item);
            }
            //^delete current ids

            if (vm.DiseaseListIds != null)
                foreach (var item in vm.DiseaseListIds)
            {

                _productDiseaseRepo.Insert(new ProductDisease
                {
                    ProductId = product.Id,
                    DiseaseId = item
                });

            }
            //^inserts new ids
            return true;
        }

        public void DeleteProduct(long productId)
        {
            var product = _productsRepo.GetById(productId);
            if (product == null) return;

            var productDiseases = _productDiseaseRepo.List().Where(c => c.ProductId == product.Id).ToList();
            foreach (var item in productDiseases)
            {
                _productDiseaseRepo.Delete(item);
            }
            //^delete current ids

            _productsRepo.Delete(product);
        }


        public List<ProductCrudVm> GetProducts(ProductCrudVm vm)
        {

            var products = _productsRepo.List().ToList();
            var productDisease = _productDiseaseRepo.List().ToList();
            products = ProductFilterHelpers.ProductType(products, vm.ProductType);
            products = ProductFilterHelpers.SearchProductName(products, vm.ProductName);
            products = ProductFilterHelpers.DiseaseType(products, productDisease, vm.DiseaseId);

            //filters are productName, productType, DiseaseType
           var model = from product in products
                select new ProductCrudVm
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.Description,
                    ProductFeature = product.Feature,
                    ProductType = product.ProductType,
                    PrimaryCare = product.PrimaryCare,
                    SecoundaryCare = product.SecondaryCare,
                    Price = product.Price,
                    OldPrice = product.OldPrice,
                    CreatedOn = product.CreatedOn.ToString(CultureInfo.InvariantCulture),
                    ImageUrl = string.IsNullOrEmpty(product.ImageUrl) ? "/images/default-image_100.png" : product.ImageUrl,
                    ProductDiseases = _diseaseService.FlattenDiseasesList(GetProductDiseaseByProductId(product.Id))
                };

            return model.ToList();

            

        } 
    }

    public class ProductCrudVm
    {
        public long Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public string ProductFeature { get; set; }
        [Required]
        public int ProductType { get; set; }

        public string PrimaryCare { get; set; }
        public string SecoundaryCare { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public string CreatedOn { get; set; }
        public string ImageUrl { get; set; }

        public List<ProductCrudVm> List { get; set; }
        public int DiseaseId { get; set; }
        public List<long> DiseaseListIds { get; set; }
        public string ProductDiseases { get; set; }
    }
}
