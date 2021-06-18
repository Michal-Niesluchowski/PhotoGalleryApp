using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PhotoItemDto
    {
        //Properties from database entity

        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string OwnerId { get; set; }

        public string FileExtension { get; set; }


        //Additional properites

        public string UrlToImage { get; set; }

        public string UrlToThumbnail { get; set; }

        [Required]
        public IFormFile PhotoFile { get; set; }
    }
}
