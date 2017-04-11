using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.SystemModule.Entity;

namespace MES_2.Modules.SystemModule.State
{
    public static class MapperState
    {
        public static StateModel MapSTAToState(STA_StateList entity)
        {
            return new StateModel()
            {
                ID_STA = entity.ID_STA,
                ID_ENT = entity.ID_ENT,
                Comments = entity.Comments.Trim(),
                Purpous = entity.Purpous,
                L_END_STATE = entity.L_END_STATE,
                L_START_STATE = entity.L_START_STATE,
                L_VALID = entity.L_VALID
            };
        }

        public static STA_StateList MapStateToSTA(StateModel entity)
        {
            return new STA_StateList()
            {
                ID_STA = entity.ID_STA,
                ID_ENT = entity.ID_ENT,
                Comments = entity.Comments,
                Purpous = entity.Purpous,
                L_END_STATE = entity.L_END_STATE,
                L_START_STATE = entity.L_START_STATE,
                L_VALID = entity.L_VALID,

            };
        }

        public static StateDetailModel MapSTAToStateDetail(STA_StateList entity)
        {
            return new StateDetailModel()
            {
                ID_STA = entity.ID_STA,
                Comments = entity.Comments.Trim(),
                Purpous = entity.Purpous,
                L_END_STATE = entity.L_END_STATE,
                L_START_STATE = entity.L_START_STATE,
                L_VALID = entity.L_VALID,
                ID_ENT = entity.ID_ENT,
                ENT_Entity = entity.ENT_Entity
            };
        }

        public static STA_StateList MapStateDetailToSTA(StateDetailModel entity)
        {
            return new STA_StateList()
            {
                ID_STA = entity.ID_STA,
                ID_ENT = entity.ID_ENT,
                //Comments = entity.Comments.Trim(),
                Comments = entity.Comments,
                Purpous = entity.Purpous,
                L_END_STATE = entity.L_END_STATE,
                L_START_STATE = entity.L_START_STATE,
                L_VALID = entity.L_VALID,
                ENT_Entity = entity.ENT_Entity
            };
        }
    }
}
