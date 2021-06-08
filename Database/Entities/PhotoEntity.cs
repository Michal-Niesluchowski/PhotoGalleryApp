using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotoGalleryBLL
{
    public class PhotoEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Tags { get; set; }

        public string OwnerId { get; set; }

        public string FileExtension { get; set; }
    }
}
