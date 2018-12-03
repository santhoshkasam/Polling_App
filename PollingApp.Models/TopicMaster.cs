using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models
{
  public class TopicMaster
  {
    [Key]
    public int TopicId { get; set; }
    [Required]
    [MaxLength(10)]
    [Display(Name = "Topic Code")]
    public string TopicCode { get; set; }
    [Required]
    [MaxLength(50)]
    [Display(Name = "Topic Name")]
    public string TopicName { get; set; }
    [Required]
    [DisplayName("Created Date")]
    public DateTime CreatedDate { get; set; }
    [Display(Name = "Created By")]
    public int? CreatedBy { get; set; }
    [Display(Name = "Last Modified By")]
    public int? LastModifiedBy { get; set; }
    [Display(Name = "Last Modified Date")]
    public DateTime? LastModifieddate { get; set; }

  }
}
