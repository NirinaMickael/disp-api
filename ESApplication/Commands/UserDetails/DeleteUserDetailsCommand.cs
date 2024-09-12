
using ESApplication.Responses;
using ESDomain.AggregateModels.UserDetailsAggregate;
using MediatR;
using System.Text.Json.Serialization;
 

namespace ESApplication.Commands.UserDetails
{
    public class DeleteUserDetailsCommand : IRequest<Response<string>>
    {
        public int action { get; set; }
        public Int64 userid { get; set; } 
        public int isactive { get; set; } 
        public int type { get; set; }
    }
}
