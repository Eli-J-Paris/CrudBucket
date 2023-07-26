﻿// <auto-generated />
using CrudBucketMVC.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CrudBucketMVC.Migrations
{
    [DbContext(typeof(CrudBucketContext))]
    partial class CrudBucketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CrudBucketMVC.Models.Contienent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_contienents");

                    b.ToTable("contienents", (string)null);
                });

            modelBuilder.Entity("CrudBucketMVC.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Population")
                        .HasColumnType("integer")
                        .HasColumnName("population");

                    b.Property<int>("contienentId")
                        .HasColumnType("integer")
                        .HasColumnName("contienent_id");

                    b.HasKey("Id")
                        .HasName("pk_countries");

                    b.HasIndex("contienentId")
                        .HasDatabaseName("ix_countries_contienent_id");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("CrudBucketMVC.Models.Country", b =>
                {
                    b.HasOne("CrudBucketMVC.Models.Contienent", "contienent")
                        .WithMany("Countries")
                        .HasForeignKey("contienentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_countries_contienents_contienent_id");

                    b.Navigation("contienent");
                });

            modelBuilder.Entity("CrudBucketMVC.Models.Contienent", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
