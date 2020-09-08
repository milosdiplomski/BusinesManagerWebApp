using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Services
{
    /// <summary>
    /// Options class for the BusinessManagerClient
    /// Populated automatically from configuration when used via DI with the options pattern
    /// </summary>
    public class BusinessManagerClientOptions
    {
        public string BaseAddress { get; set; }
        public string Port { get; set; }
        public string Version { get; set; }
        public string E500InternalServerError { get; set; }
    }
}
