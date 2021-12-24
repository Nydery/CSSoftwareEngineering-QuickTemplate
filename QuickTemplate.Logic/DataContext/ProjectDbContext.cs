//@BaseCode
//MdStart
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QuickTemplate.Logic.DataContext
{
    internal partial class ProjectDbContext : DbContext
    {
        static ProjectDbContext()
        {
            try
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionString = configuration["ConnectionStrings:DefaultConnection"];

                if (string.IsNullOrEmpty(connectionString) == false)
                {
                    ConnectionString = connectionString;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in {System.Reflection.MethodBase.GetCurrentMethod().Name}: {ex.Message}");
            }
        }

        private static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=QuickTemplateDb;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<E> GetDbSet<E>() where E : Model.IdentityObject
        {
            var handled = false;
            var result = default(DbSet<E>);

            GetDbSet(ref result, ref handled);

            return result;
        }
        partial void GetDbSet<E>(ref DbSet<E> dbSet, ref bool handled) where E : Model.IdentityObject;
        public IQueryable<E> QueryableSet<E>() where E : Model.IdentityObject
        {
            return GetDbSet<E>();
        }
    }
}
//MdEnd