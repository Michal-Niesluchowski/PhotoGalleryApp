using Database;
using Microsoft.AspNetCore.Mvc;
using PhotoGalleryBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private DatabaseContext _dbContext;

        public PhotoController(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{ownerId}")]
        public ActionResult<IEnumerable<PhotoItemDTO>> Get(string ownerId)
        {
            return _dbContext.PhotoEntities.Where(item => item.OwnerId == ownerId).Select(e => new PhotoItemDTO
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Tags = e.Tags,
                
            }).ToList();
        }

        [HttpPost]
        public ActionResult<Guid> Post([FromBody] PhotoItemDTO value)
        {
            Guid id = Guid.NewGuid();
            _dbContext.PhotoEntities.Add(new PhotoEntity
            {
                Id = id,
                Title = value.Title,
                Description = value.Description,
                Tags = value.Tags,
                OwnerId = value.OwnerId
            });

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
