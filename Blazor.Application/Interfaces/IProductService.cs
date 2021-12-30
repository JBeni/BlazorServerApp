namespace Blazor.Application.Interfaces
{
    public interface IProductService
    {
        public List<ProductResponse> GetProducts();
        public Task AddProduct(ProductResponse product);
        public Task UpdateProduct(ProductResponse product);
        public ProductResponse GetProduct(int id);
        public Task DeleteProduct(int id);
        public List<SizeResponse> GetSizesData();
        public List<ColourResponse> GetColoursData();
    }
}
