using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PollingApp.Models
{
    public class CategoryMaster
    {
        [Key]
        public int CategoryId { get; set; }
        
    
        public string CategoryCode { get; set; }
     
      
        public string CategoryName { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
