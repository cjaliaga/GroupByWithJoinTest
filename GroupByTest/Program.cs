using System;
using System.Linq;

namespace GroupByTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShowsDbContext())
            {
                var mostFollowed = (from f in context.FollowShows
                        group f by f.ShowId
                        into g
                        join show in context.Shows on g.Key equals show.Id
                        select new
                        {
                            Id = g.Key,
                            Followers = g.Count(),
                            Name = show.Name,
                        })
                    .OrderByDescending(s => s.Followers)
                    .FirstOrDefault();

                var mostFollowed2 = context.FollowShows
                    .GroupBy(f => f.ShowId, (key, grp) => new {Id = key, Followers = grp.Count()})
                    .Join(context.Shows, f => f.Id, s => s.Id,
                        (f, s) => new
                        {
                            Id = f.Id,
                            Followers = f.Followers,
                            Name = s.Name
                        }).OrderByDescending(s => s.Followers)
                    .FirstOrDefault();

            }
        }
    }
}
