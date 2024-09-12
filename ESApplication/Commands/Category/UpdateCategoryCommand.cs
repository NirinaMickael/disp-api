
using ESApplication.Responses;
using ESDomain.AggregateModels.UserDetailsAggregate;
using MediatR;
using System.Text.Json.Serialization;
 

namespace ESApplication.Commands.Category
{
    public class UpdateCategoryCommand : IRequest<Response<string>>
    {
        public Int64 userid { get; set; }
        public Int64 id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string categorycode { get; set; }
        public int action { get; set; }
        public int isactive { get; set; }
    }
}
