using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PhotoItemDTO
    {
        //Properties binded with Swagger
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public IFormFile PhotoFile { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }

        //Properties skipped in Swagger 
        internal Guid Id { get; set; }
        internal string FileExtension { get; set; }
        internal string UrlToImage { get; set; }
        internal string UrlToThumbnail { get; set; }
    }
}
