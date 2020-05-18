using Models.Profile;
using Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFreelancerService
    {
        bool CreateFreelancer(FreelancerCreate model);
        IEnumerable<FreelancerList> GetFreelancers();
        FreelancerDetail GetFreelancerById(string id);
        bool UpdateFreelancer(FreelancerUpdate freelancerToUpdate);
        bool DeleteFreelancer(string id);
    }
}
