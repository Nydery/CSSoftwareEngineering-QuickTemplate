//@BaseCode
//MdStart

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

        private DbSet<E>? dbSet = null;
        public GenericController()
            : base(new DataContext.ProjectDbContext())
        {

        }
        public GenericController(ControllerObject other)
            : base(other)
        {

        }

        internal DbSet<E> EntitySet
        {
            get
            {
                if (dbSet == null)
                {
                    if (Context != null)
                    {
                        dbSet = Context.GetDbSet<E>();
                    }
                    else
                    {
                        using var ctx = new DataContext.ProjectDbContext();

                        dbSet = ctx.GetDbSet<E>();

                    }
                }
                return dbSet;
            }
        }

        #region Queries
        public virtual Task<E[]> GetAllAsync()
        {
            return EntitySet.AsNoTracking().ToArrayAsync();
        }
        public virtual ValueTask<E?> GetByIdAsync(int id)
        {
            return EntitySet.FindAsync(id); 
        }
        #endregion Queries

        #region Insert
        public virtual async Task<E> InsertAsync(E entity)
        {
            await EntitySet.AddAsync(entity).ConfigureAwait(false);
            return entity;
        }
        public virtual async Task<IEnumerable<E>> InsertAsync(IEnumerable<E> entities)
        {
            await EntitySet.AddRangeAsync(entities).ConfigureAwait(false);
            return entities;
        }
        #endregion Insert

        #region Update
        public virtual Task<E> UpdateAsync(E entity)
        {
            return Task.Run(() =>
            {
                EntitySet.Update(entity);
                return entity;
            });
        }
        public virtual Task<IEnumerable<E>> UpdateAsync(IEnumerable<E> entities)
        {
            return Task.Run(() =>
            {
                EntitySet.UpdateRange(entities);
                return entities;
            });
        }
        #endregion Update

        #region Delete
        public virtual Task DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                E? result = EntitySet.Find(id);

                if (result != null)
                {
                    EntitySet.Remove(result);
                }
            });
        }
        #endregion Delete

        #region SaveChanges
        public async Task<int> SaveChangesAsync()
        {
            var result = 0;

            if (Context != null)
            {
                result = await Context.SaveChangesAsync().ConfigureAwait(false);
            }
            return result;
        }
        #endregion SaveChanges
    }
}
//MdEnd