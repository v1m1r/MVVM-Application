using System.Data.Entity;

namespace SizeDB2.Model
{
  public  class ApplicationContext :DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<CitiesLimit> CitiesLimits { get; set; }
    }
}
