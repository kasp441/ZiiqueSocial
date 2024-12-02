﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class ProfileRepo : IProfileRepo
    {
        RepoContext _context;
        public ProfileRepo(RepoContext context) 
        {
            _context = context;
        }
        public void AddProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
        }

        public List<Profile> GetAllProfiles()
        {
            return _context.Profiles.ToList();
        }

        public Profile GetProfile(Guid id)
        {
            return _context.Profiles.FirstOrDefault(p => p.Guid == id) ?? throw new Exception("Profile not found");
        }

        public void RemoveProfile(Guid id)
        {
            _context.Profiles.Remove(_context.Profiles.FirstOrDefault(p => p.Guid == id) ?? throw new Exception("Profile not found"));
        }

        public void UpdateProfile(Profile profile)
        {
            _context.Profiles.Update(profile);
            _context.SaveChanges();
        }
    }
}