﻿using AuthDatabase.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public PhotoController(IPhotoService photoService, UserManager<AppUser> userManager)
        {
            _photoService = photoService;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            
            if (currentUser == null)
            {
                return Challenge();
            }

            var photos = await _photoService.GetPhotosAsync(currentUser.Id);

            var model = new PhotoViewModel
            {
                Photos = photos
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPhoto(PhotoItemViewModel newPhoto)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Challenge();
            }

            Guid guid = await _photoService.AddPhotoAsync(newPhoto, currentUser.Id);

            return RedirectToAction("Index");
        }
    }
}
