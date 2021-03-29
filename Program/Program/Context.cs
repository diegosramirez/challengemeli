using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Program
{
    public class Context : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Algorithm> Algorithms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;User Id=postgres;Password=Socios1905;Database=challengeml;");
        }
    }

    [Table("applications")]
    public class Application
    {
        [Column("id")]
        public int ApplicationId { get; set; }

        [Column("name")]
        public string Name { get; set; }
        public Configuration Configuration { get; set; }
    }

    [Table("configurations")]
    public class Configuration
    {
        [Column("id")]
        public int ConfigurationId { get; set; }


        [Column("application_id")]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }


        [Column("algorithm_id")]
        public int AlgorithmId { get; set; }
        public Algorithm Algorithm { get; set; }
    }

    [Table("algorithms")]
    public class Algorithm
    {
        [Column("id")]
        public int AlgorithmId { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
