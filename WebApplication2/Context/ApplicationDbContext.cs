using Entity;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Entity.User> Users { get; set; }
        public DbSet<Entity.Task> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity.User>()
                .ToTable("users");

            // tasksテーブルのUserへの外部キー制約を設定
            modelBuilder.Entity<Entity.Task>()
                .ToTable("tasks")
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}