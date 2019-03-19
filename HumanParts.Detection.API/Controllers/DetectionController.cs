using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanParts.Detection.API.Dao;
using HumanParts.Detection.API.Data;
using HumanParts.Detection.API.Models;
using HumanParts.Detection.API.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanParts.Detection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectionController : ControllerBase
    {

        IAppRepo _Apprepo;

        public DetectionController(IAppRepo appRepo)
        {
            _Apprepo = appRepo;
        }

        #region GET METHODS

        [HttpGet]
        [Route("GetDetections")]
        public ActionResult GetAllDetections()
        {
            var detections = _Apprepo.GetAllDetections();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", detections));
        }
        [HttpGet]
        [Route("GetDetectionById")]
        public ActionResult GetDetectionById(int id)
        {
            var detection = _Apprepo.GetDetectionById(id);
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", detection));
        }

        #endregion

        #region POST METHODS

        [HttpPost]
        [Route("AddDetection")]
        public ActionResult AddDetection([FromBody] DetectionInput detectionInput)
        {

            DetectionModel detection = new DetectionModel();
            detection.deviceId = detectionInput.deviceId;
            detection.Id = detectionInput.Id;
            detection.detectionTime = detectionInput.detectionTime;
            detection.detectedObjectId = detectionInput.detectedObjectId;
            _Apprepo.Add(detection);
            _Apprepo.SaveAll();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", detection));
        }

        #endregion

        #region PUT METHODS

        [HttpPut]
        [Route("UpdateDetection")]
        public ActionResult UpdateDetection([FromBody] DetectionModel detection)
        {
            _Apprepo.Update(detection);
            _Apprepo.SaveAll();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", detection));
        }

        #endregion

        #region DELETE METHODS

        [HttpDelete]
        [Route("DeleteDetection")]
        public ActionResult DeleteDetectionById(int id)
        {
            _Apprepo.deleteDetectionById(id);
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı",id));
        }

        #endregion

    }
}