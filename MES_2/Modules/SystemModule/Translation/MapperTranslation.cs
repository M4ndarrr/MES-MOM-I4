using MES_2.DB.Database;

namespace MES_2.Modules.SystemModule.Translation
{
    public static class MapperTranslation
    {
        public static Translation MapTraToTranslation(TRA_TranslationState entity)
        {
            return new Translation()
            {
               NAME_ENT = entity.NAME_ENT.Trim(),
               Description = entity.Description.Trim(),
               ID_STA_FROM = entity.ID_STA_FROM,
               ID_STA_TO = entity.ID_STA_TO,
               ID_TRA = entity.ID_TRA,
               L_VALID = entity.L_VALID,
               L_BLOCK = entity.L_BLOCK
            
            };
        }

        public static TRA_TranslationState MapTranslationToTra(Translation entity)
        {
            return new TRA_TranslationState()
            {
                NAME_ENT = entity.NAME_ENT.Trim(),
                Description = entity.Description.Trim(),
                ID_STA_FROM = entity.ID_STA_FROM,
                ID_STA_TO = entity.ID_STA_TO,
                ID_TRA = entity.ID_TRA,
                L_VALID = entity.L_VALID,
                L_BLOCK = entity.L_BLOCK
            };
        }
    }
}
