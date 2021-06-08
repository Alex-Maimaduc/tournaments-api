using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Repository;
using System;
using tournaments_api.Enums;
using tournaments_api.Models;

namespace tournaments_api.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _db;

        public UserService(DatabaseContext db)
        {
            _db = db;
        }

        public List<User> Get() =>
            _db.Users
            .Include(u => u.FavoriteSports)
            .ToList();

        public User Get(string id) =>
            _db.Users.Include(user => user.Gym).FirstOrDefault(u => u.Id == id);

        public User Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
        }

        public bool Update(User user)
        {
            if (!_db.Users.Contains(user))
            {
                return false;
            }

            _db.Users.Update(user);
            _db.SaveChanges();

            return true;
        }

        public void Delete(string id)
        {
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public bool AddSports(string id, List<int> sports)
        {
            User user = _db.Users.Find(id);

            if (user == null)
            {
                return false;
            }

            List<Sport> sportsToAdd = _db.Sports
                .Where(sport => sports.Contains(sport.Id))
                .ToList();

            user.FavoriteSports.AddRange(sportsToAdd);

            _db.SaveChanges();

            return true;
        }

        public List<Sport> GetFavoriteSports(string id)
        {
            User user = _db.Users
                .Include(u => u.FavoriteSports)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return user.FavoriteSports;
        }

        public bool RemoveFavoriteSport(string id, int sportId)
        {
            User user = _db.Users
                .Include(u => u.FavoriteSports)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return false;
            }

            user.FavoriteSports
                .Remove(user.FavoriteSports
                .FirstOrDefault(s => s.Id == sportId));

            _db.SaveChanges();

            return true;
        }

        public int GetTeam(string id)
        {
            Team team = _db.Teams.FirstOrDefault(team => team.Owner.Id == id || team.Players.Any(player => player.Id == id));

            if (team != null)
            {
                return team.Id;
            }

            return -1;
        }

        public List<MatchPlayers> GetMatches(string id,Status status, Period period)
        {
            if (period != Period.All)
            {
                KeyValuePair<DateTime, DateTime> dateTime = Utils.GetDateTime(period,status);


                return _db.MatchesPlayers
                    .Where(match => (match.FirstPlayer.Id == id || match.SecondPlayer.Id == id) && match.Status == status && dateTime.Key <= match.StartDate && match.StartDate <= dateTime.Value)
                    .Include(m => m.Gym)
                    .Include(m => m.Sport)
                    .Include(m => m.FirstPlayer)
                    .Include(m => m.SecondPlayer)
                    .ToList();
            }
            else
            {
                return _db.MatchesPlayers
                    .Where(match => (match.FirstPlayer.Id == id || match.SecondPlayer.Id == id) && match.Status == status)
                    .Include(m => m.Gym)
                    .Include(m => m.Sport)
                    .Include(m => m.FirstPlayer)
                    .Include(m => m.SecondPlayer)
                    .ToList();
            }

        }

        public List<TournamentPlayers> GetTournaments(string id,Status status, Period period)
        {
            if (period != Period.All)
            {
                KeyValuePair<DateTime, DateTime> dateTime = Utils.GetDateTime(period,status) ;

                return _db.TournamentPlayers
                .Include(tournament => tournament.Matches)
                .Include("Matches.Sport")
                .Where(tournament => tournament.Matches.Any(match => match.FirstPlayer.Id == id || match.SecondPlayer.Id == id) && tournament.Status==status && dateTime.Key <= tournament.EndDate && tournament.EndDate <= dateTime.Value)
                .ToList();
            }
            else
            {
                return _db.TournamentPlayers
                .Include(tournament => tournament.Matches)
                .Include("Matches.Sport")
                .Where(tournament => tournament.Matches.Any(match => match.FirstPlayer.Id == id || match.SecondPlayer.Id == id) && tournament.Status == status)
                .ToList();
            }
        }
        
        public int GetGym(string id)
        {
            Gym gym = _db.Gyms.FirstOrDefault(gym => gym.Owner.Id == id || gym.Members.Any(member => member.Id == id));

            if (gym != null)
            {
                return gym.Id;
            }

            return -1;
        }

        public List<MatchPlayers> GetMatchesHistory(string id, int sportId, DateTime startDate, DateTime endDate)
        {
            return _db.MatchesPlayers
                .Where(match => (match.FirstPlayer.Id == id || match.SecondPlayer.Id == id) && match.Status == Status.Finished && match.StartDate >= startDate && match.StartDate <= endDate && match.Sport.Id == sportId)
                .Include(m => m.Gym)
                .Include(m => m.Sport)
                .Include(m => m.FirstPlayer)
                .Include(m => m.SecondPlayer)
                .ToList();
        }

        public Stats GetStats(string id, int sportId, DateTime startDate, DateTime endDate)
        {
            Stats stats = new();

            List<MatchPlayers> matches = _db.MatchesPlayers
                .Include(match => match.FirstPlayer)
                .Where(match => (match.FirstPlayer.Id == id || match.SecondPlayer.Id == id) && match.Status == Status.Finished && match.StartDate >= startDate && match.StartDate <= endDate && match.Sport.Id == sportId)
                .ToList();

            List<TournamentPlayers> tournaments = _db.TournamentPlayers
                .Include(tournament => tournament.Matches)
                .Where(tournament => tournament.Matches.Any(match => match.FirstPlayer.Id == id || match.SecondPlayer.Id == id) && tournament.Status == Status.Finished && tournament.EndDate >= startDate && tournament.EndDate <= endDate && tournament.Matches.Any(match => match.Sport.Id == sportId))
                .ToList();

            foreach (MatchPlayers match in matches)
            {
                if (match.FirstPlayer.Id == id)
                {
                    if (match.WinnerId == id)
                    {
                        stats.WonMatchs += 1;
                    }
                    stats.Score += match.FirstScore;
                }
                else
                {
                    if (match.WinnerId == id)
                    {
                        stats.WonMatchs += 1;
                    }
                    stats.Score += match.SecondScore;
                }
            }

            stats.LostMatches = matches.Count - stats.WonMatchs;
            stats.WonTournaments = tournaments.Where(tournament => tournament.WinnerId == id).Count();
            stats.LostTournaments = tournaments.Count - stats.WonTournaments;
            return stats;
        }

        public List<User> GetUsersForMatch(DateTime startDate, DateTime endDate)
        {
            List<User> users = _db.Users.ToList();

            users.RemoveAll(user => _db.MatchesPlayers.Any(match => (match.FirstPlayer.Id == user.Id || match.SecondPlayer.Id == user.Id) &&
                 ((match.StartDate <= startDate && startDate <= match.EndDate) || (match.StartDate <= endDate && endDate <= match.EndDate))));

            return users;
        }
    }
}
