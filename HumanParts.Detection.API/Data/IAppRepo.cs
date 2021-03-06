﻿using HumanParts.Detection.API.Models;
using HumanParts.Detection.API.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanParts.Detection.API.Data
{
    public interface IAppRepo
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        bool SaveAll();
        void deleteDetectionById(int id);

        #region LIST RETURN METHODS

        List<DetectionModelOutput> GetAllDetections();

        #endregion


        #region CLASS RETURN METHODS

        DetectionModelOutput GetDetectionById(int id);

        #endregion

    }
}
