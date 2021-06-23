using Microsoft.AspNetCore.Mvc;
using CodeTheWay.Web.Ui.Services;
using CodeTheWay.Web.Ui.Models.ViewModels;
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
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View(new ShippingContainerRegistrationViewModel());
        }
    }
}
