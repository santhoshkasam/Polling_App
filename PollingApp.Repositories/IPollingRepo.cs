using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Repositories
{
  public interface IPollingRepo : IRepository<Polling>
  {

    List<TopicPolls> GetTopicPolls(int CategoryId);

  }
}
