namespace Blazor.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ProductResponse> GetProducts()
        {
            try
            {
                var result = _dbContext.Products
                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddProduct(ProductResponse product)
        {
            try
            {
                var entity = _dbContext.Products.FirstOrDefault(x => x.Id == product.Id);
                if (entity != null) return;

                var size = _dbContext.Sizes.FirstOrDefault(x => x.Id == product.SizeId);
                var colour = _dbContext.Colours.FirstOrDefault(x => x.Id == product.ColourId);

                entity = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Amount = product.Amount,
                    Brand = product.Brand,
                    Size = size,
                    Colour = colour,
                };

                _dbContext.Products.Add(entity);
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateProduct(ProductResponse product)
        {
            try
            {
                Product? entity = _dbContext.Products.FirstOrDefault(x => x.Id == product.Id);
                if (entity == null) return;

                var size = _dbContext.Sizes.FirstOrDefault(x => x.Id == product.SizeId);
                var colour = _dbContext.Colours.FirstOrDefault(x => x.Id == product.ColourId);

                entity.Name = product.Name;
                entity.Description = product.Description;
                entity.Price = product.Price;
                entity.Amount = product.Amount;
                entity.Brand = product.Brand;
                entity.Size = size;
                entity.Colour = colour;

                _dbContext.Products.Update(entity);
                await _dbContext.SaveChangesAsync(new CancellationToken());
            }
            catch
            {
                throw;
            }
        }

        public ProductResponse GetProduct(int id)
        {
            try
            {
                var Product = _dbContext.Products.AsNoTracking()
                    .Where(x => x.Id == id)
                    .ProjectTo<ProductResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault();

                if (Product != null)
                {
                    return Product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                Product? Product = _dbContext.Products.Find(id);

                if (Product != null)
                {
                    _dbContext.Products.Remove(Product);
                    await _dbContext.SaveChangesAsync(new CancellationToken());
                }
            }
            catch
            {
                throw;
            }
        }

        public List<SizeResponse> GetSizesData()
        {
            try
            {
                var result = _dbContext.Sizes.AsNoTracking()
                    .ProjectTo<SizeResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public List<ColourResponse> GetColoursData()
        {
            try
            {
                var result = _dbContext.Colours.AsNoTracking()
                    .ProjectTo<ColourResponse>(_mapper.ConfigurationProvider)
                    .ToList();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
