﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OlineLibrary.Data
{
    public partial class OnlineLibraryContext : DbContext
    {
        public OnlineLibraryContext()
        {
        }

        public OnlineLibraryContext(DbContextOptions<OnlineLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BorrowedBook> BorrowedBooks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VTESOPM\\MSSQLSERVER09;Database=OnlineLibrary;Trusted_Connection=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__Books__447D36EBA90D4DD3");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RackNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BorrowedBook>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BookIsbn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BookISBN");

                entity.Property(e => e.DateOfReturn).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.BookIsbnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.BookIsbn)
                    .HasConstraintName("FK__BorrowedB__BookI__534D60F1");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BorrowedB__UserI__5441852A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
