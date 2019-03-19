using HumanParts.Detection.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Data
{
    public interface IValuesRepo
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        bool SaveAll();

        List<Device> GetDevices();
        Device GetDeviceById(int id);
        void DeleteDeviceById(int id);

        List<DetectedObject> getDetectedObjects();
        DetectedObject GetDetectedObjectById(int id);
        void DeleteDetectedObjectById(int id);
        
    }
}
