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
        [Required(ErrorMessage = "Tanınan Nesnenin Girilmesi Gerekmektedir.")]
        public int detectedObjectId { get; set; }
        public DateTime detectionTime { get; set; }
        [Required(ErrorMessage="Cihaz Id'si girlmesi gereklidir.")]
        public int deviceId { get; set; }


    }
}
