using Contracts;
using Data;
using Models.Profile;
using Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();

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
                StateId = model.StateId,
                CreatedUTC = DateTimeOffset.UtcNow
            };
            var language = (CodingLanguage) ctx.CodingLanguages.Where(e => e.CodingLanguageId == model.CodingLanguage).Select(e => e);
            entity.CodingLanguages.Add(language);


                ctx.Freelancers.Add(entity);
                return ctx.SaveChanges() == 1;
        }

        public IEnumerable<FreelancerList> GetFreelancers()
        {
                var query = ctx
                    .Freelancers
                    .Select(e => new FreelancerList
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Rating = e.Rating,
                        StateId = e.StateId
                    });
                return query.ToArray();
        }

        public FreelancerDetail GetFreelancerById(string id)
        {
                var entity = ctx
                    .Freelancers
                    .Single(e => e.FreelancerId == id);
                var stateEntity = ctx.States.Single(e => e.StateId == entity.StateId);
                return
                    new FreelancerDetail
                    {
                        FreelancerId = entity.FreelancerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        CodingLanguage = entity.CodingLanguage.CodingLanguageName,
                        JobsCompleted = entity.JobsCompleted,
                        Rating = entity.Rating,
                        StateName = stateEntity.StateName,
                        CreatedUTC = DateTimeOffset.UtcNow

                    };
        }

        public bool UpdateFreelancer(FreelancerUpdate freelancerToUpdate)
        {
                var entity = ctx
                    .Freelancers
                    .Single(e => e.FreelancerId == freelancerToUpdate.FreelancerId);

                entity.FreelancerId = freelancerToUpdate.FreelancerId;
                entity.FirstName = freelancerToUpdate.FirstName;
                entity.LastName = freelancerToUpdate.LastName;
                entity.Rating = freelancerToUpdate.Rating;
                entity.CodingLanguage.CodingLanguageId = freelancerToUpdate.CodingLanguage;
                entity.JobsCompleted = freelancerToUpdate.JobsCompleted;
                entity.StateId = freelancerToUpdate.StateId;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
        }

        public bool DeleteFreelancer(string id)
        {
                var entity =
                    ctx
                        .Freelancers
                        .Single(e => e.FreelancerId == id);

                ctx.Freelancers.Remove(entity);

                return ctx.SaveChanges() == 1;
        }
    }
}
