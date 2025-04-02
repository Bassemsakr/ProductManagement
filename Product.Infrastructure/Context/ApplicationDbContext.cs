using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProductManagement.Domian.Categories.Entity;
using ProductManagement.Domian.Common;
using ProductManagement.Domain.Products.Entities;

namespace ProductManagement.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.OwnsOne(p => p.Price, price =>
                {
                    price.Property(p => p.Value).HasColumnName("PriceValue");
                    price.Property(p => p.Currency).HasColumnName("PriceCurrency");
                });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEntities = ChangeTracker
                .Entries<Entity<Guid>>()
                .Where(x => x.Entity.DomainEvents.Any())
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

   
    }
}
