namespace Blazor.RepositoryPattern.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ProductResponse> GetAllProducts()
        {
            try
            {
                var result = _unitOfWork.Products.GetAll();
                var Products = _mapper.Map<List<ProductResponse>>(result);
                return Products;
            }
            catch
            {
                throw;
            }
        }

        public void AddProduct(ProductResponse product)
        {
            try
            {
                var entity = _unitOfWork.Products.Get(product.Id);
                if (entity != null) return;
                var size = _unitOfWork.Sizes.Get(product.SizeId);
                var colour = _unitOfWork.Colours.Get(product.ColourId);

                entity = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Amount = product.Amount,
                    Brand = product.Brand,
                    Size = size,
                    Colour = colour
                };

                _unitOfWork.Products.Add(entity);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProduct(ProductResponse product)
        {
            try
            {
                var entity = _unitOfWork.Products.Get(product.Id);
                if (entity == null) return;
                var size = _unitOfWork.Sizes.Get(product.SizeId);
                var colour = _unitOfWork.Colours.Get(product.ColourId);

                entity.Name = product.Name;
                entity.Description = product.Description;
                entity.Price = product.Price;
                entity.Amount = product.Amount;
                entity.Brand = product.Brand;
                entity.Size = size;
                entity.Colour = colour;

                _unitOfWork.Products.Update(entity);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public ProductResponse GetProductData(int id)
        {
            try
            {
                var result = _unitOfWork.Products.Get(id);
                var product = _mapper.Map<ProductResponse>(result);

                return product == null ? throw new ArgumentNullException() : product;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                Product? product = _unitOfWork.Products.Get(id);

                if (product == null) throw new ArgumentNullException();
                _unitOfWork.Products.Delete(product);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }
    }
}
