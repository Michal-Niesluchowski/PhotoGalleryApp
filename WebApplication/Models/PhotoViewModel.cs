using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PhotoViewModel
    {
        public PhotoItemViewModel[] Items { get; set; }

        public PhotoViewModel()
        {
            this.Items = new PhotoItemViewModel[0];
        }
    }
}
