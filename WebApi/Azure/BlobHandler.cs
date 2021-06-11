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
        private readonly string FOLDER_NAME = "images";

        public BlobHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void SavePhoto(Guid photoId, IFormFile photoFile)
        {
            // Access containter
            string connectionString = _configuration.GetConnectionString("StorageConnectionString");
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, CONTAINER_NAME);
            blobContainerClient.CreateIfNotExists(PublicAccessType.Blob);

            // Create blob
            string blobPath = FOLDER_NAME + "/" + photoId.ToString() + Path.GetExtension(photoFile.FileName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobPath);

            //Save photo in blob
            using (var ms = new MemoryStream())
            {
                photoFile.CopyTo(ms);
                ms.Position = 0;
                blobClient.Upload(ms);
            }
            Debug.WriteLine(blobClient.Uri);
        }
    }
}
