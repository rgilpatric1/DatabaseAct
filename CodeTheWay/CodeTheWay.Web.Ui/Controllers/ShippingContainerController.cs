using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.ViewModels;
using CodeTheWay.Web.Ui.Models;


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
            if(ModelState.IsValid)
            {
                if(model.Weight > 0)
                {
                    ShippingContainer container = new ShippingContainer()
                    {
                      Id = model.Id,
                      Destination = model.Destination,
                      Weight = model.Weight
                    };
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View("model");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var shippingContainer = await ShippingContainerService.getShippingContainer(Id);

            ShippingContainerRegistrationViewModel container = new ShippingContainerRegistrationViewModel()
            {
                Id = container.Id,
                Weight = container.Weight,
                Destination = container.Destination

            };
        }




    }
}

