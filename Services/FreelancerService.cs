﻿using Contracts;
using Data;
using Models.Freelancer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;


namespace Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        public FreelancerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFreelancer(FreelancerCreate model)
        {
            var entity = new Freelancer()
            {
                FreelancerId = _userId.ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedDate = DateTimeOffset.UtcNow
            };
            var lang = _ctx.CodingLanguages.Where(c => c.CodingLanguageId == model.CodingLanguageId).Select(c => c).FirstOrDefault();
            entity.CodingLanguages.Add(lang);
            entity.State.StateId = _ctx.States.Where(s => s.StateName == model.State).Select(s => s.StateId).FirstOrDefault();
            _ctx.Freelancers.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public ICollection<FreelancerListItem> GetFreelancers()
        {
            var query = _ctx.Freelancers.Include(nameof(CodingLanguage)).Select(e => new FreelancerListItem
            {
                FreelancerId = e.FreelancerId,
                LastName = e.LastName,
                State = e.State.StateName,
                CodingLanguages = e.CodingLanguages.Select(c => c.CodingLanguageName).ToList(),
                JobPostsCompleted = e.JobsCompleted,
                
            });
            return query.ToList();
        }

        public FreelancerDetail GetFreelancerById(string id)
        {
            var entity = _ctx.Freelancers.Include(nameof(CodingLanguage)).Single(e => e.FreelancerId == id);
            return
            new FreelancerDetail
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Rating = entity.Rating,
                CodingLanguages = entity.CodingLanguages.Select(c => c.CodingLanguageName).ToList(),
                State = entity.State.StateName,
                CreatedDate = entity.CreatedDate
            };
        }

        public bool UpdateFreelancer(FreelancerUpdate freelancerToUpdate)
        {
            var entity = _ctx.Freelancers.Single(e => e.FreelancerId == _userId.ToString());
            entity.FirstName = freelancerToUpdate.FirstName;
            entity.LastName = freelancerToUpdate.LastName;
            entity.Rating = freelancerToUpdate.Rating;
            entity.StateId = _ctx.States.Where(s => s.StateName == freelancerToUpdate.State).Select(s => s.StateId).Single();
            entity.ModifiedDate = DateTimeOffset.UtcNow;

            var lang = _ctx.CodingLanguages.Where(c => c.CodingLanguageId == freelancerToUpdate.CodingLanguageId).Select(c => c).FirstOrDefault();
            entity.CodingLanguages.Add(lang);
            //entity.CodingLanguages = freelancerToUpdate.CodingLanguage;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteFreelancer(string id)
        {
            var entity = _ctx.Freelancers.Single(e => e.FreelancerId == id);
            _ctx.Freelancers.Remove(entity);
            return _ctx.SaveChanges() == 1;
        }
    }
}
