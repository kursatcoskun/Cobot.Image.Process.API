using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanParts.Detection.API.Models;

namespace HumanParts.Detection.API.Data
{
    public class ValuesRepo : IValuesRepo
    {

        DataContext _context;
        public ValuesRepo(DataContext context)
        {
            _context = context;
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


        #region DetectedObject Field

        public List<DetectedObject> getDetectedObjects()
        {
            var detectedObjects = _context.DetectedObjects.ToList();
            return detectedObjects;
        }

        public DetectedObject GetDetectedObjectById(int id)
        {
            var detectedObjects = _context.DetectedObjects.FirstOrDefault(x => x.Id == id);
            return detectedObjects;
        }

        public void DeleteDetectedObjectById(int id)
        {
            var detectedObject = _context.DetectedObjects.FirstOrDefault(x => x.Id == id);
            _context.Remove(detectedObject);
        }

        #endregion


        #region Device Field

        public List<Device> GetDevices()
        {
            var devices = _context.Devices.ToList();
            return devices;
        }


        public Device GetDeviceById(int id)
        {
            var device = _context.Devices.FirstOrDefault(x => x.Id == id);
            return device;
        }

        public void DeleteDeviceById(int id)
        {
            var device = _context.Devices.FirstOrDefault(x=>x.Id == id);
            _context.Remove(device);
        }


        #endregion






    }
}
