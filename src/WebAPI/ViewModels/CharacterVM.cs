using Domain.Entities;

namespace WebAPI.ViewModels
{
    public class CharacterVM
    {
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public string image { get; set; }//url
        public string url { get; set; }//url
        public DateTime created { get; set; }

        public int originID { get; set; }
        public int locationID { get; set; }
        public int[] episodeArray { get; set; }
    }
}
