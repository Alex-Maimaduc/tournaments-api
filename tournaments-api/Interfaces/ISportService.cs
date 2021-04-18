﻿using System.Collections.Generic;
using tournaments_api.Models;

namespace tournaments_api.Interfaces
{
    public interface ISportService
    {
        List<Sport> Get();
        Sport Get(int id);
        Sport Create(Sport sport);
        bool Update(Sport sport);
        void Delete(int id);
    }
}