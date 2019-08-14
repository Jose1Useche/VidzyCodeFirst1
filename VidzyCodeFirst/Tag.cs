using System.Collections.Generic;

namespace VidzyCodeFirst
{
    public class Tag
    {
        public int TagId { get; set; }
        public IList<Video> Videos { get; set; }
    }
}
