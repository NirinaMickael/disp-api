
using ESApplication.Responses;
using ESDomain.AggregateModels.UserDetailsAggregate;
using MediatR;
using System.Text.Json.Serialization;
 

namespace ESApplication.Commands.Promotion
{
    public class DeletePromotionCommand : IRequest<Response<string>>
    {
        public int action { get; set; }
        public Int64 userid { get; set; }
        public Int64 id { get; set; }
        public int isactive { get; set; } 
    }
}
