using Data;
using Models.Profile;
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
                                    State =e.State.StateName
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
                                    State = e.State.StateName
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
