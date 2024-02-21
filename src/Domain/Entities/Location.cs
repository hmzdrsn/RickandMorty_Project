
namespace Domain.Entities
{
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string dimension { get; set; }
        public string url { get; set; }//url
        public DateTime created { get; set; }

    }
}