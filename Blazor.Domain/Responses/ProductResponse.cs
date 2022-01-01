namespace Blazor.Domain.Responses
{
    public class ProductResponse : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int Price { get; set; }
        public int Amount { get; set; }
        public string? Brand { get; set; } = null!;
        public int SizeId { get; set; }
        public string? SizeName { get; set; } = null!;
        public int ColourId { get; set; }
        public string? ColourName { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                .ForMember(d => d.Brand, opt => opt.MapFrom(s => s.Brand))
                .ForMember(d => d.SizeId, opt => opt.MapFrom(s => s.Size.Id))
                .ForMember(d => d.SizeName, opt => opt.MapFrom(s => s.Size.Name))
                .ForMember(d => d.ColourId, opt => opt.MapFrom(s => s.Colour.Id))
                .ForMember(d => d.ColourName, opt => opt.MapFrom(s => s.Colour.Name));
        }

        public string? Error { get; set; }
    }
}
