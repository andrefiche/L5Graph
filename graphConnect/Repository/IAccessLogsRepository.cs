using System;
using System.Collections.Generic;
using graphConnect.Models;

namespace graphConnect.Repository
{
    public interface IAccessLogsRepository
    {
        IEnumerable<AccessLogs> GetAll();
    }
}
