
using ESApplication.Responses;
using ESDomain.AggregateModels.UserDetailsAggregate;
using MediatR;
using System.Text.Json.Serialization;
 

namespace ESApplication.Commands.SiteData
{
    public class DeleteSiteDataCommand : IRequest<Response<string>>
    {
        public Int64 userid { get; set; }
        public Int64 id { get; set; } 
    }
}
