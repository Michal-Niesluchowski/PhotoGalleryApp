//Refactor opportunity - convert to singleton class

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi;
using WebApi.Models;

namespace WebApi.Azure
{
    public class BlobHandler
    {
        private IConfiguration _configuration;
        private readonly string CONTAINER_NAME = "photogallery";
        private readonly string FOLDER_NAME_IMAGES = "images";
        private readonly string FOLDER_NAME_THUMBNAILS = "thumbnails";
        private string _connectionString;
        private string _azureAddress;

        public BlobHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("StorageConnectionString");
            _azureAddress = _configuration.GetConnectionString("AzureAddress"); 
        }
        
        public void SavePhoto(Guid photoId, IFormFile photoFile)
        {
            // Access containter
            BlobContainerClient blobContainerClient = new BlobContainerClient(_connectionString, CONTAINER_NAME);
            blobContainerClient.CreateIfNotExists(PublicAccessType.Blob);

            // Create blob
            string blobPath = FOLDER_NAME_IMAGES + "/" + photoId.ToString() + Path.GetExtension(photoFile.FileName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobPath);

            //Save photo in blob
            using (var ms = new MemoryStream())
            {
                photoFile.CopyTo(ms);
                ms.Position = 0;
                blobClient.Upload(ms);
            }
        }

        public string GetUrlToImage(Guid photoId, string fileExtension)
        {
            return _azureAddress
                + "/" + CONTAINER_NAME
                + "/" + FOLDER_NAME_IMAGES 
                + "/" + photoId.ToString() + fileExtension;
        }

        public string GetUrlToThumbnail(Guid photoId, string fileExtension)
        {
            return _azureAddress
                + "/" + CONTAINER_NAME
                + "/" + FOLDER_NAME_THUMBNAILS
                + "/" + photoId.ToString() + fileExtension;
        }
    }
}
