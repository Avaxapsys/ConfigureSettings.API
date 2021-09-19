using ConfigureSettings.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfigureSettings.API.Context
{
    public class SettingsContext : DbContext
    {
        public SettingsContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Aplications> Aplications { get; set; }
    }
}
