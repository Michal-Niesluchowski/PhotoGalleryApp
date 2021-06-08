using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class PhotoItemDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string OwnerId { get; set; }

        public string FilePath { get; set; }
    }
}
