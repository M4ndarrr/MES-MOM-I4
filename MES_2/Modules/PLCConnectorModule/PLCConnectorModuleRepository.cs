//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-20
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : PLCConnectorModuleRepository.cs
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
using MES_2.DB.Tables;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.PLCConnectorModule
{
    public class PlcConnectorModuleRepository : IRepository<PlcConnectorModule, PLCConnectorModuleConfigure>
    {
// : IRepository<PlcConnectorModule>
        public List<PlcConnectorModule> PlcConnectorModulesList { get; set; }

        // singleton - lazy learning
        private static PlcConnectorModuleRepository instance;

        public static PlcConnectorModuleRepository Instance
        {
            get
            {
                if (instance == null) instance = new PlcConnectorModuleRepository();
                return instance;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public PlcConnectorModuleRepository()
        {
            PlcConnectorModulesList = new List<PlcConnectorModule>();
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public PlcConnectorModule Retrieve(int p_id)
        {
            try
            {
                return PlcConnectorModulesList[p_id];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new System.ArgumentOutOfRangeException("Index is out of range", ex);
            }
        }

        public IEnumerable<PlcConnectorModule> Retrieve()
        {
            if (PlcConnectorModulesList != null)
            {
                return PlcConnectorModulesList.ToList();
            }

            return null;
        }

        public PLCConnectorModel RetrieveModel(Guid p_id)
        {
            PLCConnectorModel Temp = new PLCConnectorModel();

            using (var db = new MES_DATABASE())
            {
                Temp = db.PLC_PLCConnectorable
                    .Where(x => x.ID_PLC == p_id)
                    .Select(Mapper.Map<PLCConnectorModel>)
                    .SingleOrDefault();
                //  .Select(MapperEntity.MapENTToMapperEntity)
            }
            return Temp;
        }

        public IEnumerable<PLCConnectorModel> RetrieveModel()
        {
            List<PLCConnectorModel> Temp = new List<PLCConnectorModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.PLC_PLCConnectorable
                    .Select(Mapper.Map<PLCConnectorModel>)
                    .ToList();
            }
            return Temp;
        }

        public PLCConnectorDetailModel RetrieveDetailModel(Guid p_id)
        {
            PLCConnectorDetailModel Temp = new PLCConnectorDetailModel();

            using (var db = new MES_DATABASE())
            {
                Temp = db.PLC_PLCConnectorable
                    .Where(x => x.ID_PLC == p_id)
                    .Select(Mapper.Map<PLCConnectorDetailModel>)
                    .SingleOrDefault();
            }
            return Temp;
        }

        public IEnumerable<PLCConnectorDetailModel> RetrieveDetailModel()
        {
            List<PLCConnectorDetailModel> Temp = new List<PLCConnectorDetailModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.PLC_PLCConnectorable
                    .Select(Mapper.Map<PLCConnectorDetailModel>)
                    .ToList();
            }
            return Temp;
        }

        public PlcConnectorModule Add(PLCConnectorModuleConfigure p_configure)
        {
            PlcConnectorModule objTemp = new PlcConnectorModule(p_configure);
            PlcConnectorModulesList.Add(objTemp);


            using (var db = new MES_DATABASE())
            {
                db.PLC_PLCConnectorable.Add(new PLC_PLCConnector()
                {
                    ID_PLC = objTemp.Id,
                    Status = (int)objTemp.EModuleState,
                    IP = objTemp.PlcModuleConfigure.IpString,
                    Port = objTemp.PlcModuleConfigure.PortString,
                    Rack = objTemp.PlcModuleConfigure.Rack,
                    Slot = objTemp.PlcModuleConfigure.Slot,
                    TimeCreated = DateTime.Now,
                    TimeModified = DateTime.Now,
                    P_Created = "Honza",
                    P_Modified = "Honza"
                });
                db.SaveChanges();
            }


            return objTemp;
        }

        public void Add(PlcConnectorModule p_entity)
        {
        }


        public void Delete(PlcConnectorModule p_entity)
        {
            p_entity.Delete();
            Instance.PlcConnectorModulesList.RemoveAt(0);
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(PlcConnectorModule p_entity)
        {
        }

        public void Edit(PLCConnectorModuleConfigure p_entity)
        {
        }

        public void LoadStartUp()
        {
            if (PlcConnectorModulesList.Count != 0)
            {
                //load vsech zarizeni z databaze - all actived

                
            }
        }


        public bool Save()
        {
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}