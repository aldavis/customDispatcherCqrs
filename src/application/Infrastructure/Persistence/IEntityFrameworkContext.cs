using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using domain.Model;

namespace application.Infrastructure.Persistence
{
    public interface IEntityFrameworkContext :IDisposable
    {
        DbEntityEntry<T> Entity<T>(T entity) where T : class, IEntity<int>;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IDbSet<Order> Orders { get; set; }

        IDbSet<Customer> Customers { get; set; }

        IDbSet<Product> Products { get; set; }
    }
}