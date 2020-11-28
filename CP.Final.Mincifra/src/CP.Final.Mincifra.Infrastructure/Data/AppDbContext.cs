using Ardalis.EFCore.Extensions;
using CP.Final.Mincifra.Core.Entities;
using CP.Final.Mincifra.SharedKernel;
using CP.Final.Mincifra.SharedKernel.Interfaces;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CP.Final.Mincifra.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

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