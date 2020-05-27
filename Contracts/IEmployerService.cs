using Models.Employer;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface IEmployerService
    {
        bool CreateEmployer(EmployerCreate model);
        List<EmployerListItem> GetEmployers();
        EmployerDetail GetEmployerById(string id);
        bool UpdateEmployer(EmployerUpdate employerToUpdate);
        bool DeleteEmployer(string id);
    }
}
