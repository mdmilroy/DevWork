using Models.Profile;
using Models.Profiles;
using System.Collections.Generic;

namespace Contracts
{
    public interface IEmployerService
    {
        bool CreateEmployer(EmployerCreate model);
        IEnumerable<EmployerList> GetEmployers();
        EmployerDetail GetEmployerById(string id);
        bool UpdateEmployer(EmployerUpdate employerToUpdate);
        bool DeleteEmployer(string id);
    }
}
