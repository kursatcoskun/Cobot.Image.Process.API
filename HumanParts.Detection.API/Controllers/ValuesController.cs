using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanParts.Detection.API.Data;
using HumanParts.Detection.API.Models;
using HumanParts.Detection.API.Output;
using Microsoft.AspNetCore.Mvc;

namespace HumanParts.Detection.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        IValuesRepo _valuesRepo;

        public ValuesController(IValuesRepo valuesRepo)
        {
            _valuesRepo = valuesRepo;
        }

        #region Device Field

        [HttpGet]
        [Route("getDevices")]
        public ActionResult GetDevices()
        {
            var devices = _valuesRepo.GetDevices();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", devices));
        }

        [HttpGet]
        [Route("getDeviceById")]
        public ActionResult GetDeviceById(int id)
        {
            var device = _valuesRepo.GetDeviceById(id);
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", device));
        }

        [HttpPost]
        [Route("CreateDevice")]
        public ActionResult CreateDevice([FromBody] Device device)
        {
            _valuesRepo.Add(device);
            _valuesRepo.SaveAll();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", device));
        }

        [HttpPut]
        [Route("UpdateDevice")]
        public ActionResult UpdateDevice([FromBody] Device device)
        {
            _valuesRepo.Update(device);
            _valuesRepo.SaveAll();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", device));
        }

        [HttpDelete]
        [Route("DeleteDeviceById")]
        public ActionResult DeleteDeviceById(int id)
        {
             _valuesRepo.DeleteDeviceById(id);
            _valuesRepo.SaveAll();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı",null));
        }

        #endregion


        #region DetectedObject Field

        [HttpGet]
        [Route("GetDetectedObjects")]
        public ActionResult GetDetectedObjects()
        {
            var detectedObjects = _valuesRepo.getDetectedObjects();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", detectedObjects));
        }

        [HttpGet]
        [Route("GetDetectedObjectById")]
        public ActionResult GetDetectedObjectById(int id)
        {
            var detectedObject = _valuesRepo.GetDetectedObjectById(id);
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", detectedObject));
        }

        [HttpPost]
        [Route("CreateDetectedObject")]
        public ActionResult CreateDetectedObject([FromBody] DetectedObject detectedObject)
        {
            _valuesRepo.Add(detectedObject);
            _valuesRepo.SaveAll();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", detectedObject));
        }

        [HttpPut]
        [Route("UpdateDetectedObject")]
        public ActionResult UpdateDetectedObject([FromBody] DetectedObject detectedObject)
        {
            _valuesRepo.Update(detectedObject);
            _valuesRepo.SaveAll();
            return Ok(new ApiResponse(true, 200, 0, 0, "Başarılı", detectedObject));
        }

        [HttpDelete]
        [Route("DeleteDetectedObjectById")]
        public ActionResult DeleteDetectedObjectById(int id)
        {
            _valuesRepo.DeleteDetectedObjectById(id);
            _valuesRepo.SaveAll();
            return Ok(new ApiResponse(true,200,0,0,"Başarılı",null));
        }


        #endregion

    }
}
