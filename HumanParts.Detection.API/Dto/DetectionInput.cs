using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Dao
{
    public class DetectionInput
    {
        public int Id { get; set; }
        public int detectedObjectId { get; set; }
        public DateTime detectionTime { get; set; }
        public int deviceId { get; set; }
    }
}
