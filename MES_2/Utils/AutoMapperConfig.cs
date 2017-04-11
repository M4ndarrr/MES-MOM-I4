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
using MES_2.Modules.SystemModule.Entity;

namespace MES_2.Utils
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ENT_Entity, EntityModel>();
                cfg.CreateMap<EntityModel, ENT_Entity>();
                cfg.CreateMap<EntityDetailModel, ENT_Entity>();
                cfg.CreateMap<ENT_Entity, EntityDetailModel>();
               
            });

        }
    }
}

