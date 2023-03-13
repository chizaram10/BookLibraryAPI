using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibraryAPI.Domain.Models
{
    public class BookLibraryContext : IdentityDbContext<User>
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.ISBN).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);

            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewId);
                entity.Property(e => e.Message).HasMaxLength(500);
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Book)
                    .WithMany(c => c.BookReviews)
                    .HasForeignKey(k => k.BookId);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
