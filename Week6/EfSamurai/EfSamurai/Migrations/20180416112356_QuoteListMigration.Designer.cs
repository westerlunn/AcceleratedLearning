﻿// <auto-generated />
using EfSamurai;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EfSamurai.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    [Migration("20180416112356_QuoteListMigration")]
    partial class QuoteListMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfSamurai.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QuoteString");

                    b.Property<int?>("SamuraiId");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("EfSamurai.Quote", b =>
                {
                    b.HasOne("EfSamurai.Samurai")
                        .WithMany("Quote")
                        .HasForeignKey("SamuraiId");
                });
#pragma warning restore 612, 618
        }
    }
}
