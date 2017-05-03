//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-20
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : ComObjectRepository.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-20
//  Change History: 
// ==================================

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MES_2.DB.Database;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.ComModule
{
    public class ComObjectRepository : IRepository<ComObject, ComObjectConfigure>
    {
        public List<ComObject> ComObjectList { get; set; }

        // singleton lazy learning 
        private static ComObjectRepository instance;

        public static ComObjectRepository Instance
        {
            get
            {
                if (instance == null) instance = new ComObjectRepository();
                return instance;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ComObjectRepository()
        {
            ComObjectList = new List<ComObject>();
        }

        public ComObject Retrieve(int p_id)
        {
            return ComObjectList[p_id];
        }

        public IEnumerable<ComObject> Retrieve()
        {
            return null;
        }

        public ComObjectModel RetrieveModel(Guid p_id)
        {
            ComObjectModel Temp = new ComObjectModel();

            using (var db = new MES_DATABASE())
            {
                Temp = db.ComObjecTable
                    .Where(x => x.ID_COM == p_id)
                    .Select(Mapper.Map<ComObjectModel>)
                    .SingleOrDefault();
            }
            return Temp;
        }

        public IEnumerable<ComObjectModel> RetrieveModel()
        {
            List<ComObjectModel> Temp = new List<ComObjectModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.PLC_PLCConnectorable
                    .Select(Mapper.Map<ComObjectModel>)
                    .ToList();
            }
            return Temp;
        }

        public ComObjectDetailModel RetrieveDetailModel(Guid p_id)
        {
            ComObjectDetailModel Temp = new ComObjectDetailModel();

            using (var db = new MES_DATABASE())
            {
                Temp = db.ComObjecTable
                    .Where(x => x.ID_COM == p_id)
                    .Select(Mapper.Map<ComObjectDetailModel>)
                    .SingleOrDefault();
            }
            return Temp;
        }

        public IEnumerable<ComObjectDetailModel> RetrieveDetailModel()
        {
            List<ComObjectDetailModel> Temp = new List<ComObjectDetailModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.PLC_PLCConnectorable
                    .Select(Mapper.Map<ComObjectDetailModel>)
                    .ToList();
            }
            return Temp;
        }




        public ComObject Add(ComObjectConfigure p_configure)
        {
            ComObject objTemp = new ComObject(p_configure);
            ComObjectList.Add(objTemp);


//            using (var db = new MES_DATABASE())
//            {
//                db.PLCTable.Add(new ComObjecTable()
//                {
//                    ID = objTemp.Id,
//                    Status = (int) objTemp.EModuleState,
//                    AreaMemory = objTemp.ObjectConfigure.AreaOfMemory,
//                    StartOffSet = objTemp.ObjectConfigure.StartOffset,
//                    Period = objTemp.ObjectConfigure.PeriodOfCheck,
//                    ReadWrite = objTemp.ObjectConfigure.ERW,
//                    DBnumber = objTemp.ObjectConfigure.DbNumber,
//                    WorldLen = objTemp.ObjectConfigure.WorldLen,
//                    IDPLC =
//                });
//                db.SaveChanges();
//            }

            return objTemp;
        }

        public void Add(ComObject p_entity)
        {
        }

        public void Delete(ComObject p_entity)
        {
            var item = ComObjectList.FindIndex(x => x.Id == p_entity.Id);
            ComObjectList.RemoveAt(item);
        }

        public void Delete(int p_id)
        {
            ComObjectList.RemoveAt(p_id);
        }

        public void DeleteAll(ComObject p_entity)
        {
            ComObjectList.Clear();
        }

        // edit na zaklade ID? nebo reference?
        public void Edit(ComObject p_entity)
        {
        }

        public void Edit(ComObjectConfigure p_entity)
        {
        }

        public bool Save()
        {
            return true;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}