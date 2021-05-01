using System;
using System.Collections.Generic;

namespace tournaments_api.GraphQL.Users
{
    public record AddUserInput(string Id, string Mail, string FirstName, string LastName, string Gender, DateTime DateOfBirth,List<int> FavoriteSportIds);
}
