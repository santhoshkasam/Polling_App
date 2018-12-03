using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollingApp.Models;

namespace PollingApp.Repositories
{
    public class CategoryTopicMappingRepo : Repository<CategoryTopicMapping>, ICategoryTopicMappingRepo
    {
        public CategoryTopicMappingRepo(PollingAppContext context) : base(context)
        {

        }
    }
}