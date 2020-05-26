using Contracts;
using Data;
using Models.Profile;
using Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class EmployerService : IEmployerService
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
                StateId = model.StateId,
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
                        LastName = e.LastName,
                        StateName = e.State.StateName
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
                var stateEntity = ctx.States.Single(e => e.StateId == entity.StateId);
                return
                    new EmployerDetail
                    {
                        EmployerId = entity.EmployerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Rating = entity.Rating,
                        Organization = entity.Organization,
                        StateName = stateEntity.StateName,
                        CreatedUTC = DateTimeOffset.UtcNow
                    };
            }
        }

        public bool UpdateEmployer(EmployerUpdate employerToUpdate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Employers
                    .Single(e => e.EmployerId == employerToUpdate.EmployerId);

                entity.FirstName = employerToUpdate.FirstName;
                entity.LastName = employerToUpdate.LastName;
                entity.Rating = employerToUpdate.Rating; // TODO this is not updating...
                entity.Organization = employerToUpdate.Organization;
                entity.StateId = employerToUpdate.StateId;
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
                        .Single(e => e.EmployerId == id);
                ctx.Employers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
