﻿using System;
using System.Collections.Generic;
using tournaments_api.DBModels;
using tournaments_api.Enums;
using tournaments_api.Models;

namespace tournaments_api.Interfaces
{
    public interface IUserService
    {
        List<User> Get();

        User Get(string id);

        User Create(User user);

        bool Update(User user);

        void Delete(string id);

        bool AddSports(string id, List<int> sports);

        Team GetTeam(string id);

        List<Sport> GetFavoriteSports(string id);

        bool RemoveFavoriteSport(string id,int sportId);

        List<MatchPlayers> GetMatches(string id,Status status, Period period);

        List<TournamentPlayers> GetTournaments(string id,Status status, Period period);

        int GetGym(string id);

        List<MatchPlayers> GetMatchesHistory(string id, int sportId, DateTime startDate, DateTime endDate);

        Stats GetStats(string id, int sportId, DateTime startDate, DateTime endDate);

    }
}
