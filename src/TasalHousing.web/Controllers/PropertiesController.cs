﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasalHousing.web.Controllers
{
    public class PropertiesController : Controller
    {

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(PropertyModel model)
        {
            throw new NotImplementedException();
        }
    }
}
