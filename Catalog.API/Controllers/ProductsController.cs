using Catalog.Application.Features.Product.Commands.CreateNewProduct;
using Catalog.Application.Features.Product.Quaries.GetAllProducts;
using Catalog.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        // private readonly GetAllProductsRequestHandler _getAllProductsRequestHandler;
        private readonly IMediator _mediator;
        public ProductsController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet]
         public async Task<IActionResult> Get()
        {
            //1.isteği oluştur:
            var request = new GetAllProductRequest();
            //2.İsteği işleyecek handler ile çalış (enjekte et).
            var response = await _mediator.Send(request);
            //DİKKAT!! aşağıdaki kod service patterni
            //var products = await _productService.GetProducts();
 
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(request);
                return Created($"https://mydomain.com/products{response.CreatedProductId}",request);
            }
            return BadRequest(ModelState);
        }
    }
}
