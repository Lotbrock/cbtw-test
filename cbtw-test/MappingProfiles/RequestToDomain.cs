using AutoMapper;
using Entities.DbSet;
using Entities.DTOs.Requests;

namespace cbtw_test.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateClientRequest, Client>()
                .ForMember(
                des => des.Status, 
                opt => opt.MapFrom(src => 1)
                );
            CreateMap<UpdateClientResquest, Client>()
                .ForMember(
                des => des.UpdateDate,
                opt => opt.MapFrom(src => DateTime.Now)
                );
            CreateMap<CreateProductRequest, Product>()
                .ForMember(
                des => des.Status,
                opt => opt.MapFrom(src => 1)
                );
            CreateMap<UpdateProductRequest, Product>()
                .ForMember(
                des => des.UpdateDate,
                opt => opt.MapFrom(src => DateTime.Now)
                );

        }
    }
}
