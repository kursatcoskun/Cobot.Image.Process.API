using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Output
{
    public class DetectionModelOutput
    {
        public int Id { get; set; }
        public int detectedObjectId { get; set; }
        public string detectedObject { get; set; }
        public DateTime detectionTime { get; set; }
        public int deviceId { get; set; }
        public string device { get; set; }
    }
}
