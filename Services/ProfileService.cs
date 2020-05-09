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
    public class ProfileService
    {
        private readonly Guid _userId;

        public ProfileService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<EmployersList> GetEmployers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employers
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new EmployersList
                                {
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Organization = e.Organization,
                                    Rating = e.Rating,
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<FreelancersList> GetFreelancers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Freelancers
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new FreelancersList
                                {
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    CodingLanguage = e.CodingLanguage.LanguageName,
                                    Rating = e.Rating,
                                }
                        );

                return query.ToArray();
            }
        }

        public EmployerDetail GetEmployerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employers
                        .Single(e => e.UserId == _userId);
                return
                    new EmployerDetail
                    {
                        EmployerId = entity.UserId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        Organization = entity.Organization,
                        State = entity.State.StateName,
                        Rating = entity.Rating
                    };
            }
        }

        public FreelancerDetail GetFreelancerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Freelancers
                        .Single(e => e.UserId == _userId);
                return
                    new FreelancerDetail
                    {
                        FreelancerId = entity.UserId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Email = entity.Email,
                        CodingLanguage = entity.CodingLanguage.LanguageName,
                        State = entity.State.StateName,
                        Rating = entity.Rating
                    };
            }
        }
    }
}
