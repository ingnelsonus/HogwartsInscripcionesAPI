using DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace DataAccess.Contracts
{
    public interface IHowartsSchoolRequestDBContext
    {
        DbSet<SolicitudIngresoEntitycs> SolicitudIngreso { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void RemoveRange(IEnumerable<object> entities);
        EntityEntry Update(object entity);

    }
}
