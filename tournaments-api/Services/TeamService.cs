using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tournaments_api.DBModels;
using tournaments_api.Enums;
using tournaments_api.Interfaces;
using tournaments_api.Models;
using tournaments_api.Repository;

namespace tournaments_api.Services
{
    public class TeamService : ITeamService
    {
        private readonly DatabaseContext _db;

        public TeamService(DatabaseContext db)
        {
            _db = db;
        }

        public List<Team> Get() =>
            _db.Teams.Include(t => t.Owner).Include(t => t.Players).Where(team => team.IsDeleted == false).ToList();

        public Team Get(int id) =>
            _db.Teams
                .Include(t => t.Owner)
                .Include(t => t.Players)
                .Include(t => t.Sport)
                .FirstOrDefault(t => t.Id == id);

        public Team Create(Team team)
        {
            if (team.Owner != null)
            {
                team.Owner = _db.Users.Find(team.Owner.Id);
            }

            team.Sport = _db.Sports.Find(team.Sport.Id);

            if (team.Players != null)
            {
                List<User> players = new();

                team.Players.ForEach(player =>
                {
                    players.Add(_db.Users.Find(player.Id));
                });


                team.Players = players;
            }

            _db.Teams.Add(team);
            _db.SaveChanges();

            return team;
        }

        public bool Update(Team team)
        {
            Team teamToUpdate = _db.Teams.Include(team => team.Players).Include(team => team.Sport).FirstOrDefault(t => t.Id == team.Id);

            teamToUpdate.Players.ForEach(user =>
            {
                if (!team.Players.Exists(u => u.Id == user.Id))
                {
                    user.Team = null;
                }
            });

            teamToUpdate.Name = team.Name;
            teamToUpdate.Description = team.Description;
            teamToUpdate.Sport = _db.Sports.Find(team.Sport.Id);
            teamToUpdate.ImagePath = team.ImagePath;

            List<User> players = new();

            team.Players.ForEach(member =>
            {
                players.Add(_db.Users.Find(member.Id));
            });

            teamToUpdate.Players = players;

            _db.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            if (_db.MatchTeams.Any(match => match.FirstTeam.Id == id || match.SecondTeam.Id == id))
            {
                return false;
            }

            Team team = _db.Teams.Include(team => team.Players).FirstOrDefault(team => team.Id == id);

            team.Owner = null;
            team.IsDeleted = true;
            team.Players.ForEach(user =>
            {
                user.Team = null;
            });

            _db.SaveChanges();

            return true;
        }

        public List<MatchTeams> GetMatches(int id, Status status, Period period)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            return _db.MatchTeams
             .Where(match => (match.FirstTeam.Id == id || match.SecondTeam.Id == id) &&
                match.Status == status &&
                (period == Period.All || (dateTime.Key <= match.StartDate && match.StartDate <= dateTime.Value)))
             .Include(m => m.Sport)
             .Include(m => m.FirstTeam)
             .Include(m => m.SecondTeam)
             .Include(match => match.Gym)
             .OrderBy(match => match.StartDate)
             .ThenBy(match => match.EndDate)
             .ToList();

        }

        public List<TournamentTeams> GetTournaments(int id, Status status, Period period)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }


            return _db.TournamentTeams
                .Include(tournament => tournament.Matches)
                .Include(tournament => tournament.Gym)
                .Include(tournament => tournament.Sport)
                .Where(tournament =>
                    tournament.Matches.Any(match => match.FirstTeam.Id == id || match.SecondTeam.Id == id) &&
                    tournament.Status == status &&
                    (period == Period.All || (dateTime.Key <= tournament.StartDate && tournament.StartDate <= dateTime.Value)))
                .OrderBy(tournament => tournament.StartDate)
                .ThenBy(tournament => tournament.EndDate)
                .ToList();
        }

        public List<Team> GetTeamsForMatch(int sportId, DateTime startDate, DateTime endDate)
        {
            List<Team> teams = _db.Teams.Where(team => team.Sport.Id == sportId && team.IsDeleted == false).ToList();

            teams.RemoveAll(team => _db.MatchTeams.Any(match => (match.FirstTeam.Id == team.Id || match.SecondTeam.Id == team.Id) &&
                 ((match.StartDate <= startDate && startDate <= match.EndDate) || (match.StartDate <= endDate && endDate <= match.EndDate))));

            return teams;
        }

        public Stats GetStats(int id, Period period)
        {
            Stats stats = new();
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, Status.Finished);
            }

            List<MatchTeams> matches = _db.MatchTeams
                      .Include(match=>match.FirstTeam)
                      .Where(match => (match.FirstTeam.Id == id || match.SecondTeam.Id == id) &&
                        match.Status == Status.Finished &&
                        (period == Period.All || (dateTime.Key <= match.StartDate && match.StartDate <= dateTime.Value)))
                      .ToList();

            List<TournamentTeams> tournaments = _db.TournamentTeams
                          .Where(tournament => tournament.Matches.Any(match => match.FirstTeam.Id == id || match.SecondTeam.Id == id) &&
                              tournament.Status == Status.Finished &&
                              (period == Period.All || (dateTime.Key <= tournament.StartDate && tournament.StartDate <= dateTime.Value)))
                          .ToList();

            foreach (MatchTeams match in matches)
            {
                if (match.WinnerId != -1)
                {
                    if (match.WinnerId == id)
                    {
                        stats.WonMatches++;
                    }
                    else
                    {
                        stats.LostMatches++;
                    }
                }

                stats.Score += match.FirstTeam.Id == id ? match.FirstScore : match.SecondScore;
            }

            stats.TotalMatches = matches.Count;
            stats.WonTournaments = tournaments.Where(tournament => tournament.WinnerId == id).Count();
            stats.LostTournaments = tournaments.Count - stats.WonTournaments;
            return stats;
        }
    }
}
