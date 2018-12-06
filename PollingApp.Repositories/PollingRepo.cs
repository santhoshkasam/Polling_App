using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Repositories
{
  public class PollingRepo : Repository<Polling>, IPollingRepo
  {
    private readonly IUnitOfWork uow;

    public PollingRepo(PollingAppContext context, IUnitOfWork uow) : base(context)
    {
      this.uow = uow;

    }


    public List<TopicPolls> GetTopicPolls(int CategoryId)
    {

      var categoryTopicMappingRepo = uow.GetRepository<CategoryTopicMapping>();
      var topicOptionMappingRepo = uow.GetRepository<TopicOptionMapping>();

      var topicList = (from topics in categoryTopicMappingRepo.SelectQuery(c => c.CategoryId == CategoryId)
                       select new
                       {
                         topicId = topics.TopicId
                       }).ToList();

      var topicOptionList = (from to in topicOptionMappingRepo.SelectQuery().ToList()
                             join tl in topicList on to.TopicId equals tl.topicId
                             select new
                             {
                               topicOptionMappingId = to.TopicOptionMappingId
                             }).ToList()
               .Select(x => new TopicOptionMapping
               {
                 TopicOptionMappingId = x.topicOptionMappingId
               }).ToList();

      var topicPollsList = (from tp in SelectQuery(null, null, t => t.TopicOptionMapping.TopicMaster, o => o.TopicOptionMapping.OptionMaster).ToList()
                            join to in topicOptionList on tp.TopicOptionMappingId equals to.TopicOptionMappingId
                            select new
                            {
                              topicName = tp.TopicOptionMapping.TopicMaster.TopicName,
                              optionName = tp.TopicOptionMapping.OptionMaster.OptionName,
                              comments = tp.Comments
                            }).ToList().Select(x => new TopicPolls
                            {
                              TopicName = x.topicName,
                              OptionNameWithCount = x.optionName,
                              Comments = x.comments
                            }).OrderBy(o => o.TopicName).ToList();

      var topicPollsList1 = (from t in topicPollsList
                             group t by
                             new { t.TopicName, t.OptionNameWithCount } into g
                             select new TopicPolls
                             {
                               TopicName = g.Key.TopicName,
                               OptionNameWithCount = g.Key.OptionNameWithCount + '-' + g.Count(),
                             }).ToList().GroupBy(t => t.TopicName).Select(d => new TopicPolls
                             {
                               TopicName = d.Key,
                               OptionNameWithCount = string.Join("/", d.Select(s => s.OptionNameWithCount).Distinct()).ToString()
                             }).ToList();
      return topicPollsList1;
    }

    private object GetPercentage(string topicOptionMappingId)
    {
      throw new NotImplementedException();
    }
  }
}
