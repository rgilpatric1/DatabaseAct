using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.ViewModels;
namespace CodeTheWay.Web.Ui.Controllers
{
    public class ShippingContainerController : Controller
    {
        private IShippingContainerService ShippingContainerService;

        public ShippingContainerController(IShippingContainerService shippingContainerService)
        {
            this.ShippingContainerService = shippingContainerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View(new ShippingContainerRegistrationViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(ShippingContainerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Weight > 1000)
                {
                    ShippingContainer shippingcontainer = new ShippingContainer()
                    {
                        Id = model.Id,
                        Weight = model.Weight,
                        Destination = model.Destination
                    };
                    var abc = await ShippingContainerService.Create(shippingcontainer);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var shippingcontainer = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel a = new ShippingContainerRegistrationViewModel()
            {
                Id = shippingcontainer.Id,
                Weight = shippingcontainer.Weight,
                Destination = shippingcontainer.Destination
            };
            return View(a);
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(ShippingContainerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Weight > 1000)
                {
                    ShippingContainer a = new ShippingContainer()
                    {
                        Id = model.Id,
                        Weight = model.Weight,
                        Destination = model.Destination
                    };
                    var student = await ShippingContainerService.Update(a);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var shippingcontainer = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel a = new ShippingContainerRegistrationViewModel()
            {
                Id = shippingcontainer.Id,
                Weight = shippingcontainer.Weight,
                Destination = shippingcontainer.Destination
            };
            return View(a);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var shippingcontainer = await ShippingContainerService.GetShippingContainer(id);
            await ShippingContainerService.Delete(shippingcontainer);
            return RedirectToAction("Index");
        }

    }
}
}
