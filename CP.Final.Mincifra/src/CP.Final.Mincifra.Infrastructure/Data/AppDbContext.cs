using Ardalis.EFCore.Extensions;
using CP.Final.Mincifra.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP.Final.Mincifra.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher)
        //    : base(options)
        //{
        //    _dispatcher = dispatcher;
        //}

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<MetaData> MetaDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

            // alternately this is built-in to EF Core 2.2
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}