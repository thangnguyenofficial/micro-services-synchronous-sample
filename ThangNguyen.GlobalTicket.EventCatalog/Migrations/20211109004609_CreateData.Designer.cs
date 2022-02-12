﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThangNguyen.GlobalTicket.EventCatalog.Infrastructure;

namespace ThangNguyen.GlobalTicket.EventCatalog.Migrations
{
    [DbContext(typeof(EventCatalogDbContext))]
    [Migration("20211109004609_CreateData")]
    partial class CreateData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThangNguyen.GlobalTicket.EventCatalog.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"),
                            Name = "Concerts"
                        },
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"),
                            Name = "Musicals"
                        },
                        new
                        {
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"),
                            Name = "Plays"
                        });
                });

            modelBuilder.Entity("ThangNguyen.GlobalTicket.EventCatalog.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Artist")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            EventId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"),
                            Artist = "John Egbert",
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"),
                            Date = new DateTime(2022, 5, 9, 7, 46, 9, 88, DateTimeKind.Local).AddTicks(7418),
                            Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                            ImageUrl = "/img/banjo.jpg",
                            Name = "John Egbert Live",
                            Price = 65
                        },
                        new
                        {
                            EventId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"),
                            Artist = "Michael Johnson",
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"),
                            Date = new DateTime(2022, 8, 9, 7, 46, 9, 89, DateTimeKind.Local).AddTicks(5478),
                            Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                            ImageUrl = "/img/michael.jpg",
                            Name = "The State of Affairs: Michael Live!",
                            Price = 85
                        },
                        new
                        {
                            EventId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"),
                            Artist = "Nick Sailor",
                            CategoryId = new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"),
                            Date = new DateTime(2022, 7, 9, 7, 46, 9, 89, DateTimeKind.Local).AddTicks(5564),
                            Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                            ImageUrl = "/img/musical.jpg",
                            Name = "To the Moon and Back",
                            Price = 135
                        });
                });

            modelBuilder.Entity("ThangNguyen.GlobalTicket.EventCatalog.Entities.Event", b =>
                {
                    b.HasOne("ThangNguyen.GlobalTicket.EventCatalog.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ThangNguyen.GlobalTicket.EventCatalog.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
