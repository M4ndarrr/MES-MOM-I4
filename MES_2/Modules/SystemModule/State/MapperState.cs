using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.SystemModule.Entity;

namespace MES_2.Modules.SystemModule.State
{
    public static class MapperState
    {
        public static State MapSTAToState(STA_StateList entity)
        {
            return new State()
            {
                ID_STA = entity.ID_STA,
                NAME_ENT = entity.NAME_ENT,
                Comments = entity.Comments.Trim(),
                Purpous = entity.Purpous,
                
                L_END_STATE = entity.L_END_STATE,
                L_START_STATE = entity.L_START_STATE,
                L_VALID = entity.L_VALID
            };
        }

        public static STA_StateList MapStateToSTA(State entity)
        {
            return new STA_StateList()
            {
                ID_STA = entity.ID_STA,
                NAME_ENT = entity.NAME_ENT,
                Comments = entity.Comments.Trim(),
                Purpous = entity.Purpous,
                L_END_STATE = entity.L_END_STATE,
                L_START_STATE = entity.L_START_STATE,
                L_VALID = entity.L_VALID
            };
        }
    }
}
