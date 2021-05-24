using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using tournaments_api.DBModels;
using tournaments_api.Repository;

namespace tournaments_api.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(DatabaseContext))]
        [UseProjection]
        [UseSorting]
        [UseFiltering]
        public IQueryable<User> GetUser([Service] DatabaseContext context)
        {
            return context.Users;
        }

        [UseDbContext(typeof(DatabaseContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Sport> GetSport([Service] DatabaseContext context)
        {
            return context.Sports;
        }
    }
}
