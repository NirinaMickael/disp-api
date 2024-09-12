
 
namespace ESApplication.AggregateModels
{
    public class BusinessImagesDto
    {
        public Int64 Id { get; set; }
        public Int64 BusinessId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public int Isactive { get; set; }
        public int type { get; set; }
        public DateTime CreatedOn { get; set; }
    } 
}

 