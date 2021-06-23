using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Services
{
    public class ShippingContainerService : IShippingContainerService
    {
        IShippingContainerRepository ShippingContainerRepository;

        public ShippingContainerService(AppDbContext dbContext)
        {
            this.ShippingContainerRepository = new ShippingContainerRepository(dbContext);
        }

        public async Task<ShippingContainer> Create(ShippingContainer shippingcontainer)
        {
            return await this.ShippingContainerRepository.Create(shippingcontainer);
        }

        public async Task<List<ShippingContainer>> GetShippingContainers()
        {
            return await this.ShippingContainerRepository.GetShippingContainers();
        }

        public async Task<ShippingContainer> GetShippingContainer(Guid id)
        {
            return await this.ShippingContainerRepository.GetShippingContainer(id);
        }
        public async Task<ShippingContainer> Update(ShippingContainer shippingcontainer)
        {
            return await ShippingContainerRepository.Update(shippingcontainer);
        }
        public async Task<ShippingContainer> Delete(ShippingContainer shippingcontainer)
        {
            return await ShippingContainerRepository.Delete(shippingcontainer);
        }
    }
}