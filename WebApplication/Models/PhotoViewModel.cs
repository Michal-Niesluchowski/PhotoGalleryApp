using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PhotoViewModel
    {
        public PhotoItemViewModel[] Photos { get; set; }

        public PhotoViewModel()
        {
            Photos = new PhotoItemViewModel[0];
        }
    }
}
