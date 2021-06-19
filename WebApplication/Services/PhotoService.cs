using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class PhotoService : IPhotoService
    {
        private string url = "http://localhost:63718/";

        HttpClient httpClient = new HttpClient();

        public async Task<Guid> AddPhotoAsync(PhotoItemViewModel photo)
        {
            PhotoWebApiClient apiClient = new PhotoWebApiClient(url, httpClient);

            photo.OwnerId = "MN"; //improve when implementing authentication

            //Convert iformfile to file parameter and sent http post to api
            Guid result;
            using (var ms = new MemoryStream())
            {
                photo.PhotoFile.CopyTo(ms);
                ms.Position = 0;
                FileParameter fileParameterPhoto = new FileParameter(ms, photo.PhotoFile.FileName, "image/jpeg");
                result = await apiClient.PhotoAsync(photo.Id, photo.Title, photo.Description, photo.Tags,
                photo.OwnerId, "", "", "", fileParameterPhoto);
            }

            return result;
        }

        public async Task<PhotoItemViewModel[]> GetPhotosAsync()
        {
            string ownerId = "MN"; //improve when implementing authentication

            PhotoWebApiClient apiClient = new PhotoWebApiClient(url, httpClient);

            IEnumerable<PhotoItemDto> photosDto = await apiClient.PhotoAllAsync(ownerId);

            return photosDto.Select(dto => PhotoItemViewModel.FromDto(dto)).ToArray();
        }
    }
}
