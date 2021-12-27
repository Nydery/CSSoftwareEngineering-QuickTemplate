//@BaseCode
//MdStart
using Microsoft.EntityFrameworkCore;

namespace QuickTemplate.Logic.Controllers
{
    public abstract partial class GenericController<E> : ControllerObject where E : Entities.IdentityObject, new()
    {
        public GenericController()
            : base(new DataContext.ProjectDbContext())
        {

        }
        public GenericController(ControllerObject other)
            : base(other)
        {

        }

        internal DbSet<E> EntitySet => Context.GetDbSet<E>();
        internal virtual IQueryable<E> QueryableSet => Context.QueryableSet<E>();

        public virtual Task<E> GetByIdAsync(int id)
        {
            return EntitySet.FindAsync(id).AsTask();
        }
        public virtual async Task<E> InsertAsync(E entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await EntitySet.AddAsync(entity).ConfigureAwait(false);
            return entity;
        }
        public virtual async Task<IEnumerable<E>> InsertAsync(IEnumerable<E> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            await EntitySet.AddRangeAsync(entities).ConfigureAwait(false);
            return entities;
        }
        public virtual Task<E> UpdateAsync(E entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return Task.Run(() =>
            {
                EntitySet.Update(entity);
                return entity;
            });
        }
        public virtual Task DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                E result = EntitySet.Find(id);

                if (result != null)
                {
                    EntitySet.Remove(result);
                }
            });
        }
        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
//MdEnd