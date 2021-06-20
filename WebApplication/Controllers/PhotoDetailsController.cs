using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PhotoDetailsController : Controller
    { 
        public IActionResult Index(PhotoItemViewModel photo)
        {
            var model = photo;

            return View(model);
        }
    }
}
