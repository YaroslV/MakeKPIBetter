using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CourseWork.Data
{
    public class AppContext : DbContext
    {

        public AppContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<TutorRegisterRequest> TutorRegisterRequests { get; set; }
    }
}