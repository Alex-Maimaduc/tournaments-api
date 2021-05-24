using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using tournaments_api.GraphQL.Sports;
using tournaments_api.GraphQL.Users;
using tournaments_api.DBModels;
using tournaments_api.Repository;
using tournaments_api.GraphQL.DBModels;

namespace tournaments_api.GraphQL
{
    public class Mutation
    {

        #region User

        [UseDbContext(typeof(DatabaseContext))]
        public async Task<AddUserPayload> AddUserAsync(AddUserInput input, [ScopedService] DatabaseContext context)
        {
            var user = new User
            {
                Id = input.Id,
                Mail = input.Mail,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Gender = input.Gender,
                DateOfBirth = input.DateOfBirth
            };

            if (input.FavoriteSportIds != null)
            {
                List<Sport> sportsToAdd = context.Sports.Where(sport => input.FavoriteSportIds.Contains(sport.Id)).ToList();

                user.FavoriteSports.AddRange(sportsToAdd);
            }

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return new AddUserPayload(user);
        }

        [UseDbContext(typeof(DatabaseContext))]
        public async Task<User> UpdateUserAsync(AddUserInput input, [ScopedService] DatabaseContext context)
        {
            var user = new User
            {
                Id = input.Id,
                Mail = input.Mail,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Gender = input.Gender,
                DateOfBirth = input.DateOfBirth
            };


            if (!context.Users.Contains(user))
            {
                return null;
            }

            if (input.FavoriteSportIds.Count > 0)
            {
                List<Sport> sportsToAdd = context.Sports.Where(sport => input.FavoriteSportIds.Contains(sport.Id)).ToList();

                user.FavoriteSports.AddRange(sportsToAdd);
            }

            context.Users.Update(user);
            await context.SaveChangesAsync();

            return user;
        }


        [UseDbContext(typeof(DatabaseContext))]
        public async Task<string> DeleteUser(string input, [ScopedService] DatabaseContext context)
        {
            var user = context.Users.Find(input);

            if (user == null)
            {
                return null;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return "Deleted";
        }

        #endregion

        #region Sport

        [UseDbContext(typeof(DatabaseContext))]
        public async Task<SportPayload> AddSportAsync(AddSportInput input, [ScopedService] DatabaseContext context)
        {
            var sport = new Sport
            {
                Name = input.Name,
                Description = input.Description,
                ImagePath = input.ImagePath
            };

            context.Sports.Add(sport);
            await context.SaveChangesAsync();

            return new SportPayload(sport);
        }

        #endregion

    }
}
