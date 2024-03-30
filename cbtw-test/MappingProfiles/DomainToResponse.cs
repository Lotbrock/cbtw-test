using AutoMapper;
using Entities.DbSet;
using Entities.DTOs.Responses;

namespace cbtw_test.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Client, ClientResponse>();
        }
    }
}
