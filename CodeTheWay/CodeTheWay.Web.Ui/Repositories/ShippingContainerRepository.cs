using CodeTheWay.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CodeTheWay.Web.Ui.Repositories
{
    public class ShippingContainerRepository : IShippingContainerRepository
    {
        private AppDbContext AppDbContext;

        public ShippingContainerRepository(AppDbContext dbContext)
        {
            this.AppDbContext = dbContext;
        }

        public async Task<ShippingContainer> Create(ShippingContainer container)
        {
            var result = await this.AppDbContext.ShippingContainer.AddAsync(container);
            await this.AppDbContext.SaveChangesAsync();
            return result.Entity;

        }

    }
}

