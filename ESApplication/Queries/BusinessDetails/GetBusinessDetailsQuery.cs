using ESApplication.AggregateModels;
using MediatR;

namespace ESApplication.Queries.GetBusiness
{
    public class GetBusinessDetailsQuery : IRequest<List<BusinessDto>>
    {
        public Int64 userid { get; set; }
        public Int64 id { get; set; }
    }
}
