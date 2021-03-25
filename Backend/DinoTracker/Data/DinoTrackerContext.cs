using DinoTracker.Core;
using Microsoft.EntityFrameworkCore;

namespace DinoTracker.Data
{
    public class DinoTrackerContext : DbContext
    {
        public DbSet<Dino> Dinos { get; set; } = null!;

        public DbSet<Paleontologist> Paleontologists { get; set; } = null!;

        public DinoTrackerContext()
        {
        }
        public DinoTrackerContext(DbContextOptions<DinoTrackerContext> options)
        : base(options)
        {
        }
    }
}