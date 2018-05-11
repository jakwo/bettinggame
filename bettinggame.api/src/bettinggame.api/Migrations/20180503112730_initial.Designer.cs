using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using bettinggame.data;
using bettinggame.data.Entities;

namespace bettinggame.api.Migrations
{
    [DbContext(typeof(BettingGameContext))]
    [Migration("20180503112730_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bettinggame.data.Entities.Match", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AwayGoals");

                    b.Property<int>("AwayTeam");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("HomeGoals");

                    b.Property<int>("HomeTeam");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("bettinggame.data.Entities.Tip", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AwayGoals");

                    b.Property<int?>("HomeGoals");

                    b.Property<long>("MatchId");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("User", "MatchId")
                        .IsUnique();

                    b.ToTable("Tips");
                });

            modelBuilder.Entity("bettinggame.data.Entities.Tip", b =>
                {
                    b.HasOne("bettinggame.data.Entities.Match", "Match")
                        .WithMany("Tips")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
