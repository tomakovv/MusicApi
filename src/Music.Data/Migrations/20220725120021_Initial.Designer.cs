﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Music.Data;

#nullable disable

namespace Music.Data.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20220725120021_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Music.Data.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Music.Data.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Music.Data.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Music.Data.Entities.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Music.Data.Entities.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaylistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Music.Data.Entities.Album", b =>
                {
                    b.HasOne("Music.Data.Entities.Artist", null)
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("Music.Data.Entities.Song", b =>
                {
                    b.HasOne("Music.Data.Entities.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");

                    b.HasOne("Music.Data.Entities.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Music.Data.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Music.Data.Entities.Playlist", null)
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistId");

                    b.Navigation("Album");

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Music.Data.Entities.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Music.Data.Entities.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Music.Data.Entities.Playlist", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}