using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.SystemModule.Entity;
using MES_2.Modules.SystemModule.State;

namespace MES_2.Modules.SystemModule.Translation
{
    public static class MapperTranslation
    {
        public static TranslationModel MapTraToTranslation(TRA_TranslationState entity)
        {
            return new TranslationModel()
            {
                ID_TRA = entity.ID_TRA,
                ID_ENT = entity.ID_ENT,
                ID_STA_PICA_FROM = entity.ID_STA_PICA_FROM,
                ID_STA_PICA_TO = entity.ID_STA_PICA_TO,
                Description = entity.Description.Trim(),
                L_VALID = entity.L_VALID,
                L_BLOCK = entity.L_BLOCK
            };
        }

        public static TRA_TranslationState MapTranslationToTra(TranslationModel entity)
        {
            return new TRA_TranslationState()
            {
                ID_TRA = entity.ID_TRA,
                ID_ENT = entity.ID_ENT,
                ID_STA_PICA_FROM = entity.ID_STA_PICA_FROM,
                ID_STA_PICA_TO = entity.ID_STA_PICA_TO,
                Description = entity.Description.Trim(),
                L_VALID = entity.L_VALID,
                L_BLOCK = entity.L_BLOCK
            };
        }
        

        public static TranslationDetailModel MapTraToTranslationDetail(TRA_TranslationState entity)
        {
            return new TranslationDetailModel()
            {
                ID_TRA = entity.ID_TRA,
                ID_ENT = entity.ID_ENT,
                ID_STA_PICA_FROM = entity.ID_STA_PICA_FROM,
                ID_STA_PICA_TO = entity.ID_STA_PICA_TO,
                Description = entity.Description.Trim(),
                L_VALID = entity.L_VALID,
                L_BLOCK = entity.L_BLOCK,
                ENT_Entity = entity.ENT_Entity,
                STATE_FROM = entity.STATE_FROM,
                STATE_TO = entity.STATE_TO
            };
        }

        public static TRA_TranslationState MapTranslationDetailToTra(TranslationDetailModel entity)
        {
            return new TRA_TranslationState()
            {
                ID_TRA = entity.ID_TRA,
                ID_ENT = entity.ID_ENT,
                ID_STA_PICA_FROM = entity.ID_STA_PICA_FROM,
                ID_STA_PICA_TO = entity.ID_STA_PICA_TO,
                Description = entity.Description.Trim(),
                L_VALID = entity.L_VALID,
                L_BLOCK = entity.L_BLOCK,
                
            };
        }
    }
}