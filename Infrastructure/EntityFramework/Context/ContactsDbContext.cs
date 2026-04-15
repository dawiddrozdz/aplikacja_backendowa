using AppCore.Models;
using AppCore.ValueObjects;
using Infrastructure.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework.Context;

public class ContactsDbContext : IdentityDbContext<CrmUser, CrmRole, string>
{
    private readonly IConfiguration _configuration;

    public DbSet<Person> People { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Organization> Organizations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("CrmDb"));
    }

    public ContactsDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ContactsDbContext(DbContextOptions<ContactsDbContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); // wymagane przez Identity

        builder.Entity<CrmUser>(entity =>
        {
            entity.Property(u => u.FirstName).HasMaxLength(100);
            entity.Property(u => u.LastName).HasMaxLength(100);
            entity.Property(u => u.Department).HasMaxLength(100);
            entity.HasIndex(u => u.Email).IsUnique();
        });

        builder.Entity<CrmRole>(entity =>
        {
            entity.Property(r => r.Name).HasMaxLength(20);
        });

        // Konfiguracji mapowania dziedziczenia TPH
        // Jedna tabela do przechowywnia wszystkich typów kontaktów
        builder.Entity<Contact>()
            .HasDiscriminator<string>("ContactType")
            .HasValue<Person>("Person")
            .HasValue<Company>("Company")
            .HasValue<Organization>("Organization");

        builder.Entity<Contact>(entity =>
        {
            entity.Property(p => p.Email).HasMaxLength(200);
            entity.Property(p => p.Phone).HasMaxLength(20);
            // dodoj ograniczenia dla pozostałych właściwości
        });

        builder.Entity<Person>(entity =>
        {
            entity.Property(p => p.BirthDate).HasColumnType("date");
            entity.Property(p => p.Gender).HasConversion<string>();
            // dodaj ograniczenia dla pozostałych właściwości
        });

        // definicja związku
        builder.Entity<Person>()
            .HasOne(p => p.Employer)
            .WithMany(e => e.Employees);


        // definicja związku
        builder.Entity<Organization>()
            .HasMany(o => o.Members)
            .WithOne(p => p.Organization);

        // przykładowa firma
        builder.Entity<Company>(entity =>
        {
            entity.HasData(
                new Company
                {
                    Id = Guid.Parse("516A34D7-CCFB-4F20-85F3-62BD0F3AF271"),
                    Name = "WSEI",
                    Industry = "edukacja",
                    Phone = "123567123",
                    Email = "biuro@wsei.edu.pl",
                    Website = "https://wsei.edu.pl",
                    Address = null,
                    DateTimeCreatedAt = default,
                    ContactStatus = ContactStatus.Active,
                }
            );
        });

        var address = new
        {
            Id = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"),
            City = "Kraków",
            Country = "Poland",
            PostalCode = "25-009",
            Street = "ul. Św. Filipa 17",
            AddressType = AddressType.Correspondence,
            // id osoby, która dodana jest niżej
            ContactId = Guid.Parse("3d54091d-abc8-49ec-9590-93ad3ed5458f")
        };

        // przykładowe kontakty typu Person
        builder.Entity<Person>(entity =>
        {
            entity.HasData(
                new
                {
                    Id = Guid.Parse("3d54091d-abc8-49ec-9590-93ad3ed5458f"),
                    FirstName = "Adam",
                    LastName = "Nowak",
                    MiddleName = "Jan",
                    Gender = Gender.Male,
                    ContactStatus = ContactStatus.Active,
                    Email = "adam@wsei.edu.pl",
                    Phone = "123456789",
                    BirthDate = DateTime.Parse("2001-01-11"),
                    Position = "Programista",
                    DateTimeCreatedAt = DateTime.Now,
                    DateTimeUpdatedAt = DateTime.Now
                },
                new
                {
                    Id = Guid.Parse("B4DCB17C-F875-43F8-9D66-36597895A466"),
                    FirstName = "Ewa",
                    LastName = "Kowalska",
                    MiddleName = "Maria",
                    Gender = Gender.Female,
                    ContactStatus = ContactStatus.Blocked,
                    Email = "ewa@wsei.edu.pl",
                    Phone = "123123123",
                    BirthDate = DateTime.Parse("2001-01-11"),
                    Position = "Tester",
                    DateTimeCreatedAt = DateTime.Now,
                    DateTimeUpdatedAt = DateTime.Now
                });
        });
        //mapowanie adresu jako typu osadzonej w encji Contact
        builder.Entity<Contact>()
            .OwnsOne(c => c.Address)
            .HasData(address);

        // Dodanie ról
        builder.Entity<CrmRole>().HasData(
            new CrmRole(UserRole.Administrator.ToString(), "Administrator role"),
            new CrmRole(UserRole.SalesManager.ToString(), "Sales Manager role"),
            new CrmRole(UserRole.Salesperson.ToString(), "Salesperson role"),
            new CrmRole(UserRole.SupportAgent.ToString(), "Support Agent role"),
            new CrmRole(UserRole.ReadOnly.ToString(), "Read Only role")
        );

        // Dodanie użytkowników
        builder.Entity<CrmUser>().HasData(
            new CrmUser
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111").ToString(),
                UserName = "admin@wsei.edu.pl",
                Email = "admin@wsei.edu.pl",
                FirstName = "Admin",
                LastName = "User",
                FullName = "Admin User",
                Department = "IT",
                Status = SystemUserStatus.Active,
                CreatedAt = DateTime.Now
            },
            new CrmUser
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222").ToString(),
                UserName = "user@wsei.edu.pl",
                Email = "user@wsei.edu.pl",
                FirstName = "Regular",
                LastName = "User",
                FullName = "Regular User",
                Department = "Sales",
                Status = SystemUserStatus.Active,
                CreatedAt = DateTime.Now
            }
        );
    }
}