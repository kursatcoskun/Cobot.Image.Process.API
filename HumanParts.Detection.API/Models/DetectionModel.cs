using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Models
{
    public class DetectionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("detectedObject")]
        public int detectedObjectId { get; set; }
        public DateTime detectionTime { get; set; }
        [ForeignKey("device")]
        public int deviceId { get; set; }

        public virtual Device device { get; set; }
        public virtual DetectedObject detectedObject { get; set; }


    }
}
