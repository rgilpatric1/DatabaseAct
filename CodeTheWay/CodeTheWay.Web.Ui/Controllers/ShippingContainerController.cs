using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Models.ViewModels;
using CodeTheWay.Web.Ui.Services; //CHECK
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CodeTheWay.Web.Ui.Controllers
{
    public class ShippingContainerController : Controller
    {
        private IShippingContainerService ShippingContainerService;

        public ShippingContainerController(IShippingContainerService shippingContainerService)
        {
            this.ShippingContainerService = shippingContainerService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await ShippingContainerService.GetShippingContainer());
        }

        public async Task<IActionResult> Create()
        {
            return View(new ShippingContainerRegistrationViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(ShippingContainerRegistrationViewModel model)
        {
            ShippingContainer shippingContainer = new ShippingContainer()
                    {
                        Id = model.Id,
                        Weight = model.Weight,
                        Destination = model.Destination
                    };
            var result = await ShippingContainerService.Create(shippingContainer);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var shippingContainer = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel test = new ShippingContainerRegistrationViewModel()
            {
                Id = shippingContainer.Id,
                Weight = shippingContainer.Weight,
                Destination = shippingContainer.Destination

            };
            return View(test);
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(ShippingContainerRegistrationViewModel model)
        {
            ShippingContainer shippingContainer = new ShippingContainer()
            {
                Id = model.Id,
                Weight = model.Weight,
                Destination = model.Destination
            };
            var result = await ShippingContainerService.Update(shippingContainer);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var shippingContainer = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel test = new ShippingContainerRegistrationViewModel()
            {
                Id = shippingContainer.Id,
                Weight = shippingContainer.Weight,
                Destination = shippingContainer.Destination

            };
            return View(test);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var shippingContainer = await ShippingContainerService.GetShippingContainer(id);
            await ShippingContainerService.Delete(shippingContainer);
            return RedirectToAction("Index");
        }
    }
}