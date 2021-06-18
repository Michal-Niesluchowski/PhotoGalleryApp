using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class PhotoService
    {
        private string url = "http://localhost:37422";

        HttpClient httpClient = new HttpClient();

        public async Task<Guid> AddPhotoAsync(PhotoItemViewModel photo)
        {
            PhotoWebApiClient apiClient = new PhotoWebApiClient(url, httpClient);

            photo.OwnerId = "MN"; //improve when implementing authentication

            //Try to handle file parameter in nswag
            FileParameter fileParameterPhoto;
            using (var ms = new MemoryStream())
            {
                photo.PhotoFile.CopyTo(ms);
                ms.Position = 0;
                fileParameterPhoto = new FileParameter(ms, photo.PhotoFile.FileName);
            }

            //FAIL?? Need to manually convert file parameter to IFormFile??
            Guid result = await apiClient.PhotoAsync(photo.Id, photo.Title, photo.Description, photo.Tags,
                photo.OwnerId, photo.FileExtension, photo.UrlToImage, photo.UrlToThumbnail, fileParameterPhoto);

            return result;
        }
    }
}
