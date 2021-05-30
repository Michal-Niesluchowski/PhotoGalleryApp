using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoGalleryBLL
{
    public class PhotoEntity
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }
        
        public string Comment { get; set; }
        
        public string Tag { get; set; }

        public string OwnerId { get; set; }
    }
}
