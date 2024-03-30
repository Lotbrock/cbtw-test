using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IClientRespository Clients {  get; }
        IProductReceiptRepository ProductsReceipts { get; }
        IProductRepository Products { get; }
        IReceiptRepository Receipts { get; }

        Task<bool> CompleteAsync();
    }
}
