using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult Index()
        {
            return View(new PhotoViewModel());
        }
    }
}
