using Contracts;
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
        private readonly string _userId;
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        public FreelancerService(string userId)
        {
            _userId = userId;
        }

        public bool CreateFreelancer(FreelancerCreate model)
        {
            var entity = new Freelancer()
            {
                FreelancerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FirstName + " " + model.LastName,
                StateId = model.StateId,
                CreatedDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };
            //var lang = _ctx.CodingLanguages.Where(c => c.CodingLanguageId == model.CodingLanguageId).Select(c => c).FirstOrDefault();
            //entity.CodingLanguages.Add(lang);
            _ctx.Freelancers.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public ICollection<FreelancerListItem> GetFreelancers()
        {
            var query = _ctx.Freelancers.Include(nameof(CodingLanguage)).Where(m => m.IsActive == true).Select(e => new FreelancerListItem
            {
                FreelancerId = e.FreelancerId,
                FullName = e.FullName,
                State = e.State.StateName,
                CodingLanguages = e.CodingLanguages.Select(c => c.CodingLanguageName).ToList(),
                JobPostsCompleted = e.JobsCompleted,
                
            });
            return query.ToList();
        }

        public FreelancerDetail GetFreelancerById(string id)
        {
            var entity = _ctx.Freelancers.Single(e => e.FreelancerId == id);
            return
            new FreelancerDetail
            {
                FullName = entity.FullName,
                Rating = entity.Rating,
                CodingLanguages = entity.CodingLanguages.Select(c => c.CodingLanguageName).ToList(),
                State = entity.State.StateName,
                CreatedDate = entity.CreatedDate,
                IsActive = entity.IsActive
            };
        }


        // TODO ability add or remove just coding languages
        public bool UpdateFreelancer(FreelancerUpdate freelancerToUpdate)
        {
            var entity = _ctx.Freelancers.Single(e => e.FreelancerId == _userId.ToString());
            entity.FirstName = freelancerToUpdate.FirstName;
            entity.LastName = freelancerToUpdate.LastName;
            entity.Rating = freelancerToUpdate.Rating;
            entity.StateId = _ctx.States.Select(s => s.StateId).Single();
            entity.ModifiedDate = DateTimeOffset.UtcNow;

            var lang = _ctx.CodingLanguages.Where(c => c.CodingLanguageId == freelancerToUpdate.CodingLanguageId).Select(c => c).FirstOrDefault();
            entity.CodingLanguages.Add(lang);

            return _ctx.SaveChanges() == 1;
        }

        public bool AddCodingLanguage(FreelancerAddCodingLanguage codingLanguageId)
        {
            var entity = _ctx.Freelancers.Single(e => e.FreelancerId == _userId.ToString());
            var lang = _ctx.CodingLanguages.Where(c => c.CodingLanguageId == codingLanguageId.CodingLanguageId).Select(c => c).FirstOrDefault();
            entity.CodingLanguages.Add(lang);

            return _ctx.SaveChanges() == 1;
        }

        public bool RemoveCodingLanguage(FreelancerRemoveCodingLanguage codingLanguageId)
        {
            var entity = _ctx.Freelancers.Single(e => e.FreelancerId == _userId.ToString());
            var lang = _ctx.CodingLanguages.Where(c => c.CodingLanguageId == codingLanguageId.CodingLanguageId).Select(c => c).FirstOrDefault();
            entity.CodingLanguages.Remove(lang);

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteFreelancer(string id)
        {
            var entity = _ctx.Freelancers.Single(e => e.FreelancerId == id);
            entity.IsActive = false;
            //_ctx.Freelancers.Remove(entity);
            return _ctx.SaveChanges() == 1;
        }
    }
}
