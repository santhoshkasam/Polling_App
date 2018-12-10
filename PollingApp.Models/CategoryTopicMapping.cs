using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models
{
  public class CategoryTopicMapping
  {
    [Key]
    public int CategoryTopicMappingId { get; set; }

    [Required]
    [Display(Name = "Category ID")]
    public int CategoryId { get; set; }

    [Required]
    [Display(Name = "Topic ID")]
    public int TopicId { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public virtual TopicMaster TopicMaster { get; set; }
    public virtual CategoryMaster TopicMaster { get; set; }

  }
}
