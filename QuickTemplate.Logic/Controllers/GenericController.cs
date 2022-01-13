//@BaseCode
//MdStart
using Microsoft.EntityFrameworkCore;

namespace QuickTemplate.Logic.Controllers
{
    public abstract partial class GenericController<E> : ControllerObject where E : Entities.IdentityObject, new()
    {
        static GenericController()
        {
            BeforeClassInitialize();
            AfterClassInitialize();
        }
        static partial void BeforeClassInitialize();
        static partial void AfterClassInitialize();

        private DbSet<E> dbSet = null;
        public GenericController()
            : base(new DataContext.ProjectDbContext())
        {

        }
        public GenericController(ControllerObject other)
            : base(other)
        {

        }

        internal DbSet<E> EntitySet => dbSet ??= Context.GetDbSet<E>();
        internal virtual IQueryable<E> QueryableSet => Context.QueryableSet<E>();

        #region Queries
        public virtual Task<E> GetByIdAsync(int id)
        {
            return EntitySet.FindAsync(id).AsTask();
        }
        #endregion Queries

        #region Insert
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
        #endregion Insert

        #region Update
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
        public virtual Task UpdateAsync(IEnumerable<E> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            return Task.Run(() =>
            {
                EntitySet.UpdateRange(entities);
            });
        }
        #endregion Update

        #region Delete
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
        #endregion Delete

        #region SaveChanges
        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
        #endregion SaveChanges
    }
}
//MdEnd