using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PollingApp.Models;

namespace PollingApp.Repositories
{
  public  class CategoryMasterRepo : Repository<CategoryMaster>, ICategoryMasterRepo
    {
        public CategoryMasterRepo(PollingAppContext context) : base(context)
        {

        }

    }
}
