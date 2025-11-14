using Microsoft.EntityFrameworkCore;
using RodentBase_01.WebAPI.Domain.Entities;

namespace RodentBase_01.WebAPI.Infrastructure.Persistance;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Animal entity configuration
        builder.Entity<Animal>()
            .HasOne(a => a.Association)
            .WithMany()
            .HasForeignKey(a => a.AssociationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Animal>()
            .HasOne(a => a.Litter)
            .WithMany()
            .HasForeignKey(a => a.LitterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Animal>()
            .HasOne(a => a.Owner)
            .WithMany()
            .HasForeignKey(a => a.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Animal>()
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Entity<Animal>()
            .Property(a => a.Sex)
            .IsRequired()
            .HasMaxLength(20);

        // Litter entity configuration
        builder.Entity<Litter>()
            .HasMany(l => l.Animals)
            .WithOne();

        builder.Entity<Litter>()
            .HasOne(l => l.Species)
            .WithMany()
            .HasForeignKey(l => l.SpeciesId);

        builder.Entity<Litter>()
            .HasOne(l => l.Breeder)
            .WithMany()
            .HasForeignKey(l => l.BreederId);

        builder.Entity<Litter>()
            .HasOne(l => l.Mother)
            .WithMany()
            .HasForeignKey(l => l.MotherId);

        builder.Entity<Litter>()
            .HasOne(l => l.Father)
            .WithMany()
            .HasForeignKey(l => l.FatherId);

        // Species entity configuration
        builder.Entity<Species>()
            .HasOne(s => s.Association)
            .WithMany()
            .HasForeignKey(s => s.AssociationId);

        // Association entity configuration
        builder.Entity<Association>()
            .HasMany(a => a.Animals)
            .WithOne();



        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var properties = entity.GetProperties()
                .Where(p => p.ClrType == typeof(string) && p.GetMaxLength() == null);

            foreach (var property in properties)
            {
                property.SetMaxLength(255);
            }
        }

        base.OnModelCreating(builder);
    }

    DbSet<Animal> Animals { get; set; }
    DbSet<Association> Associations { get; set; }
    DbSet<AssociationRole> AssociationRoles { get; set; }
    DbSet<AssociationRolePermission> AssociationRolePermissions { get; set; }
    DbSet<AssociationUserRole> AssociationUserRoles { get; set; }
    DbSet<Litter> Litters { get; set; }
    DbSet<Permission> Permissions { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<Species> Species { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserRole> UserRoles { get; set; }

}
