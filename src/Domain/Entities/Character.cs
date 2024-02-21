using Domain.Entities;
namespace Domain.Entities
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public Origin origin { get; set; }
        public Location location { get; set; }
        public string image { get; set; }//url
        public List<Episode> episode { get; set; }//url
        public string url { get; set; }//url
        public DateTime created { get; set; }

    }

}
