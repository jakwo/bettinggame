using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using bettinggame.data;

namespace bettinggame.api.Migrations
{
    [DbContext(typeof(BettingGameContext))]
    partial class BettingGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
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
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("User", "MatchId")
                        .IsUnique();

                    b.ToTable("Tips");
                });

            modelBuilder.Entity("bettinggame.data.Entities.Tip", b =>
                {
                    b.HasOne("bettinggame.data.Entities.Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
