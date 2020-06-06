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
        private readonly string _userId;
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        public EmployerService(string userId)
        {
            _userId = userId;
        }

        public bool CreateEmployer(EmployerCreate model)
        {
            var entity = new Employer()
            {
                EmployerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FirstName + " " + model.LastName,
                Organization = model.Organization,
                StateId = model.StateId,
                CreatedDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };

            _ctx.Employers.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public List<EmployerListItem> GetEmployers()
        {
            var query = _ctx.Employers.Where(m => m.IsActive == true).Select(e => new EmployerListItem
            {
                EmployerId = e.EmployerId,
                FullName = e.FullName,
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
                FullName = entity.FullName,
                Rating = entity.Rating,
                Organization = entity.Organization,
                State = entity.State.StateName,
                CreatedDate = entity.CreatedDate.Date,
                IsActive = entity.IsActive
            };
        }

        public bool UpdateEmployer(EmployerUpdate employerToUpdate)
        {
            var entity = _ctx.Employers.Single(e => e.EmployerId == _userId.ToString());
                entity.FirstName = employerToUpdate.FirstName;
                entity.LastName = employerToUpdate.LastName;
                entity.Rating = employerToUpdate.Rating;
                entity.Organization = employerToUpdate.Organization;
                entity.StateId = employerToUpdate.State;
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
