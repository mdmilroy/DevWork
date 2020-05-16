using Models.Profile;
using Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
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
