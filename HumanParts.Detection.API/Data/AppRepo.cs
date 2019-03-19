using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanParts.Detection.API.Models;
using HumanParts.Detection.API.Output;

namespace HumanParts.Detection.API.Data
{
    public class AppRepo:IAppRepo
    {
        DataContext _context;
        IValuesRepo _valuesRepo;
        public AppRepo(DataContext context,IValuesRepo valuesRepo)
        {
            _context = context;
            _valuesRepo = valuesRepo;
        }

        #region Standart EF Methods

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        #endregion

        #region Void Methods

        public void deleteDetectionById(int id)
        {
            var detection = _context.Detections.FirstOrDefault(x => x.Id == id);
            _context.Remove(detection);
        }

        #endregion

        #region List Return Methods

        public List<DetectionModelOutput> GetAllDetections()
        {
            Device device = new Device();
            DetectedObject detectedObject = new DetectedObject();
            List<DetectionModel> detectionModels = new List<DetectionModel>();
            detectionModels = _context.Detections.ToList();
            DetectionModelOutput detectionModelOutput = new DetectionModelOutput();
            List<DetectionModelOutput> detectionModelOutputs = new List<DetectionModelOutput>();

            foreach (var item in detectionModels)
            {
                device = _valuesRepo.GetDeviceById(item.deviceId);
                detectedObject = _valuesRepo.GetDetectedObjectById(item.detectedObjectId);
               
                detectionModelOutputs.Add(new DetectionModelOutput()
                {

                    Id = item.Id,
                    deviceId = item.deviceId,
                    detectedObjectId = item.detectedObjectId,
                    detectionTime = item.detectionTime,
                    detectedObject = detectedObject.Title,
                    device = device.Name
                });

            }
            return detectionModelOutputs;
            
        }

        #endregion

        #region Class Return Methods

        public DetectionModelOutput GetDetectionById(int id)
        {
            Device device = new Device();
            DetectedObject detectedObject = new DetectedObject();
            DetectionModelOutput detectionModelOutput = new DetectionModelOutput();
            DetectionModel detectionModel = new DetectionModel();
            detectionModel = _context.Detections.FirstOrDefault(x => x.Id == id);

            detectedObject = _valuesRepo.GetDetectedObjectById(detectionModel.detectedObjectId);
            device = _valuesRepo.GetDeviceById(detectionModel.deviceId);
  
            detectionModelOutput.Id = detectionModel.Id;
            detectionModelOutput.detectionTime = detectionModel.detectionTime;
            detectionModelOutput.deviceId = detectionModel.deviceId;
            detectionModelOutput.device = detectionModel.device.Name;
            detectionModel.detectedObjectId = detectionModel.detectedObjectId;
            detectionModelOutput.detectedObject = detectedObject.Title;


            return detectionModelOutput;
        }

        #endregion






    }
}
