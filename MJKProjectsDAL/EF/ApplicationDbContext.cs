using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MJKProjectsDAL.Models;

namespace MJKProjectsDAL.EF
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<PageContentSection> PageContentSections { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkHistory> WorkHistories { get; set; }
        public DbSet<Education> Educations { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>().Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");
            builder.Entity<BlogPost>().Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");
            builder.Entity<PageContentSection>().Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");

            builder.Entity<Skill>().Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");
            builder.Entity<Education>().Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");
            builder.Entity<WorkHistory>().Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");

            builder.Entity<Project>().HasIndex(i => i.Title).IsUnique();
            builder.Entity<BlogPost>().HasIndex(i => i.Title).IsUnique();
            builder.Entity<PageContentSection>().HasIndex(i => i.Title).IsUnique();

            builder.Entity<Skill>().HasIndex(i => i.Name).IsUnique();            
            builder.Entity<Education>().HasIndex(i => i.Name).IsUnique();
        }
    }
}
