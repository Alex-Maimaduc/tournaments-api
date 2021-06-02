using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tournaments_api.DBModels;
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
            _db.Teams.Include(t => t.Owner).Include(t => t.Players).ToList();

        public Team Get(int id) =>
            _db.Teams
                .Include(t => t.Owner)
                .Include(t => t.Players)
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
            if (!_db.Teams.Contains(team))
            {
                return false;
            }

            team.Sport = _db.Sports.Find(team.Sport.Id);

            if (team.Owner != null)
            {
                team.Owner = _db.Users.Find(team.Owner.Id);
            }

            if (team.Players != null)
            {
                List<User> usersToAdd = new();
                if (team.Players.Select(u => u.Id).Contains(team.Owner.Id))
                {
                    team.Players.Remove(team.Owner);
                    usersToAdd.Add(team.Owner);
                }
                usersToAdd.AddRange(_db.Users.Where(user => team.Players.Select(u => u.Id).Contains(user.Id)).ToList());

                team.Players = usersToAdd;
            }

            _db.Teams.Update(team);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            Team team = _db.Teams.Find(id);

            _db.Teams.Remove(team);
            _db.SaveChanges();
        }

        public List<MatchTeams> GetMatches(int id)
        {
            return _db.MatchTeams
                 .Where(match => match.FirstTeam.Id == id || match.SecondTeam.Id == id)
                 .Include(m => m.Sport)
                 .Include(m => m.FirstTeam)
                 .Include(m => m.SecondTeam)
                 .ToList();
        }

        public List<TournamentTeams> GetTournaments(int id)
        {
            return _db.TournamentTeams
                .Include(tornament=>tornament.Matches)
                .Where(tournament => tournament.Matches.Any(match => match.FirstTeam.Id == id || match.SecondTeam.Id == id))
                .ToList();
        }
    }
}
