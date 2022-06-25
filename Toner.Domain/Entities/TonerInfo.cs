using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toner.Domain.Entities
{
   public class TonerInfo : BaseModel
   {
      [Key]
      public int TonerId { get; set; }

      public string TonerModel { get; set; }
      public string BW { get; set; }
      public string Cyan { get; set; }
      public string M { get; set; }
      public string Y { get; set; }
      public string K { get; set; }
      public double TotalMachineToner { get; set; }
      public double CurrentTonerStock { get; set; }
      public double InHouseTotalToner  { get; set; }
      public double LastMonthTotalTonerStock { get; set; }
      public double MonthlyDeliveryToner { get; set; }
      public double TotalTonerStock { get; set; }
      public double MonthlyUsedToner { get; set; }

      //public virtual IList<CustomerInfo>? CustomerInfos { get; set; }
   }
}
