using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toner.Domain.Entities
{
   public class UsesDetail:BaseModel
   {
      [Key]
      public int UsesDetailId { get; set; }
      [Required(ErrorMessage = "Previous Count required!")]
      [Display(Name = "Previous Count")]
      public int PrevCount { get; set; }
      [Required(ErrorMessage = "Current Count required!")]
      [Display(Name = "Current Count")]
      public int CurCount { get; set; }
      [Required(ErrorMessage = "Total Count required!")]
      [Display(Name = "Total Count")]
      public int TotalCount { get; set; }
      [Required(ErrorMessage = "Total Percentage required!")]
      [Display(Name = "Total Percentage")]
      public int  TonerPercentage { get; set; }

      /// <summary>
      /// Foreign key, Primary key of the MachineInfo table.
      /// </summary>
      public int MachineId { get; set; }


      [ForeignKey("MachineId")]
      public virtual MachineInfo? MachineInfo { get; set; }

      public IList<TonerDetail>? TonerDetails { get; set; }
   }
}
