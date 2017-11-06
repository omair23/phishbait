namespace Phishbait
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhishModel : DbContext
    {
        public PhishModel(): base("name=PhishModel")
        {

        }

        public virtual DbSet<Configuration> Config { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<UrlStatistic> UrlStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}
