using Models.Freelancer;
using System.Collections.Generic;

namespace Contracts
{
    public interface IFreelancerService
    {
        bool CreateFreelancer(FreelancerCreate model);
        List<FreelancerListItem> GetFreelancers();
        FreelancerDetail GetFreelancerById(string id);
        bool UpdateFreelancer(FreelancerUpdate freelancerToUpdate);
        bool DeleteFreelancer(string id);
    }
}
