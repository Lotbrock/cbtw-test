using Data.Data;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IClientRespository Clients { get; }

        public IProductReceiptRepository ProductsReceipts { get; }

        public IProductRepository Products { get; }

        public IReceiptRepository Receipts { get; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory) 
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("logs");
            Clients = new ClientRepository(context, logger);
            ProductsReceipts = new ProductReceiptRepository(context, logger);
            Products = new ProductRepository(context, logger);
            Receipts =  new ReceiptRepository(context, logger);
        }
        public async Task<bool> CompleteAsync()
        {
           var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
