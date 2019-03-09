using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Models
{
    public class DetectionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string humanPartName { get; set; }
        public DateTime detectionTime { get; set; }
        public string deviceName { get; set; }

    }
}
