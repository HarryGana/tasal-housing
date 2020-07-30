using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasalHousing.web.Controllers
{
    public class PropertiesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
