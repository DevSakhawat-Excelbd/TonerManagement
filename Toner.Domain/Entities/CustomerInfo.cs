using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toner.Domain.Entities
{
   public class CustomerInfo:BaseModel
   {
      /// <summary>
      /// Primary key of the table Customer.
      /// </summary>
      [Key]
      public int CustomerId { get; set; }

      /// <summary>
      /// Name of the Customer.
      /// </summary>
      [Required(ErrorMessage = "Customer Name is required!")]
      [StringLength(200)]
      [Display(Name = "Customer Name")]
      public string CustomerName { get; set; }

      /// <summary>
      /// Name of the Customer.
      /// </summary>
      [StringLength(14)]
      [Display(Name = "Contact Number")]
      public string? ContactNumber { get; set; }

      /// <summary>
      /// Address of the Customer.
      /// </summary>
      [StringLength(300)]
      [Display(Name = "Address")]
      public string? Address { get; set; }

      public IList<ProjectInfo>? ProjectInfos { get; set; }


      //[ForeignKey("MachineId")]
      //public virtual MachineInfo MachineInfo { get; set; }
      //[ForeignKey("TonerId")]
      //public virtual TonerInfo? TonerInfo { get; set; }

   }
}
