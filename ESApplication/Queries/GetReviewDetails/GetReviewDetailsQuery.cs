using ESApplication.AggregateModels;
using ESApplication.Responses;
using MediatR; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESApplication.Queries.GetReviewDetails
{
    public class GetReviewDetailsQuery : IRequest<List<UserDetailsDto>>
    {
        public Int64 businessid { get; set; }
        public Int16 isactive { get; set; }
        public Int16 isquiz { get; set; }

    }
}
