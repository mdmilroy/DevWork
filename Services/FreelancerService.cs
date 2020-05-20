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
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Rating = e.Rating
                    });
                return query.ToArray();
            }
        }

        public FreelancerDetail GetFreelancerById(int id)
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

        public bool UpdateFreelancer(int id, FreelancerUpdate freelancerToUpdate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Freelancers
                    .Single(e => e.FreelancerId == freelancerToUpdate.FreelancerId);

                entity.FreelancerId = freelancerToUpdate.FreelancerId;
                entity.FirstName = freelancerToUpdate.FirstName;
                entity.LastName = freelancerToUpdate.LastName;
                entity.Rating = freelancerToUpdate.Rating;
                entity.CodingLanguage = freelancerToUpdate.CodingLanguage;
                entity.JobsCompleted = freelancerToUpdate.JobsCompleted;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFreelancer(int id)
        {
            using (var ctx = new ApplicationDbContext())
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
}
