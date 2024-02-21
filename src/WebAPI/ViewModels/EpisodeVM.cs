using Domain.Entities;

namespace WebAPI.ViewModels
{
    public class EpisodeVM
    {
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public string url { get; set; }//url
        public int[]? characterList {  get; set; }
    }
}
