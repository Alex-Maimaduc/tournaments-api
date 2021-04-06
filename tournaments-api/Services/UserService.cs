﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using tournaments.Repository;
using tournements.Data;

namespace tournaments.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _db;

        public UserService(UserDbContext db)
        {
            _db = db;
        }

        public List<User> Get() =>
            _db.Users.ToList();

        public User Get(string id) =>
            _db.Users.Find(id);

        public User Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
        }

        public bool Update(User user)
        {
            if (!_db.Users.Contains(user))
            {
                return false;
            }

            _db.Users.Update(user);
            _db.SaveChanges();

            return true;
        }

        public void Delete(string id)
        {
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
