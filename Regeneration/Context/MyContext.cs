﻿using Microsoft.EntityFrameworkCore;
using Regeneration.Models;

namespace Regeneration.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<Creator> Creators { get; set; } = null!;
        public DbSet<Project> Projects { get; set; }=null!;
        public DbSet<Category> Category { get; set; }=null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BackerDonation>().HasKey(b => new { b.DonationProjectId, b.BackerId });

            modelBuilder.Entity<BackerDonation>()
                .HasOne(p => p.Backer)
                .WithMany(s => s.DonationProjects)
                .HasForeignKey(p => p.BackerId);

            modelBuilder.Entity<BackerDonation>()
                .HasOne(p => p.DonationProject)
                .WithMany(p => p.DonationProjects)
                .HasForeignKey(p => p.DonationProjectId);

        }

        public DbSet<Backer> Backers { get; set; } = null!;
        public DbSet<DonationProject> DonationProjects { get; set; } = null!;
        public DbSet<BackerDonation> BackerDonations { get; set; } = null!;
    }
}
