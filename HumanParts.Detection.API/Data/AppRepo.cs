using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanParts.Detection.API.Models;

namespace HumanParts.Detection.API.Data
{
    public class AppRepo:IAppRepo
    {
        DataContext _context;
        public AppRepo(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void deleteDetectionById(int id)
        {
            var detection = _context.Detections.FirstOrDefault(x => x.Id == id);
            _context.Remove(detection);
        }

        public List<DetectionModel> GetAllDetections()
        {
            var detections = _context.Detections.ToList();
            return detections;
        }

        public DetectionModel GetDetectionById(int id)
        {
            var detection = _context.Detections.FirstOrDefault(x => x.Id == id);
            return detection;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
