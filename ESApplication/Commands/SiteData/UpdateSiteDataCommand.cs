
using ESApplication.Responses;
using ESDomain.AggregateModels.UserDetailsAggregate;
using MediatR;
using System.Text.Json.Serialization;
 

namespace ESApplication.Commands.SiteData
{
    public class UpdateSiteDataCommand : IRequest<Response<string>>
    {
        public Int64 userid { get; set; }
        public Int64 id { get; set; }
        public string type { get; set; }
        public string filename { get; set; }
        public string description { get; set; }
        public string base64text { get; set; }
    }
}
