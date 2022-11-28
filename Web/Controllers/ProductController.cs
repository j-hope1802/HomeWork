using Domain.Dtos;
using Infrastructure.ProductService;
using Microsoft.AspNetCore.Mvc;
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController
    {
        private ProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }


        [HttpGet]
        public List<Products> GetInfoProducts()
        {
            return _productService.GetInfoProduct();
        }
        [HttpPost("Insert")]
        public int InsertProduct(Products products)
        {
            return _productService.InsertProduct(products);
        }

        [HttpPut]
        public int UpdateProduct(Products products)
        {
            return _productService.UpdateProduct(products);
        }

        [HttpDelete]
        public int DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }



    }
}
