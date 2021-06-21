using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PhotoGalleryViewModel
    {
        public PhotoItemViewModel[] Photos { get; set; }

        public PhotoGalleryViewModel()
        {
            Photos = new PhotoItemViewModel[0];
        }
    }
}
