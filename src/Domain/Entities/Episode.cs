
namespace Domain.Entities
{
    public class Episode
    {
        public int id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public List<Character> characters { get; set; }//url
        public string url { get; set; }//url
        public DateTime created { get; set; }
    }

}