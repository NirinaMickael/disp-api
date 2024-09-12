using ESApplication.AggregateModels;
using MediatR;

namespace ESApplication.Queries.GetBusinessImages
{
    public class GetBusinessImagesDetailsQuery : IRequest<List<BusinessImagesDto>>
    {
        public Int64 id { get; set; }
    }
}
