namespace PagePass.Application.Mappings
{
    public class DomainToTDOMappingsProfile : Profile
    {
        public DomainToTDOMappingsProfile()
        {
            CreateMap<ClienteEntity, ClienteDTO>().ReverseMap();
            CreateMap<UsuarioEntity,UsuarioDTO>().ReverseMap();
            CreateMap<LivroEntity, LivroDTO>().ReverseMap();
            CreateMap<EmprestimoDTO, EmprestimoEntity>().ReverseMap().
                    ForMember(dest => dest.LivroDTO, opt => opt.MapFrom(x => x.Livro)).
                    ForMember(dest => dest.ClienteDTO, opt => opt.MapFrom(x => x.Cliente));
            CreateMap<EmprestimoEntity, EmprestimoPostDTO>().ReverseMap();
            CreateMap<EmprestimoEntity, EmprestimoPutDTO>().ReverseMap();
            CreateMap<QuantidadeItensEntity, QuantidadeItemsDTO>().ReverseMap();
        }
    }
}