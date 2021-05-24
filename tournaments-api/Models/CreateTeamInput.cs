using System;
using System.Collections.Generic;
using tournaments_api.DBModels;

namespace tournaments_api.Models
{
    public class CreateTeamInput
    {
        public Team Team;
        public List<string> UserIds;
    }
}
