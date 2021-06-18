using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using WebApplication.Services;

namespace WebApplication.Models
{
    public class PhotoItemViewModel
    {
        //Properties from database entity

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

        internal static PhotoItemDto ToDto()
        {
            throw new NotImplementedException();
        }
    }
}
