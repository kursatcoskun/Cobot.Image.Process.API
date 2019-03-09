using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanParts.Detection.API.Data;
using HumanParts.Detection.API.Models;
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

        [HttpGet]
        [Route("GetDetections")]
        public ActionResult GetAllDetections()
        {
            var detections = _Apprepo.GetAllDetections();
            return Ok(detections);
        }
        [HttpGet]
        [Route("GetDetectionById")]
        public ActionResult GetDetectionById(int id)
        {
            var detection = _Apprepo.GetDetectionById(id);
            return Ok(detection);
        }
        [HttpPost]
        [Route("AddDetection")]
        public ActionResult AddDetection([FromBody] DetectionModel detection)
        {
            _Apprepo.Add(detection);
            _Apprepo.SaveAll();
            return Ok(detection);
        }
        [HttpPut]
        [Route("UpdateDetection")]
        public ActionResult UpdateDetection([FromBody] DetectionModel detection)
        {
            _Apprepo.Update(detection);
            _Apprepo.SaveAll();
            return Ok(detection);
        }
        [HttpDelete]
        [Route("DeleteDetection")]
        public ActionResult DeleteDetectionById(int id)
        {
            _Apprepo.deleteDetectionById(id);
            return Ok();
        }
    }
}