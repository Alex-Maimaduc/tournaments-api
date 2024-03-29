﻿using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.DBModels;
using tournaments_api.Repository;
using Microsoft.EntityFrameworkCore;
using tournaments_api.Enums;
using System;

namespace tournaments_api.Services
{
    public class SportService : ISportService
    {
        private readonly DatabaseContext _db;

        public SportService(DatabaseContext db)
        {
            _db = db;
        }

        public List<Sport> Get() =>
            _db.Sports.ToList();

        public Sport Get(int id) =>
            _db.Sports.Find(id);

        public Sport Create(Sport sport)
        {
            _db.Sports.Add(sport);
            _db.SaveChanges();

            return sport;
        }

        public bool Update(Sport sport)
        {
            if (_db.Sports.Find(sport.Id) == null)
            {
                return false;
            }
            _db.Sports.Update(sport);
            _db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            Sport sport = _db.Sports.Find(id);

            _db.Sports.Remove(sport);
            _db.SaveChanges();
        }

        public List<MatchPlayers> GetMatches(int id, Status status, Period period)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            return _db.MatchesPlayers
                    .Where(match => match.Sport.Id == id && match.Status == status && (period == Period.All || dateTime.Key <= match.StartDate && match.StartDate <= dateTime.Value))
                    .Include(m => m.Gym)
                    .Include(m => m.Sport)
                    .Include(m => m.FirstPlayer)
                    .Include(m => m.SecondPlayer)
                    .OrderBy(match => match.StartDate)
                    .OrderBy(match => match.EndDate)
                    .ToList();
        }

        public List<MatchTeams> GetMatchesTeams(int id, Status status, Period period)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            return _db.MatchTeams
                    .Where(match => match.Sport.Id == id && match.Status == status && (period == Period.All || dateTime.Key <= match.StartDate && match.StartDate <= dateTime.Value))
                    .Include(m => m.Gym)
                    .Include(m => m.Sport)
                    .Include(m => m.FirstTeam)
                    .Include(m => m.SecondTeam)
                    .OrderBy(match => match.StartDate)
                    .OrderBy(match => match.EndDate)
                    .ToList();
        }

        public List<TournamentPlayers> GetTournaments(int id, Status status, Period period)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            return _db.TournamentPlayers
                .Include(tournament => tournament.Matches)
                .Include("Matches.Sport")
                .Where(tournament => tournament.Matches.Any(match => match.Sport.Id == id) && tournament.Status == status && (period == Period.All || dateTime.Key <= tournament.StartDate && tournament.StartDate <= dateTime.Value))
                .OrderBy(tournament => tournament.StartDate)
                .OrderBy(tournament => tournament.EndDate)
                .ToList();
        }

        public List<TournamentTeams> GetTournamentsTeams(int id, Status status, Period period)
        {
            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (period != Period.All)
            {
                dateTime = Utils.GetDateTime(period, status);
            }

            return _db.TournamentTeams
                .Include(tournament => tournament.Matches)
                .Include("Matches.Sport")
                .Where(tournament => tournament.Matches.Any(match => match.Sport.Id == id) && tournament.Status == status && (period == Period.All || dateTime.Key <= tournament.StartDate && tournament.StartDate <= dateTime.Value))
                .OrderBy(tournament => tournament.StartDate)
                .OrderBy(tournament => tournament.EndDate)
                .ToList();
        }
    }
}
