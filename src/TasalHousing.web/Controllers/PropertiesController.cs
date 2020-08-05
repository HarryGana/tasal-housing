using Microsoft.AspNetCore.Mvc;
using System;
using TasalHousing.web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasalHousing.web.Interfaces;

namespace TasalHousing.web.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
            

        [HttpGet]

        public IActionResult Index()
        {
            var properties = _propertyService.GetAllProperties();
            return View(properties);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]

        public async Task<IActionResult> Add(PropertyModel model)
        {
            try
            {
                await _propertyService.AddProperty(model);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
