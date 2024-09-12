using ESApplication.AggregateModels;
using MediatR;

namespace ESApplication.Queries.GetSiteDataDetails
{
    public class GetSiteDataDetailsQuery : IRequest<List<SiteDataDto>>
    {
        public Int64 userid { get; set; }
    }
}
