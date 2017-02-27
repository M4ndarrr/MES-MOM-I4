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

namespace MES_application.Modules.CommunicationModule
{
    public class PlcConnectorModuleRepository
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
            return objTemp;
        }


        public void Delete(PlcConnectorModule p_entity)
        {
            p_entity.Delete();
            Instance.PlcConnectorModulesList.RemoveAt(0);
        }

        public void Edit(PlcConnectorModule p_entity)
        {
        }

        public bool Save(PlcConnectorModule p_entity)
        {
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}