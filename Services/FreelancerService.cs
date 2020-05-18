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
    public class FreelancerService
    {
        private readonly Guid _userId;

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
                CodingLanguage = model.CodingLanguage,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Freelancers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FreelancerList> GetFreelancers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Freelancers
                    .Select(e => new FreelancerList
                    {
                        FreelancerId = e.FreelancerId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Rating = e.Rating
                    });
                return query.ToArray();
            }
        }

        public FreelancerDetail GetFreelancerById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Freelancers
                    .Single(e => e.FreelancerId == id);
                return
                    new FreelancerDetail
                    {
                        FreelancerId = entity.FreelancerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Rating = entity.Rating,
                        CodingLanguage = entity.CodingLanguage,
                        JobsCompleted = entity.JobsCompleted,
                    };
            }
        }

        public bool UpdateFreelancer(FreelancerUpdate freelancerToUpdate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Freelancers
                    .Single(e => e.FreelancerId == freelancerToUpdate.FreelancerId && e.FreelancerId == _userId.ToString());

                entity.FreelancerId = freelancerToUpdate.FreelancerId;
                entity.FirstName = freelancerToUpdate.FirstName;
                entity.LastName = freelancerToUpdate.LastName;
                entity.Rating = freelancerToUpdate.Rating;
                entity.CodingLanguage = freelancerToUpdate.CodingLanguage;
                entity.JobsCompleted = freelancerToUpdate.JobsCompleted;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFreelancer(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Freelancers
                        .Single(e => e.FreelancerId == id && e.FreelancerId == _userId.ToString());

                ctx.Freelancers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
