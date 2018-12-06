﻿using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Repositories
{
  public interface ITopicOptionMappingRepo: IRepository<TopicOptionMapping>
  {
    List<TopicWithOptions> GetTopicsWithOptions(int CategoryId);
    
  }
}
