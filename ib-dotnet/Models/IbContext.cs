using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ib_dotnet.Models
{
    public class IbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public override int SaveChanges()
        {            
            foreach (var entry in ChangeTracker.Entries())
            {                
                if (entry.Entity is ILoggableEntity && entry.State == System.Data.EntityState.Added)
                {
                    ((ILoggableEntity)entry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public IbContext()
        {
            Configuration.ProxyCreationEnabled = false;
        }
    }
}