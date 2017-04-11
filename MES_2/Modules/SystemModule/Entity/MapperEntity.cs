using MES_2.DB.Database;
using MES_2.DB.Tables;

namespace MES_2.Modules.SystemModule.Entity
{
    public static class MapperEntity
    {
        public static EntityModel MapENTToMapperEntity(ENT_Entity entity)
        {
            return new EntityModel()
            {
                ID_ENT = entity.ID_ENT,
                NAME_ENT = entity.NAME_ENT.Trim(),
                State = entity.State,
                VALID = entity.VALID
            };
        }

        public static ENT_Entity MapEntityToENT(EntityModel entity)
        {
            return new ENT_Entity()
            {
                ID_ENT = entity.ID_ENT,
                NAME_ENT = entity.NAME_ENT.Trim(),
                State = entity.State,
                VALID = entity.VALID
            };
        }

        public static ENT_Entity MapEntityDetilToENT(EntityDetailModel entity)
        {
            return new ENT_Entity()
            {
                ID_ENT = entity.ID_ENT,
                NAME_ENT = entity.NAME_ENT.Trim(),
                State = entity.State,
                VALID = entity.VALID,
                STA_StateList = entity.STA_StateList,
                TRA_TranslationState = entity.TRA_TranslationState
            };
        }

        public static EntityDetailModel MapENTToMapperEntityDetail(ENT_Entity entity)
        {
            return new EntityDetailModel()
            {
                ID_ENT = entity.ID_ENT,
                NAME_ENT = entity.NAME_ENT.Trim(),
                State = entity.State,
                VALID = entity.VALID,
                STA_StateList = entity.STA_StateList,
                TRA_TranslationState = entity.TRA_TranslationState
            };
        }
    }
}
