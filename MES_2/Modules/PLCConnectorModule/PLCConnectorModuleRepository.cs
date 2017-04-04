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

        public PlcConnectorModule Add(PLCConnectorModuleConfigure p_configure)
        {
            PlcConnectorModule objTemp = new PlcConnectorModule(p_configure);
            PlcConnectorModulesList.Add(objTemp);


            using (var db = new MES_DATABASE())
            {
                db.PLCTable.Add(new PLCTable()
                {
                    ID = objTemp.Id,
                    Status = (int)objTemp.EModuleState,
                    IP = objTemp.PlcModuleConfigure.IpString,
                    Port = objTemp.PlcModuleConfigure.PortString,
                    Rack = objTemp.PlcModuleConfigure.Rack,
                    Slot = objTemp.PlcModuleConfigure.Slot,
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