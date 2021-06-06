using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class PhotoService
    {
        string url = "http://localhost:63718";

        HttpClient httpClient = new HttpClient();

        public async  Task<Guid> AddPhotoAsync(PhotoItemViewModel photo)
        {
            PhotoWebApiClient apiClient = new PhotoWebApiClient(url, httpClient);

            photo.OwnerId = "tempOwnerId";
            photo.Tags = "tempTags";
            photo.Title = "tempTitle";
            photo.Description = "tempDescription";

            Guid returnValue = await apiClient.PhotoAsync(photo.ToDto());

            return returnValue; 
        }

        public async Task<PhotoItemViewModel[]> GetPhotosAsync()
        {
            PhotoWebApiClient apiClient = new PhotoWebApiClient(url, httpClient);
            var dtoPhotos = await apiClient.PhotoAllAsync("tempOwnerId");
            return dtoPhotos.Select(dto => PhotoItemViewModel.FromDto(dto)).ToArray();
        }

        public async Task<bool> Mark
    }
}
 