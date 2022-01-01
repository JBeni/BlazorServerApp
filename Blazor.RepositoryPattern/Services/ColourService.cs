namespace Blazor.RepositoryPattern.Services
{
    public class ColourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColourService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ColourResponse> GetColoursData()
        {
            try
            {
                var result = _unitOfWork.Colours.GetAll();
                var colours = _mapper.Map<List<ColourResponse>>(result);
                return colours;
            }
            catch
            {
                throw;
            }
        }
    }
}
