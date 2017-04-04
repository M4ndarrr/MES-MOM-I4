using MES_2.DB.Database;
using MES_2.DB.Tables;

namespace MES_2.Modules.SystemModule.Entity
{
    public static class MapperEntity
    {
        public static Entity MapENTToMapperEntity(ENT_Entity entity)
        {
            return new Entity()
            {
                ID_ENT = entity.ID_ENT,
                NAME_ENT = entity.NAME_ENT.Trim(),
                State = entity.State,
                VALID = entity.VALID
            };
        }

        public static ENT_Entity MapEntityToENT(Entity entity)
        {
            return new ENT_Entity()
            {
                ID_ENT = entity.ID_ENT,
                NAME_ENT = entity.NAME_ENT.Trim(),
                State = entity.State,
                VALID = entity.VALID
            };
        }
    }
}
