﻿using System.Collections.Generic;
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
    }
}
