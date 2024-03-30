using Data.Data;
using Data.Repositories.Interfaces;
using Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductReceiptRepository : GenericRepository<ProductReceipt>, IProductReceiptRepository
    {
        public ProductReceiptRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<ProductReceipt>> GetAll()
        {
            try
            {
                return await _dbSet.Where(d => d.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(d => d.AddDate)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repo: Function Error ", typeof(ProductReceiptRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {

                var entity = await _dbSet.Where(d => d.Id == id).FirstOrDefaultAsync();

                if (entity == null)
                {
                    return false;
                }

                entity.Status = 0;
                entity.UpdateDate = DateTime.Now;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repo: Function Error ", typeof(ProductReceiptRepository));
                throw;

            }
        }

        public override async Task<bool> Update(ProductReceipt entity)
        {
            try
            {
                var old = await _dbSet.FirstOrDefaultAsync(c => c.Id == entity.Id);
                
                old.Quantity = entity.Quantity;
                old.UpdateDate = DateTime.Now;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repo: Function Error ", typeof(ProductReceiptRepository));
                throw;

            }
        }
    }
}
