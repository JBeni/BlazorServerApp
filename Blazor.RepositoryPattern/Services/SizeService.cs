namespace Blazor.RepositoryPattern.Services
{
    public class SizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SizeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<SizeResponse> GetSizesData()
        {
            try
            {
                var result = _unitOfWork.Sizes.GetAll();
                var sizes = _mapper.Map<List<SizeResponse>>(result);
                return sizes;
            }
            catch
            {
                throw;
            }
        }
    }
}
