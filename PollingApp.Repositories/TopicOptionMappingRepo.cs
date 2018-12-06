using PollingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollingApp.Repositories
{
  public class TopicOptionMappingRepo : Repository<TopicOptionMapping>, ITopicOptionMappingRepo
  {
    private readonly IUnitOfWork uow;

    public TopicOptionMappingRepo(PollingAppContext context, IUnitOfWork uow) : base(context)
    {
      this.uow = uow;

    }
    public List<TopicWithOptions> GetTopicsWithOptions(int CategoryId)
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
                               topicOptionMappingId = to.TopicOptionMappingId,
                               optionId = to.OptionId,
                               topicId = to.TopicId,
                               optionName = to.OptionMaster.OptionName,
                               topicName = to.TopicMaster.TopicName
                             }).ToList()
               .Select(x => new
               {
                 TopicOptionMappingId = x.topicOptionMappingId,
                 OptionName = x.optionName,
                 TopicName = x.topicName,
               }).ToList();


      var topicPollsList1 = (from t in topicOptionList
                             group t by
                             new { t.TopicName } into g
                             select new TopicWithOptions
                             {
                               TopicName = g.Key.TopicName,
                               Options= string.Join("/", g.Select(s => s.OptionName).Distinct()).ToString(),
                               TopicOptionMappingId= string.Join("/", g.Select(s => s.TopicOptionMappingId).Distinct()).ToString()
                             }).ToList();
      return topicPollsList1;
    }
  }
}
