using Contracts;
using Data;
using Models.Employer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace Services
{
    public class EmployerService : IEmployerService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
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
                CreatedDate = DateTimeOffset.UtcNow
            };
            entity.State.StateId = _ctx.States.Where(s => s.StateName == model.State).Select(s => s.StateId).Single();

            _ctx.Employers.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public List<EmployerListItem> GetEmployers()
        {
            var query = _ctx.Employers.Where(m => m.IsActive == true).Select(e => new EmployerListItem
            {
                EmployerId = e.EmployerId,
                LastName = e.LastName,
                Organization = e.Organization,
                State = e.State.StateName,
                JobPostsActive = e.JobPosts.Count()
            });

            return query.ToList();
        }

        public EmployerDetail GetEmployerById(string id)
        {
            var entity = _ctx.Employers.Single(e => e.EmployerId == id);
            return new EmployerDetail
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Rating = entity.Rating,
                Organization = entity.Organization,
                State = entity.State.StateName,
                CreatedDate = entity.CreatedDate,
                IsActive = entity.IsActive
            };
        }

        public bool UpdateEmployer(EmployerUpdate employerToUpdate)
        {
            var entity = _ctx.Employers.Single(e => e.EmployerId == _userId.ToString());
                entity.FirstName = employerToUpdate.FirstName;
                entity.LastName = employerToUpdate.LastName;
                entity.Rating = employerToUpdate.Rating; // TODO this is not updating...
                entity.Organization = employerToUpdate.Organization;
                entity.StateId = _ctx.States.Where(s => s.StateName == employerToUpdate.State).Select(s => s.StateId).Single();
                entity.ModifiedDate = DateTimeOffset.UtcNow;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteEmployer(string id)
        {
            var entity = _ctx.Employers.Single(e => e.EmployerId == id);
            entity.IsActive = false;
            //_ctx.Employers.Remove(entity);
            return _ctx.SaveChanges() == 1;
        }

    }
}
