using System.Collections.Generic;
using System.Linq;
using tournaments_api.Interfaces;
using tournaments_api.Models;
using tournaments_api.Repository;

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
            if (_db.Sports.Find(sport.Id)==null)
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
    }
}
