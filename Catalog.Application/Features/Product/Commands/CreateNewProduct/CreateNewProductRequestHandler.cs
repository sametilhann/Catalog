using Catalog.Application.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.Commands.CreateNewProduct
{
    public class CreateNewProductRequestHandler : IRequestHandler<CreateNewProductRequest, CreateNewProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateNewProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateNewProductResponse> Handle(CreateNewProductRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Entities.Product>();
            await _productRepository.Create(product);
            return new CreateNewProductResponse(CreatedProductId:product.Id);
        }
    }
}
