using AutoMapper;
using Data.Repositories.Interfaces;

namespace cbtw_test.Controllers
{
    public class SellController : BaseController
    {
        public SellController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

    }
}


