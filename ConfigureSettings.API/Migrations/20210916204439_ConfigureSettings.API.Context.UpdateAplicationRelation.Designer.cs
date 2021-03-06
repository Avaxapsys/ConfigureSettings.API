// <auto-generated />
using ConfigureSettings.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConfigureSettings.API.Migrations
{
    [DbContext(typeof(SettingsContext))]
    [Migration("20210916204439_ConfigureSettings.API.Context.UpdateAplicationRelation")]
    partial class ConfigureSettingsAPIContextUpdateAplicationRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConfigureSettings.API.Models.Aplications", b =>
                {
                    b.Property<int>("AplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AplicationId");

                    b.ToTable("Aplications");
                });

            modelBuilder.Entity("ConfigureSettings.API.Models.Settings", b =>
                {
                    b.Property<int>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SettingId");

                    b.HasIndex("AplicationId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("ConfigureSettings.API.Models.Settings", b =>
                {
                    b.HasOne("ConfigureSettings.API.Models.Aplications", "Aplication")
                        .WithMany("Settings")
                        .HasForeignKey("AplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aplication");
                });

            modelBuilder.Entity("ConfigureSettings.API.Models.Aplications", b =>
                {
                    b.Navigation("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}
