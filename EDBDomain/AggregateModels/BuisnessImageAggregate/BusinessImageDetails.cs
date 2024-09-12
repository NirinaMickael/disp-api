
using ESDomain.SeedWork;

namespace ESDomain.AggregateModels.BusinessImageAggregate
{
    public class BusinessImageDetails : IAggregateRoot
    {              
        public Int64 Id { get; set; }
        public Int64 BusinessId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public Int16 Status { get; set; }
        public int Isactive { get; set; }           
        public int Action { get; set; }
        public int IsDeleted { get; set; }
        public Int64 UserId { get; set; }
        public int type { get; set; }


    }
} 