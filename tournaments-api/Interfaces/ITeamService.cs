﻿using System.Collections.Generic;
using tournaments_api.DBModels;
using tournaments_api.Enums;
using tournaments_api.Models;

namespace tournaments_api.Interfaces
{
    public interface ITeamService
    {
        List<Team> Get();
        Team Get(int id);
        Team Create(Team team);
        bool Update(Team team);
        void Delete(int id);
        List<MatchTeams> GetMatches(int id, Status status, Period period);
        List<TournamentTeams> GetTournaments(int id, Status status, Period period
            );
    }
}