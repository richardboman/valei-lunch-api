﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValeiLunchAPI.Data;

namespace ValeiLunchAPI.Data.Migrations
{
    [DbContext(typeof(LunchDbContext))]
    partial class LunchDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("ValeiLunchAPI.Lunches.Models.Lunch", b =>
                {
                    b.Property<int>("LunchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LunchId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Lunches");
                });

            modelBuilder.Entity("ValeiLunchAPI.Restaurants.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("ValeiLunchAPI.Lunches.Models.Lunch", b =>
                {
                    b.HasOne("ValeiLunchAPI.Restaurants.Models.Restaurant", "Restaurant")
                        .WithMany("Lunches")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
