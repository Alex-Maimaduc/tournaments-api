﻿using System.Collections.Generic;
using tournaments_api.DBModels;
using tournaments_api.Enums;

namespace tournaments_api.Interfaces
{
    public interface ISportService
    {
        List<Sport> Get();
        Sport Get(int id);
        Sport Create(Sport sport);
        bool Update(Sport sport);
        void Delete(int id);
        List<TournamentPlayers> GetTournaments(int id,Status status,Period period);
        List<MatchPlayers> GetMatches(int id,Status status, Period period);
    }
}
