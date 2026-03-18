using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILoggerService
    {
        void logInfo(string message);
        void logWarning(string message);
        void logError(string message);
        void logDebug(string message);
    }
}
