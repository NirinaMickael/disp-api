using ESApplication.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESApplication.Commands.BusinessImages
{
    public class DeleteBusinessImagesCommand : IRequest<Response<string>>
    {
        public int Action { get; set; }
        public Int64 UserId { get; set; }
        public Int64 Id { get; set; }
        public string? ImagePath { get; set; }
        public Int64 Isactive { get; set; }

    }

}
