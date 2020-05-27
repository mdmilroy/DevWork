using Models.Freelancer;
using System.Collections.Generic;

namespace Contracts
{
    public interface IFreelancerService
    {
        bool CreateFreelancer(FreelancerCreate model);
        ICollection<FreelancerListItem> GetFreelancers();
        FreelancerDetail GetFreelancerById(string id);
        bool UpdateFreelancer(FreelancerUpdate freelancerToUpdate);
        bool AddCodingLanguage(FreelancerAddCodingLanguage codingLanguageId);
        bool RemoveCodingLanguage(FreelancerRemoveCodingLanguage codingLanguageId);
        bool DeleteFreelancer(string id);
    }
}
