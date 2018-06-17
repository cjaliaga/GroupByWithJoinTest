using System;
using System.Text;
using GroupByTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace GroupByTest
{
    class ShowsDbContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public DbSet<Show> Shows { get; set; }
        public DbSet<FollowShow> FollowShows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;;Database=TestShows;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Show>().HasData(
                new Show
                {
                    Id = 1,
                    Name = "Friends"
                },
                new Show
                {
                    Id = 2,
                    Name = "Game of Thrones"
                });

            modelBuilder.Entity<FollowShow>().HasData(
                new FollowShow
                {
                    Id = 1,
                    ShowId = 1,
                    Followed = DateTime.Now,
                },
                new FollowShow
                {
                    Id = 2,
                    ShowId = 1,
                    Followed = DateTime.Now,
                },
                new FollowShow
                {
                    Id = 3,
                    ShowId = 1,
                    Followed = DateTime.Now,
                },
                new FollowShow
                {
                    Id = 4,
                    ShowId = 1,
                    Followed = DateTime.Now,
                },
                new FollowShow
                {
                    Id = 5,
                    ShowId = 1,
                    Followed = DateTime.Now,
                },
                new FollowShow
                {
                    Id = 6,
                    ShowId = 2,
                    Followed = DateTime.Now,
                },
                new FollowShow
                {
                    Id = 7,
                    ShowId = 2,
                    Followed = DateTime.Now,
                },
                new FollowShow
                {
                    Id = 8,
                    ShowId = 2,
                    Followed = DateTime.Now,
                }
            );
        }
    }
}
