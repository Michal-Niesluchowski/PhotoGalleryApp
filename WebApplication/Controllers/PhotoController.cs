using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index()
        {
            var photos = await _photoService.GetPhotosAsync("");

            var model = new PhotoViewModel
            {
                Photos = photos
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPhoto(PhotoItemViewModel newPhoto)
        {
            Guid guid = await _photoService.AddPhotoAsync(newPhoto);

            return RedirectToAction("Index");
        }
    }
}
