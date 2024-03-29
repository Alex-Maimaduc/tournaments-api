﻿using System;
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

            if (gym.Members != null)
            {
                List<User> members = new();

                gym.Members.ForEach(member =>
                {
                    members.Add(_db.Users.Find(member.Id));
                });

                gym.Members = members;
            }


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

        public bool Delete(int id)
        {

            if (_db.MatchesPlayers.Any(match => match.Gym.Id == id) || _db.MatchTeams.Any(match => match.Gym.Id == id))
            {
                return false;
            }
            Gym gym = _db.Gyms.Include(gym => gym.Members).Include(gym => gym.Owner).FirstOrDefault(gym => gym.Id == id);

            gym.Owner = null;
            gym.IsDeleted = true;
            gym.Members.ForEach(user =>
            {
                user.Gym = null;
            });

            _db.SaveChanges();

            return true;
        }

        public List<MatchPlayers> GetMatches(int id, Status status, Period period, int sportId)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            Gym gym = _db.Gyms
                .Include(g=>g.MatchesPlayers)
                .Include("MatchesPlayers.FirstPlayer")
                .Include("MatchesPlayers.SecondPlayer")
                .Include("MatchesPlayers.Sport")
                .FirstOrDefault(g=>g.Id==id);

            return gym.MatchesPlayers
                .Where(match => (sportId == -1 || match.Sport.Id == sportId) &&
                    match.Status == status &&
                    (period == Period.All || dateTime.Key <= match.StartDate && match.StartDate <= dateTime.Value))
                .OrderBy(match => match.StartDate)
                .ThenBy(match => match.EndDate)
                .ToList();
        }

        public List<MatchTeams> GetMatchesTeams(int id, Status status, Period period, int sportId)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            Gym gym = _db.Gyms
                .Include(g => g.MatchesTeams)
                .Include("MatchesTeams.FirstTeam")
                .Include("MatchesTeams.SecondTeam")
                .Include("MatchesTeams.Sport")
                .FirstOrDefault(g => g.Id == id);

            return gym.MatchesTeams
                    .Where(match => (sportId == -1 || match.Sport.Id == sportId) &&
                        match.Status == status &&
                        (period == Period.All || dateTime.Key <= match.StartDate && match.StartDate <= dateTime.Value))
                    .OrderBy(match => match.StartDate)
                    .ThenBy(match=>match.EndDate)
                    .ToList();
        }

        public List<TournamentPlayers> GetTournaments(int id, Status status, Period period, int sportId)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            Gym gym = _db.Gyms
                .Include(g => g.TournamentsPlayers)
                .Include("TournamentsPlayers.Matches")
                .Include("TournamentsPlayers.Sport")
                .FirstOrDefault(g => g.Id == id);

            return gym.TournamentsPlayers
                    .Where(tournament =>
                         (sportId == -1 || tournament.Sport.Id == sportId) &&
                            tournament.Status == status &&
                            (period == Period.All ||
                                (dateTime.Key <= tournament.StartDate && tournament.StartDate <= dateTime.Value) ||
                                (dateTime.Key <= tournament.EndDate && tournament.EndDate <= dateTime.Value)))
                    .OrderBy(tournament => tournament.StartDate)
                    .ThenBy(tournament => tournament.EndDate)
                    .ToList();
        }

        public List<TournamentTeams> GetTournamentsTeams(int id, Status status, Period period, int sportId)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            Gym gym = _db.Gyms
                .Include(g => g.TournamentsTeams)
                .Include("TournamentsTeams.Matches")
                .Include("TournamentsTeams.Sport")
                .FirstOrDefault(g => g.Id == id);

            return gym.TournamentsTeams
                    .Where(tournament =>
                        ( sportId == -1 || tournament.Sport.Id == sportId) &&
                            tournament.Status == status &&
                            (period == Period.All ||
                                (dateTime.Key <= tournament.StartDate && tournament.StartDate <= dateTime.Value) ||
                                (dateTime.Key <= tournament.EndDate && tournament.EndDate <= dateTime.Value)))
                    .OrderBy(tournament => tournament.StartDate)
                    .ThenBy(tournament => tournament.EndDate)
                    .ToList();
        }
    }
}
