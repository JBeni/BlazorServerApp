namespace Blazor.RepositoryPattern.Services
{
    public class CityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<CityResponse> GetCitiesData()
        {
            try
            {
                var result = _unitOfWork.Cities.GetAll();
                var cities = _mapper.Map<List<City>, List<CityResponse>>(result);
                return cities;
            }
            catch
            {
                throw;
            }
        }
    }
}
