using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string rosVersion { get; set; }
        public string OperatingSystemVersion { get; set; }
    }
}
