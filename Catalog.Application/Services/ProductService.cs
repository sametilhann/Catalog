using Catalog.Application.Contracts;
using Catalog.Application.DataTransferObjects;

namespace Catalog.Application.Services
{
    public class ProductService : IProductService
    {
        //DBContext nesnesi ziole edilme çünkü gelecekte veri deposuyla nasıl çalışacağım değiştiğinde bu classa mudahale etmek istemiyoruz.
        //private readonly EGMCatalogDbContext dbContext;
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        //private List<Product> _products = new ()
        //{
        //  new() { Id=1,Name ="Ürün A",Price =1},
        //  new() { Id=2,Name ="Ürün B",Price =1}
        //};
        public async Task<IEnumerable<ProductsDisplayResponse>> GetProducts()
        {
            var products = await productRepository.GetAll();
            return products.Select(p => new ProductsDisplayResponse(
            
            Id: p.Id,
            Name: p.Name,
            Description: p.Description,
            Price: p.Price,
            Rating: p.Rating
            ));
        }

     
    }
}
