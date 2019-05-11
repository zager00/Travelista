using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ActivityServices.Model
{
    public class ActivityContext: DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options)
      : base(options)
        {
        }

        public DbSet<ActivityOrganiser> ActivityOrganiser { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityTimeSlot> ActivityTimeSlot { get; set; }
       
    }
}
