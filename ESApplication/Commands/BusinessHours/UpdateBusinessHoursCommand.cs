
using ESApplication.Responses;
using MediatR;


namespace ESApplication.Commands.BusinessHours
{
    public class UpdateBusinessHoursCommand : IRequest<Response<string>>
    {
        public Int64 userid { get; set; }
        public Int64 id { get; set; }
        public Int64 businessid { get; set; }

        public int isactive { get; set; }
        public int action { get; set; }
        public string day { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public Int16 status { get; set; }

    }
}
