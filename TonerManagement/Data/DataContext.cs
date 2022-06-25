using Microsoft.EntityFrameworkCore;
using Toner.Domain.Entities;

namespace TonerManagement.Data
{
   public class DataContext:DbContext
   {
      public DataContext(DbContextOptions<DataContext> options):base(options)
      {

      }
      public DbSet<CustomerInfo> CustomerInfos { get; set; }
      public DbSet<MachineInfo> MachineInfos { get; set; }
      public DbSet<TonerInfo> TonerInfos { get; set; }
      public DbSet<ProjectInfo> ProjectInfos { get; set; }
      public DbSet<UsesDetail> UsesDetails { get; set; }
      public DbSet<TonerDetail> TonerDetails { get; set; }
   }
}
