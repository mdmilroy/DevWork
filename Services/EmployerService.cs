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
    public class EmployerService
    {
        private readonly Guid _userId;

        public EmployerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployer(EmployerCreate model)
        {
            var entity = new Employer()
            {
                EmployerId = _userId.ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Organization = model.Organization,
                CreatedUTC = DateTimeOffset.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployerList> GetEmployers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Employers
                    .Select(e => new EmployerList
                    {
                        EmployerId = e.EmployerId,
                        FirstName = e.FirstName,
                        LastName = e.LastName
                    });
                return query.ToArray();
            }
        }

        public EmployerDetail GetEmployerById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employers
                    .Single(e => e.EmployerId == id);
                return
                    new EmployerDetail
                    {
                        EmployerId = entity.EmployerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Rating = entity.Rating,
                        Organization = entity.Organization,
                        CreatedUTC = entity.CreatedUTC
                    };
            }
        }

        public bool UpdateEmployer(EmployerUpdate employerToUpdate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employers
                    .Single(e => e.EmployerId == employerToUpdate.EmployerId && e.EmployerId == _userId.ToString());

                entity.EmployerId = employerToUpdate.EmployerId;
                entity.FirstName = employerToUpdate.FirstName;
                entity.LastName = employerToUpdate.LastName;
                entity.Rating = employerToUpdate.Rating;
                entity.Organization = employerToUpdate.Organization;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployer(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employers
                        .Single(e => e.EmployerId == id && e.EmployerId == _userId.ToString());

                ctx.Employers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
