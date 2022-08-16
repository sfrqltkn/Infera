using Infera_WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;

namespace Infera_WebApi.Context
{
    public class SqlServerDbContext : DbContext
    {
        IHttpContextAccessor _httpContextAccessor;
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> opt) : base(opt)
        {

        }
        public int GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }

            return Convert.ToInt16(result);
        }
        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;


                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                    entity.GetType().GetProperty("DeletedBy").SetValue(entity, GetMyName());
                    entity.GetType().GetProperty("DeletedAt").SetValue(entity, DateTime.Now);

                }

                if (entry.State == EntityState.Added)
                {
                    entity.GetType().GetProperty("CreatedBy").SetValue(entity, GetMyName());
                }
            }
            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Case>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Ticket>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<TicketNote>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(b => !b.IsDeleted);

            #region Users table
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();
            #endregion

            #region UserRole table


            modelBuilder.Entity<UserRole>()
                .HasKey(bc => new {bc.UserId, bc.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.UserRoles)
                .HasForeignKey(bc => bc.UserId);          

            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.Role)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(bc => bc.RoleId);

            #endregion
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketNote> TicketNotes { get; set; }
        public DbSet<Case> Cases { get; set; }
    } 
}
