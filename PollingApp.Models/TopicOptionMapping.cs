using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models
{
  public class TopicOptionMapping
  {
    [Key]
    public int TopicOptionMappingId { get; set; }
    public int TopicId { get; set; }
    public int OptionId { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int? LastModifiedBy { get; set; }
    public virtual TopicMaster TopicMaster { get; set; }
    public virtual OptionMaster OptionMaster { get; set; }


  }
}
