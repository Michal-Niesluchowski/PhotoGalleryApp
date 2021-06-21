using Database;
using Microsoft.AspNetCore.Mvc;
using PhotoGalleryBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private DatabaseContext _dbContext;
        private IConfiguration _configuration;
        private BlobHandler _blobHandler;

        public PhotoController(DatabaseContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _blobHandler = new BlobHandler(_configuration);
        }

        [HttpGet("{ownerId}")]
        public ActionResult<IEnumerable<PhotoItemDto>> Get(string ownerId)
        {
            return _dbContext.PhotoEntities.Where(photo => photo.OwnerId == ownerId).Select(p => new PhotoItemDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Tags = p.Tags,
                FileExtension = p.FileExtension,
                OwnerId = p.OwnerId,
                UrlToImage = _blobHandler.GetUrlToImage(p.Id, p.FileExtension),
                UrlToThumbnail = _blobHandler.GetUrlToThumbnail(p.Id, p.FileExtension)
            }).ToList();
        }

        [HttpPost]
        public ActionResult<Guid> Post([FromForm] PhotoItemDto photo)
        {
            //Save image in blob
            Guid id = Guid.NewGuid();
            _blobHandler.SavePhoto(id, photo.PhotoFile);

            //Create new photo entity for db
            PhotoEntity newPhoto = new PhotoEntity
            {
                Id = id,
                Title = photo.Title,
                Description = photo.Description,
                Tags = photo.Tags,
                OwnerId = photo.OwnerId,
                FileExtension = Path.GetExtension(photo.PhotoFile.FileName)
            };

            //Save new photo to db
            _dbContext.PhotoEntities.Add(newPhoto);
            _dbContext.SaveChanges();

            return id;
        }
    }
}
