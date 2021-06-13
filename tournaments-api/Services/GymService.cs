using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tournaments_api.DBModels;
using tournaments_api.Enums;
using tournaments_api.Interfaces;
using tournaments_api.Repository;

namespace tournaments_api.Services
{
    public class GymService : IGymService
    {
        private readonly DatabaseContext _db;

        public GymService(DatabaseContext db)
        {
            _db = db;
        }

        public IEnumerable<Gym> Get() =>
            _db.Gyms;

        public Gym Get(int id) =>
            _db.Gyms
            .Include(gym => gym.Owner)
            .Include(gym => gym.Members)
            .FirstOrDefault(gym => gym.Id == id);

        public Gym Create(Gym gym)
        {
            User owner = _db.Users.Find(gym.Owner.Id);

            gym.Owner = owner;

            List<User> members = new();

            gym.Members.ForEach(member =>
            {
                members.Add(member);
            });

            gym.Members = members;

            _db.Gyms.Add(gym);
            _db.SaveChanges();

            return gym;
        }

        public bool Update(Gym gym)
        {
            Gym gymToUpdate = _db.Gyms.Include(gym => gym.Members).FirstOrDefault(g => g.Id == gym.Id);

            gymToUpdate.Members.ForEach(user =>
            {
                if (!gym.Members.Exists(u => u.Id == user.Id))
                {
                    user.Gym = null;
                }
            });

            gymToUpdate.Name = gym.Name;
            gymToUpdate.Description = gym.Description;
            gymToUpdate.Street = gym.Street;
            gymToUpdate.City = gym.City;
            gymToUpdate.Number = gym.Number;
            gymToUpdate.ImagePath = gym.ImagePath;

            List<User> members = new();

            gym.Members.ForEach(member =>
            {
                members.Add(_db.Users.Find(member.Id));
            });

            gymToUpdate.Members = members;

            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            Gym gym = _db.Gyms.Find(id);

            _db.Gyms.Remove(gym);
            _db.SaveChanges();
        }

        public List<MatchPlayers> GetMatches(int id, Status status, Period period)
        {
            if (period != Period.All)
            {
                KeyValuePair<DateTime, DateTime> dateTime = Utils.GetDateTime(period, status);

                return _db.MatchesPlayers
                    .Include(match => match.FirstPlayer)
                    .Include(match => match.SecondPlayer)
                    .Include(match => match.Sport)
                    .Include(match => match.Gym)
                    .Where(match => match.Gym.Id == id && match.Status == status && dateTime.Key <= match.StartDate && match.StartDate <= dateTime.Value)
                    .OrderBy(match => match.StartDate)
                    .OrderBy(match => match.EndDate)
                    .ToList();

            }
            else
            {
                return _db.MatchesPlayers
                    .Include(match => match.FirstPlayer)
                    .Include(match => match.SecondPlayer)
                    .Include(match => match.Sport)
                    .Include(match => match.Gym)
                    .Where(match => match.Gym.Id == id && match.Status == status)
                    .OrderBy(match => match.StartDate)
                    .OrderBy(match => match.EndDate)
                    .ToList();
            }
        }

        public List<TournamentPlayers> GetTournaments(int id, Status status, Period period)
        {
            if (period != Period.All)
            {
                KeyValuePair<DateTime, DateTime> dateTime = Utils.GetDateTime(period, status);

                return _db.TournamentPlayers
                    .Include(tournament => tournament.Matches)
                    .Include("Matches.Sport")
                    .Where(tournament => tournament.Matches.Any(match => match.Gym.Id == id) && tournament.Status == status && dateTime.Key <= tournament.StartDate && tournament.StartDate <= dateTime.Value)
                    .OrderBy(tournament => tournament.StartDate)
                    .OrderBy(tournament => tournament.EndDate)
                    .ToList();
            }
            else
            {
                var tournaments = _db.TournamentPlayers
                    .Include(tournament => tournament.Matches)
                    .Include("Matches.Sport")
                    .Where(tournament => tournament.Matches.Any(match => match.Gym.Id == id) && tournament.Status == status)
                    .OrderBy(tournament => tournament.StartDate)
                    .OrderBy(tournament => tournament.EndDate)
                    .ToList();

                return tournaments;
            }
        }
    }
}
