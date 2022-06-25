using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toner.Domain.Entities
{
   public class ProjectInfo:BaseModel
   {
      /// <summary>
      /// Primary key of the table ProjectInfo.
      /// </summary>
      [Key]
      public int ProjectId { get; set; }

      /// <summary>
      /// Name of the Project.
      /// </summary>
      [Required(ErrorMessage = "Project Name is required!")]
      [StringLength(200)]
      [Display(Name = "Project Name")]
      public string ProjectName { get; set; }

      /// <summary>
      /// Name of the Project.
      /// </summary>
      [StringLength(200)]
      [Display(Name = "Contact Number")]
      public string? ContactNumber { get; set; }

      /// <summary>
      /// Address of the Project.
      /// </summary>
      [StringLength(300)]
      [Display(Name = "Address")]
      public string? Address { get; set; }

      /// <summary>
      /// Foreign key, Primary key of the CustomerInfo table.
      /// </summary>
      [ForeignKey("CustomerId")]
      public int CustomerId { get; set; }

    
      public virtual CustomerInfo? CustomerInfo { get; set; }

      public IList<MachineInfo>? MachineInfos { get; set; }

      ///// <summary>
      ///// Foreign key, Primary key of the MachineInfo table.
      ///// </summary>
      //public int MachineId { get; set; }

      ///// <summary>
      ///// Foreign key, Primary key of the TonerInfo table.
      ///// </summary>
      //public int TonerId { get; set; }


      //[ForeignKey("MachineId")]
      //public virtual MachineInfo MachineInfo { get; set; }
      //[ForeignKey("TonerId")]
      //public virtual TonerInfo? TonerInfo { get; set; }
   }
}
