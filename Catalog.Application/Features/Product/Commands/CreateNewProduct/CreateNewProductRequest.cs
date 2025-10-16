using Catalog.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.Product.Commands.CreateNewProduct
{
    public record CreateNewProductRequest(
            [Required(ErrorMessage = "Ürün adı boş olamamalı")] string Name,
            string? Description,
            decimal Price,
            int StockCount,
            int CategoryId
        ) : IRequest<CreateNewProductResponse>;

    public record CreateNewProductResponse(int CreatedProductId);


}
