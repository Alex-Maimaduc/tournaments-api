using System;
using System.Collections.Generic;
using tournaments_api.Interfaces;
using tournaments_api.Models;
using tournaments_api.Repository;

namespace tournaments_api.Services
{
    public class MatchService : IMatchService
    {
        private readonly DatabaseContext _db;

        public MatchService(DatabaseContext db)
        {
            _db = db;
        }

        public Match Create(Match match)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Match> Get()
        {
            throw new NotImplementedException();
        }

        public Match Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Match match)
        {
            throw new NotImplementedException();
        }
    }
}
