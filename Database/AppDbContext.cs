using Microsoft.EntityFrameworkCore;
using Server.Modal;

namespace Server.Database
{
    public class AppDbContext : DbContext
    {   
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        // Define your DbSets (tables) here, for example:
        public DbSet<User> Users { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<VolunteerCase> VolunteerCase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Users table
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "password123", Phone = "123-456-7890", Address = "123 Elm St, Springfield", Role = Role.Admin },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password456", Phone = "987-654-3210", Address = "456 Oak St, Metropolis", Role = Role.Volunteer },
                new User { Id = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com", Password = "alicepwd789", Phone = "456-789-1234", Address = "789 Pine St, Gotham", Role = Role.Volunteer },
                new User { Id = 4, Name = "Bob Williams", Email = "bob.williams@example.com", Password = "bobpwd101", Phone = "789-123-4567", Address = "101 Maple St, Star City", Role = Role.Cooperator },
                new User { Id = 5, Name = "Eve Davis", Email = "eve.davis@example.com", Password = "evepwd202", Phone = "123-321-4567", Address = "202 Cedar St, Central City", Role = Role.Admin }
            );

            // Seed data for Cases table
            modelBuilder.Entity<Case>().HasData(
                new Case { Id = 1, Name = "Case Alpha", Address = "789 Birch St, Gotham", Description = "Investigation about environmental impact", CooperatorId = 1 },
                new Case { Id = 2, Name = "Case Beta", Address = "159 Cedar St, Star City", Description = "A study on urban development", CooperatorId = 2 },
                new Case { Id = 3, Name = "Case Gamma", Address = "202 Elm St, Metropolis", Description = "Research on traffic patterns", CooperatorId = 3 },
                new Case { Id = 4, Name = "Case Delta", Address = "345 Oak St, Springfield", Description = "Energy consumption analysis", CooperatorId = 4 },
                new Case { Id = 5, Name = "Case Epsilon", Address = "987 Maple St, Central City", Description = "Water quality monitoring", CooperatorId = 5 }
            );

            // Seed data for Reports table
            modelBuilder.Entity<Report>().HasData(
                new Report { Id = 1, Address = "789 Birch St, Gotham", Description = "Initial findings on air quality.", Email = "reporter1@example.com" },
                new Report { Id = 2, Address = "159 Cedar St, Star City", Description = "Preliminary analysis of traffic data.", Email = "reporter2@example.com" },
                new Report { Id = 3, Address = "202 Elm St, Metropolis", Description = "Research summary on congestion.", Email = "reporter3@example.com" },
                new Report { Id = 4, Address = "345 Oak St, Springfield", Description = "Energy report for industrial area.", Email = "reporter4@example.com" },
                new Report { Id = 5, Address = "987 Maple St, Central City", Description = "Analysis of water contaminants.", Email = "reporter5@example.com" }
            );
            //defining a composite primary key
            modelBuilder.Entity<VolunteerCase>().HasKey(vc => new { vc.volunteerId, vc.caseId });
            // Seeding initial data for VolunteerCase
            modelBuilder.Entity<VolunteerCase>().HasData(
                new VolunteerCase { volunteerId = 1, caseId = 1 },
                new VolunteerCase { volunteerId = 1, caseId = 2 },
                new VolunteerCase { volunteerId = 2, caseId = 3 },
                new VolunteerCase { volunteerId = 3, caseId = 4 },
                new VolunteerCase { volunteerId = 4, caseId = 5 }
            );
        }

    }
}
