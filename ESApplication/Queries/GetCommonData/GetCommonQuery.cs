using ESApplication.AggregateModels;
using MediatR;

namespace ESApplication.Queries.GetCommonDetails
{
    public class GetCommonDetailsQuery : IRequest<List<CommonDto>>
    {
        public Int64 userid { get; set; }
        public int type { get; set; }
    }
}
