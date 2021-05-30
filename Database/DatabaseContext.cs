using Microsoft.EntityFrameworkCore;
using PhotoGalleryBLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions opt): base(opt)
        {

        }

        protected DatabaseContext()
        {

        }

        public virtual DbSet<PhotoEntity> PhotoEntities { get; set; }
    }
}
