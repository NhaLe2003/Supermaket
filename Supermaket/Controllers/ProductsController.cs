using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Supermaket.Domain.Models;
using Supermaket.Domain.Services;
using Supermaket.Extensions;
using Supermaket.Resources;

namespace Supermaket.Controllers
{
    
        [Route("/api/[controller]")]
        public class ProductsController : Controller
        {
            private readonly IProductService _productService;
            private readonly IMapper _mapper;

            public ProductsController(IProductService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<IEnumerable<ProductResource>> ListAsync()
            {
                var products = await _productService.ListAsync();
                var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
                return resources;
            }
            [HttpPost]
            public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages);
            }
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var productResource = _mapper.Map<Product ,  ProductResource>(result.Product);
            return Ok(productResource);
        }

        
        }
}
