using ESApplication.AggregateModels;
using MediatR;

namespace ESApplication.Queries.GetDashboard
{
    public class GetDashboardDetailsQuery : IRequest<List<DashboardDto>>
    {
        public Int64 userid { get; set; }
        public Int64 businessid { get; set; }
    }
}
