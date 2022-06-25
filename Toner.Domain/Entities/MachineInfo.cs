using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toner.Domain.Entities
{
   public class MachineInfo : BaseModel
   {
      /// <summary>
      /// Primary key of the table MachineInfo.
      /// </summary>
      [Key]
      public int MachineId { get; set; }

      /// <summary>
      /// Name of the Machine.
      /// </summary>
      //[Required(ErrorMessage = "Machine Name is required!")]
      [StringLength(200)]
      [Display(Name = "Machine Name")]
      public string MachineName { get; set; }

      /// <summary>
      /// Name of the MachineModel.
      /// </summary>
      [Required(ErrorMessage = "Machine Model is required!")]
      [StringLength(200)]
      [Display(Name = "Machine SI")]
      public string MachineSI { get; set; }


      /// <summary>
      /// Foreign key, Primary key of the ProjectInfo table.
      /// </summary>
      public int ProjectId { get; set; }

      [ForeignKey("ProjectId")]
      public virtual ProjectInfo? ProjectInfo { get; set; }

      public IList<UsesDetail>? UsesDetails { get; set; }
      ///// <summary>
      ///// Page Previous Count
      ///// </summary>
      //public int PreviousCount { get; set; }

      ///// <summary>
      ///// Page Current Count
      ///// </summary>
      //public int CurrentCount { get; set; }

      ///// <summary>
      ///// Page Total Count ( Page Current Count - Page Previous Count )
      ///// </summary>
      //public int TotalCount { get; set; }

      ///// <summary>
      ///// Printed Page Per Toner
      ///// </summary>
      //public int PrintedPagePerToner { get; set; }

      //public virtual IList<CustomerInfo> CustomerInfos { get; set; }
   }
}
