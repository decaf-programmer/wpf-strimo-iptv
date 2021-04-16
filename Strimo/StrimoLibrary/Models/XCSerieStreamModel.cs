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
        public int seriesId { get; set; }
        public string cover { get; set; }
        public string plot { get; set; }
        public string cast { get; set; }
        public string director { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public string lastModified { get; set; }
        public double rating { get; set; }
        public double ratingFiveBased { get; set; }
        public List<string> backDropPath { get; set; }
        public string youtubeTrailer { get; set; }
        public string episodeRunTime { get; set; }
        public string categoryId { get; set; }
    }
}
