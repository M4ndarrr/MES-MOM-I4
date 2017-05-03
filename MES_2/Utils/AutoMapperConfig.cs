//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-10
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : AutoMapperConfig.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-10
//  Change History: 
// ==================================

using AutoMapper;
using MES_2.DB.Tables;
using MES_2.Modules.ComModule;
using MES_2.Modules.PLCConnectorModule;
using MES_2.Modules.SystemModule.Entity;

namespace MES_2.Utils
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(cfg =>
            {
                //entity
                cfg.CreateMap<ENT_Entity, EntityModel>();
                cfg.CreateMap<EntityModel, ENT_Entity>();
                cfg.CreateMap<EntityDetailModel, ENT_Entity>();
                cfg.CreateMap<ENT_Entity, EntityDetailModel>();

                //PLC_PLCConnector
                cfg.CreateMap<PLC_PLCConnector, PLCConnectorModel>();
                cfg.CreateMap<PLC_PLCConnector, PLCConnectorDetailModel>();
                cfg.CreateMap< PLCConnectorModel, PLC_PLCConnector>();
                cfg.CreateMap< PLCConnectorDetailModel, PLC_PLCConnector>();

                //COM_ComObject
                cfg.CreateMap<COM_ComObject, ComObjectModel>();
                cfg.CreateMap<COM_ComObject, ComObjectDetailModel>();
                cfg.CreateMap<ComObjectModel, COM_ComObject>();
                cfg.CreateMap<ComObjectDetailModel, COM_ComObject>();

                //RES_ResultTable
                cfg.CreateMap<RES_ResultTable, ReceivedResult>();
                cfg.CreateMap<RES_ResultTable, ReceivedResultDetail>();
                cfg.CreateMap<ReceivedResult, RES_ResultTable>();
                cfg.CreateMap<ReceivedResultDetail, RES_ResultTable>();

            });

        }
    }
}

