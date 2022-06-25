using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toner.Domain.Entities
{
   public class TonerDetail:BaseModel
   {
      [Key]
      public int TonerDetailId { get; set; }
      /// <summary>
      /// TotalMachineToner = TonerPercentage(from usesdetails table) / 100 
      /// </summary>
      public double TotalMachineToner { get; set; }
      public double CurrentTonerStock { get; set; }
      public double InHouseTotalToner { get; set; }
      public double LastMonthTotalTonerStock { get; set; }
      public double MonthlyDeliveryToner { get; set; }
      public double TotalTonerStock { get; set; }
      public double MonthlyUsedToner { get; set; }

      public int UsesDetailId { get; set; }
      //public int MachineId { get; set; }
      //public int ProjectId { get; set; }
      //public int CustomerId { get; set; }

      [ForeignKey("UsesDetailId")]
      public virtual UsesDetail? UsesDetail { get; set; }

      //[ForeignKey("MachineId")]
      //public virtual MachineInfo? MachineInfo { get; set; }

      //[ForeignKey("ProjectId")]
      //public virtual ProjectInfo? ProjectInfo { get; set; }

      //[ForeignKey("CustomerId")]
      //public virtual CustomerInfo? CustomerInfo { get; set; }
   }
}
