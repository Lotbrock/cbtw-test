using AutoMapper;
using Entities.DbSet;
using Entities.DTOs.Requests;
using Entities.DTOs.Responses;

namespace cbtw_test.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Client, ClientResponse>();

            CreateMap<Receipt, PurchaseResponse>()
                .ForMember(
                des => des.FullName,
                opt => opt.MapFrom(src => $"{src.Client.Name} {src.Client.LastName}")
                )
                .ForMember(
                des => des.DocumentNumber,
                opt => opt.MapFrom(src => src.Client.DocumentNumber)
                )
                .ForMember(
                des => des.PhoneNumber,
                opt => opt.MapFrom(src => src.Client.PhoneNumber)
                )
                .ForMember(
                des => des.ProductsAmount,
                opt => opt.MapFrom(src => src.ProductReceipt.Count)
                )
                .ForMember(
                des => des.Total,
                opt => opt.MapFrom(src => src.Total)
                );
        }
    }
}
