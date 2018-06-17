using System;

namespace GroupByTest.Models
{
    public class FollowShow
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public DateTime Followed { get; set; }
    }
}