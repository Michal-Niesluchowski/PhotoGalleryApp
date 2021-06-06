using System;
using System.ComponentModel.DataAnnotations;
using WebApplication.Services;

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

        internal PhotoItemDTO ToDto()
        {
            throw new NotImplementedException();
        }

        internal static PhotoItemViewModel FromDto(PhotoItemDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
