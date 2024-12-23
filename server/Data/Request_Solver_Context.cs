using Microsoft.EntityFrameworkCore;
using RequestSolver.Entities;

namespace RequestSolver.Data;
public class RequestSolverContext : DbContext
{
    //Constructor for Db context
    public RequestSolverContext(DbContextOptions<RequestSolverContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Request> Requests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            //make user_id primary key and auto generated
            entity.HasKey(u => u.user_id);
            entity.Property(u => u.user_id).ValueGeneratedOnAdd();

            //username is unique, required, and max char is 30
            entity.HasIndex(u => u.username).IsUnique();
            entity.Property(u => u.username).IsRequired().HasMaxLength(30);

            //Required and length properties
            entity.Property(u => u.password).IsRequired().HasMaxLength(50);
            entity.Property(u => u.email).IsRequired().HasMaxLength(50);
            entity.Property(u => u.first_name).IsRequired().HasMaxLength(30);
            entity.Property(u => u.last_name).IsRequired().HasMaxLength(30);
            entity.Property(u => u.user_type).IsRequired().HasMaxLength(30);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            //Request id is primary key
            entity.HasKey(rq => rq.request_id);

            entity.Property(rq => rq.title).IsRequired().HasMaxLength(50);
            entity.Property(rq => rq.level_of_severity).IsRequired().HasMaxLength(25);
            entity.Property(rq => rq.assigned_to_user_id).IsRequired();  // Foreign key
            entity.Property(rq => rq.assigned_by_user_id).IsRequired();  // Foreign key
            entity.Property(rq => rq.date_assigned).IsRequired();
            entity.Property(rq => rq.date_due).IsRequired();
            entity.Property(rq => rq.request_description).IsRequired().HasMaxLength(500);
            entity.Property(rq => rq.request_status).IsRequired().HasMaxLength(25);

            //Each request has one user that it points to when we assign it the foreign key to that user
            entity.HasOne<User>()
            .WithMany()
            .HasForeignKey(rq => rq.assigned_to_user_id)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<User>()
            .WithMany()
            .HasForeignKey(rq => rq.assigned_by_user_id)
            .OnDelete(DeleteBehavior.Restrict);
        });
    }
    
}