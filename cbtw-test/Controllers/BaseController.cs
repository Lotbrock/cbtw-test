using AutoMapper;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cbtw_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
