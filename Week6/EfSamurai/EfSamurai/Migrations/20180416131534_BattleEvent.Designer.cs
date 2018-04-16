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
    [Migration("20180416131534_BattleEvent")]
    partial class BattleEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfSamurai.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BattleLogId");

                    b.Property<bool>("Brutal");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("BattleLogId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("EfSamurai.BattleEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BattleLogId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventTime");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.HasIndex("BattleLogId");

                    b.ToTable("BattleEvent");
                });

            modelBuilder.Entity("EfSamurai.BattleLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BattleLog");
                });

            modelBuilder.Entity("EfSamurai.HairStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HairStyle");
                });

            modelBuilder.Entity("EfSamurai.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("QuoteString");

                    b.Property<int?>("QuoteTypeId");

                    b.Property<int?>("SamuraiId");

                    b.HasKey("Id");

                    b.HasIndex("QuoteTypeId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("EfSamurai.QuoteType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("QuoteType");
                });

            modelBuilder.Entity("EfSamurai.RealIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RealName");

                    b.HasKey("Id");

                    b.ToTable("RealIdentity");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int?>("HairStyleId");

                    b.Property<string>("Name");

                    b.Property<int?>("RealIdentityId");

                    b.HasKey("Id");

                    b.HasIndex("HairStyleId");

                    b.HasIndex("RealIdentityId")
                        .IsUnique()
                        .HasFilter("[RealIdentityId] IS NOT NULL");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("EfSamurai.SamuraiBattle", b =>
                {
                    b.Property<int>("SamuraiId");

                    b.Property<int>("BattleId");

                    b.HasKey("SamuraiId", "BattleId");

                    b.HasIndex("BattleId");

                    b.ToTable("SamuraiBattle");
                });

            modelBuilder.Entity("EfSamurai.Battle", b =>
                {
                    b.HasOne("EfSamurai.BattleLog", "BattleLog")
                        .WithMany()
                        .HasForeignKey("BattleLogId");
                });

            modelBuilder.Entity("EfSamurai.BattleEvent", b =>
                {
                    b.HasOne("EfSamurai.BattleLog")
                        .WithMany("BattleEvents")
                        .HasForeignKey("BattleLogId");
                });

            modelBuilder.Entity("EfSamurai.Quote", b =>
                {
                    b.HasOne("EfSamurai.QuoteType", "QuoteType")
                        .WithMany()
                        .HasForeignKey("QuoteTypeId");

                    b.HasOne("EfSamurai.Samurai")
                        .WithMany("Quote")
                        .HasForeignKey("SamuraiId");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.HasOne("EfSamurai.HairStyle", "HairStyle")
                        .WithMany()
                        .HasForeignKey("HairStyleId");

                    b.HasOne("EfSamurai.RealIdentity", "RealIdentity")
                        .WithOne("Samurai")
                        .HasForeignKey("EfSamurai.Samurai", "RealIdentityId");
                });

            modelBuilder.Entity("EfSamurai.SamuraiBattle", b =>
                {
                    b.HasOne("EfSamurai.Battle", "Battle")
                        .WithMany()
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EfSamurai.Samurai", "Samurai")
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
