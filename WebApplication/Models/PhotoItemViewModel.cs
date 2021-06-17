using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class PhotoItemViewModel
    {
        //Properties binded with asp form
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public IFormFile PhotoFile { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }

        //Properties skipped in asp form 
        internal Guid Id { get; set; }
        internal string FileExtension { get; set; }
        public string UrlToImage { get; set; }
        public string UrlToThumbnail { get; set; }
    }
}
