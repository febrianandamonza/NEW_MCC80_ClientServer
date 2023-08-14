using API.DTOs.Roles;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

    // Pembuatan Table di Database pada Models
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountsRoles { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<University> Universities { get; set; }

    //Fluent API , Pembuatan UNIQUE
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>().HasData(new NewRoleDefaultDto
                                            {
                                                Guid = Guid.Parse("4887ec13-b482-47b3-9b24-08db91a71770"),
                                                Name = "Employee"
                                            },
                                            new NewRoleDefaultDto
                                            {
                                                Guid = Guid.Parse("53dd68fa-d4fd-492b-fecd-08db91d599ea"),
                                                Name = "Manager"
                                            },
                                            new NewRoleDefaultDto
                                            {
                                                Guid = Guid.Parse("de823e5e-cdc1-4f2d-fece-08db91d599ea"),
                                                Name = "Admin"
                                            });
        
        modelBuilder.Entity<Employee>()
                    .HasIndex(e => new{
                        e.Nik,
                        e.Email,
                        e.PhoneNumber
                    }).IsUnique();

        //One University with Many Education
        modelBuilder.Entity<University>()
            .HasMany(university => university.Educations)
            .WithOne(education => education.University)
            .HasForeignKey(education => education.UniversityGuid)
            .OnDelete(DeleteBehavior.Restrict);

        //One Room with Many Booking
        modelBuilder.Entity<Room>()
            .HasMany(r => r.Booking)
            .WithOne(b => b.Room)
            .HasForeignKey(b => b.RoomGuid)
            .OnDelete(DeleteBehavior.Restrict);

        
        //One Account with Many Account Role
        modelBuilder.Entity<Account>()
            .HasMany(a => a.AccountRoles)
            .WithOne(ar => ar.Account)
            .HasForeignKey(ar => ar.AccountGuid)
            .OnDelete(DeleteBehavior.Restrict);

        //One Role with Many Account Role
        modelBuilder.Entity<Role>()
            .HasMany(r => r.AccountRoles)
            .WithOne(ar => ar.Role)
            .HasForeignKey(ar => ar.RoleGuid)
            .OnDelete(DeleteBehavior.Restrict);

        //One Employee with Many Booking
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Booking)
            .WithOne(b => b.Employee)
            .HasForeignKey(b => b.EmployeeGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Employee with One Account
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Employee)
            .WithOne(e => e.Account)
            .HasForeignKey<Account>(a => a.Guid)
            .OnDelete(DeleteBehavior.Restrict);

        //One Employee with one Education
        modelBuilder.Entity<Education>()
            .HasOne(ed => ed.Employee)
            .WithOne(e => e.Education)
            .HasForeignKey<Education>(ed => ed.Guid)
            .OnDelete(DeleteBehavior.Cascade);

    }

}
