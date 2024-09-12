using ESApplication.AggregateModels;
using MediatR;

namespace ESApplication.Queries.GetBusinessHours
{
    public class GetBusinessHoursDetailsQuery : IRequest<List<BusinessHoursDto>>
    {
        public Int64 id { get; set; }
    }
}
