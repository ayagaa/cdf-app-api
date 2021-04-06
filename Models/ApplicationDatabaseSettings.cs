using CDF.API.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Models
{
    public class ApplicationDatabaseSettings : IApplicationDatabaseSettings
    {
        public string CDFAppCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
