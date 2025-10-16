using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.Quaries.GetAllProducts
{
    public record GetAllProductRequest() : IRequest<GetAllProductResponse>;
    //Not: Aslında aşağıdaki dto nesnesini yazmamımıza gerek yoktu fakat ,klasör yapısına uygun olması için. DataTransferObjects ProductDisplayResponse recordunu aynen buraya alıyoruz.


    public record ProductsDisplayResponseAlternate(int Id, string? Name, string? Description, double? Rating, decimal Price);

    public record GetAllProductResponse(
        bool IsSuccess,
        int TotaCount,
        IEnumerable<ProductsDisplayResponseAlternate> ProductDisplays,
        List<string>? Errors
        );
}

