using System.Collections.Generic;

namespace GroupByTest.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FollowShow> Followers { get; set; }
    }
}