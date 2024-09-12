 
namespace ESApplication.AggregateModels
{
    public class SiteDataDto
    {
        public Int64 userid { get; set; }
        public Int64 id { get; set; }
        public string type { get; set; }
        public string filename { get; set; }
        public string filepath { get; set; }
        public string description { get; set; } 
        public string base64text { get; set; }
        public DateTime createdon { get; set; }  
    }
} 