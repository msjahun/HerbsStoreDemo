using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Products;
using HerbsStore.Libraries.HS.Data.Repository;
using HerbsStore.Libraries.HS.Services.DropdownServices;
using HerbsStore.Libraries.HS.Services.ImageServices;

namespace HerbsStore.Libraries.HS.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productsRepo;
        private readonly IImageService _imageService;
        private readonly IDropdownService _dropdownService;

        public ProductService(IRepository<Product> productsRepo,
            IImageService imageService,
            IDropdownService dropdownService)
        {
            _productsRepo = productsRepo;
            _imageService = imageService;
            _dropdownService = dropdownService;
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

            return  _productsRepo.Insert(product);
            
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
                ImageUrl = string.IsNullOrEmpty(product.ImageUrl)? "/images/default-image_100.png" : product.ImageUrl
            };

            return model;
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

            return true;
        }

        public void DeleteProduct(long productId)
        {
            var product = _productsRepo.GetById(productId);
            if (product == null) return;

            _productsRepo.Delete(product);
        }


        public List<ProductCrudVm> GetProducts()
        {
            var model = from product in _productsRepo.List()
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
                    ImageUrl = string.IsNullOrEmpty(product.ImageUrl) ? "/images/default-image_100.png" : product.ImageUrl
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
    }
}
