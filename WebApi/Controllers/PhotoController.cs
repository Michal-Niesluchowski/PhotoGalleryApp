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
    [Produces("application/json")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private DatabaseContext _dbContext;
        private IConfiguration _configuration;

        public PhotoController(DatabaseContext dbContext, IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this._configuration = configuration;
        }

        [HttpGet("{ownerId}")]
        public ActionResult<IEnumerable<PhotoItemDTO>> Get(string ownerId)
        {
            //Prepare blob handler
            BlobHandler blobHandler = new BlobHandler(_configuration);

            //Get photos from database and Azure
            return _dbContext.PhotoEntities.Where(item => item.OwnerId == ownerId).Select(e => new PhotoItemDTO
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Tags = e.Tags
            }).ToList();
        }

        [HttpPost]
        public ActionResult<Guid> Post([FromForm] PhotoForm photo)
        {
            //Add image to blob
            Guid id = Guid.NewGuid();
            BlobHandler blobHandler = new BlobHandler(_configuration);
            blobHandler.SavePhoto(id, photo.PhotoFile);

            //Create new photo entity
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

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] PhotoItemDTO value)
        {
            var entity = _dbContext.PhotoEntities.SingleOrDefault(e => e.Id == id);

            if (entity != null)
            {
                entity.Tags = value.Tags;
                entity.Title = value.Title;
                entity.Description = value.Description;
                _dbContext.SaveChanges();
            }
        }
    }
}
