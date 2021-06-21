using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;
        private string _apiUrl;
        HttpClient httpClient = new HttpClient();

        public PhotoService(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl = _configuration.GetConnectionString("ApiUrl");
        }

        public async Task<Guid> AddPhotoAsync(PhotoItemViewModel photo, string ownerId)
        {
            //Initialize
            PhotoWebApiClient apiClient = new PhotoWebApiClient(_apiUrl, httpClient);
            Guid result;
            photo.OwnerId = ownerId;

            //Assign nulls to get ready for http transfer
            photo.FileExtension = "";
            photo.UrlToImage = "";
            photo.UrlToThumbnail = "";

            //Convert PhotoFile type from IFormFile to to get ready for http transfer
            //And send to api
            using (var memoryStream = new MemoryStream())
            {
                photo.PhotoFile.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                FileParameter fileParameterPhoto = new FileParameter(memoryStream, photo.PhotoFile.FileName, "image/jpeg");
                result = await apiClient.PhotoAsync(photo.Id, photo.Title, photo.Description, photo.Tags,
                photo.OwnerId, photo.FileExtension, photo.UrlToImage, photo.UrlToThumbnail, fileParameterPhoto);
            }

            return result;
        }

        public async Task<PhotoItemViewModel[]> GetPhotosAsync(string ownerId)
        {
            PhotoWebApiClient apiClient = new PhotoWebApiClient(_apiUrl, httpClient);

            IEnumerable<PhotoItemDto> photosDto = await apiClient.PhotoAllAsync(ownerId);

            return photosDto.Select(dto => PhotoItemViewModel.FromDto(dto)).ToArray();
        }
    }
}
