using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoLibrary.Models
{
    public class XCSerieStreamModel
    {
        public int num { get; set; }
        public string name { get; set; }
        public int series_id { get; set; }
        public string cover { get; set; }
        public string plot { get; set; }
        public string cast { get; set; }
        public string director { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public string last_modified { get; set; }
        public float rating { get; set; }
        public float ratingFiveBased { get; set; }
        public List<string> backdrop_path { get; set; }
        public string youtube_trailer { get; set; }
        public string episode_run_time { get; set; }
        public string category_id { get; set; }
    }
}
