 
namespace ESApplication.AggregateModels
{
    public class CategoryDto
    { 
        public Int64 id { get; set; }
        public string code { get; set; }
        public string description { get; set; } 
        public int isactive { get; set; }
        public DateTime createdon { get; set; }
    } 
}
