using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormVision.Services.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        void ExecuteInTransactionScope(Action operationsToExecute);
    }
}
