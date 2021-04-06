using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Models.Interfaces
{
    public interface IApplicationDatabaseSettings
    {
        string CDFAppCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
