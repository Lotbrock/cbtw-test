using AutoMapper;
using Data.Repositories.Interfaces;

namespace cbtw_test.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

    }
}
