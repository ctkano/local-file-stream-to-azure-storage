using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStreamer.Objects
{
    /// <summary>
    /// Azure storage access information
    /// </summary>
    public class AzureAccessObjects
    {
        /// <summary>
        /// Storage resource URI 
        /// </summary>
        public string URI { get; set; }

        /// <summary>
        /// SAS Token
        /// </summary>
        public string Token { get; set; }
    }
}
