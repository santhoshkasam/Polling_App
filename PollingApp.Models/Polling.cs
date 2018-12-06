using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Models
{
  public class Polling
  {
    [Key]
    public int PollingId { get; set; }
    public int TopicOptionMappingId { get; set; }
    public string Comments { get; set; }
    public int? AppUserId { get; set; }
    public DateTime SubmittedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }

    public virtual TopicOptionMapping TopicOptionMapping { get; set; }

  }
}
