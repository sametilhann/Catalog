using Catalog.Application.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.Quaries.GetAllProducts
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
    {
        private readonly IProductRepository productRepository;

        public GetAllProductsRequestHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository; 
        }

        public async Task<GetAllProductResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAll();

            //var responseDto = products.Select(p => new ProductsDisplayResponseAlternate(
            //    Id: p.Id,
            //    Name: p.Name,
            //    Description: p.Description,
            //    Price: p.Price,
            //    Rating: p.Rating
            //    ));

            var responseDto = products.Adapt<IEnumerable<ProductsDisplayResponseAlternate>>();

            if (responseDto != null)
            {
                return new GetAllProductResponse(
                  IsSuccess: true, responseDto.Count(), responseDto, null);
            }
            return new GetAllProductResponse(IsSuccess: false, 0, null, new() { "Ürünler Çekilemedi" });
        }

        //public async Task<GetAllProductResponse> Handle(GetAllProductRequest request) 
        //{ 
        //    var products = await productRepository.GetAll();
        //    var responseDto = products.Select(p => new ProductsDisplayResponseAlternate(
        //        Id: p.Id,
        //        Name: p.Name,
        //        Description: p.Description,
        //        Price: p.Price,
        //        Rating: p.Rating
        //        ));

        //    if (responseDto != null)
        //    {
        //      return  new GetAllProductResponse(
        //        IsSuccess: true,responseDto.Count(),responseDto,null);
        //    }
        //    return new GetAllProductResponse(IsSuccess: false, 0, null, new() { "Ürünler Çekilemedi" });
        //}
    }
}
