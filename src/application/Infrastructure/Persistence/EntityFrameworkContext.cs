using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using domain.Model;

namespace application.Infrastructure.Persistence
{
    public class EntityFrameworkContext:DbContext,IEntityFrameworkContext
    {
        public EntityFrameworkContext():base("DefaultConnection"){}

        public DbEntityEntry<T> Entity<T>(T entity) where T : class, IEntity<int>
        {
            return Entry(entity);
        }

        public static EntityFrameworkContext Create()
        {
            return new EntityFrameworkContext();
        }

        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Product> Products { get; set; }
    }
}
