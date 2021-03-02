﻿// <auto-generated />
using System;
using EmployedAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployedAPI.Migrations
{
    [DbContext(typeof(ConferenceDbContext))]
    [Migration("20210228071313_API Inicial version")]
    partial class APIInicialversion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployedAPI.Models.Conference", b =>
                {
                    b.Property<int>("ConferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ConferenceDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConferenceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConferenceId");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("EmployedAPI.Models.SessionTalk", b =>
                {
                    b.Property<int>("SessionTalkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConferenceId")
                        .HasColumnType("int");

                    b.Property<string>("SessionTalkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpeakerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionTalkId");

                    b.HasIndex("ConferenceId");

                    b.ToTable("SessionTalk");
                });

            modelBuilder.Entity("EmployedAPI.Models.SessionTalk", b =>
                {
                    b.HasOne("EmployedAPI.Models.Conference", "FK_Conference")
                        .WithMany("SessionTalks")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FK_Conference");
                });

            modelBuilder.Entity("EmployedAPI.Models.Conference", b =>
                {
                    b.Navigation("SessionTalks");
                });
#pragma warning restore 612, 618
        }
    }
}