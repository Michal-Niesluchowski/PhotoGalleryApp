using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class PhotoItemViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string OwnerId { get; set; }

        public string FileExtension { get; set; }

        public 
    }
}
