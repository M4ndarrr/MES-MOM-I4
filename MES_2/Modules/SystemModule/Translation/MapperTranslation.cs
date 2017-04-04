using MES_2.DB.Database;
using MES_2.DB.Tables;
using MES_2.Modules.SystemModule.Entity;
using MES_2.Modules.SystemModule.State;

namespace MES_2.Modules.SystemModule.Translation
{
    public static class MapperTranslation
    {
        public static Translation MapTraToTranslation(TRA_TranslationState entity)
        {
            return new Translation()
            {
                ID_TRA = entity.ID_TRA,
                NAME_ENT = entity.NAME_ENT,
                ID_STA_PICA_FROM = entity.ID_STA_PICA_FROM,
                ID_STA_PICA_TO = entity.ID_STA_PICA_TO,
                Description = entity.Description.Trim(),
               L_VALID = entity.L_VALID,
               L_BLOCK = entity.L_BLOCK
            
            };
        }

        public static TRA_TranslationState MapTranslationToTra(Translation entity)
        {
            return new TRA_TranslationState()
            {
                ID_TRA = entity.ID_TRA,
                NAME_ENT = entity.NAME_ENT,
                ID_STA_PICA_FROM = entity.ID_STA_PICA_FROM,
                ID_STA_PICA_TO = entity.ID_STA_PICA_TO,
                Description = entity.Description.Trim(),
                L_VALID = entity.L_VALID,
                L_BLOCK = entity.L_BLOCK
            };
        }
    }
}
