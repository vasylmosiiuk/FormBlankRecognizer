using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FormVision.IoC
{
    public interface IModuleInitialization
    {
        Task Init();
    }
}
