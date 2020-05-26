using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        double Rating { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset ModifiedDate { get; set; }
        int JobsCompleted { get; set; }
    }
}
