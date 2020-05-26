using Models.Profile;
using Models.Profiles;
using System.Collections.Generic;

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
