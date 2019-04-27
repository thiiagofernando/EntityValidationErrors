using System.Data.Entity;
using ValidationsErros.Models;

namespace ValidationsErros.Data
{
    public class ConexaoBdContext : DbContext
    {
        public ConexaoBdContext()
            :base("StringBD")
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
