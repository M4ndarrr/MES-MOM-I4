using MES_2.DB.Database;

namespace MES_2.Modules.SystemModule.State
{
    public static class MapperState
    {
        public static State MapSTAToState(STA_StateList entity)
        {
            return new State()
            {
                ID_STA = entity.ID_STA,
                ID_State = entity.State,
                Comments = entity.Comments.Trim(),
                Purpous = entity.Purpous,
                Name_Entity = entity.Name_Entity,
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
                State = entity.ID_State,
                Comments = entity.Comments.Trim(),
                Purpous = entity.Purpous,
                Name_Entity = entity.Name_Entity,
                L_END_STATE = entity.L_END_STATE,
                L_START_STATE = entity.L_START_STATE,
                L_VALID = entity.L_VALID
            };
        }
    }
}
