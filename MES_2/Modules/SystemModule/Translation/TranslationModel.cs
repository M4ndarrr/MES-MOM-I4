//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-29
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : TranslationModel.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-29
//  Change History: 
// 
// ==================================

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MES_2.DB.Database;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.SystemModule.Translation
{
    public class TranslationModel : IRepository<Translation, object>
    {

        // singleton - lazy learning
        private static TranslationModel instance;

        public static TranslationModel Instance
        {
            get
            {
                if (instance == null) instance = new TranslationModel();
                return instance;
            }
        }

        public Translation Retrieve(int p_id)
        {
            return null;
        }

        public IEnumerable<Translation> Retrieve()
        {
            List<Translation> Temp = new List<Translation>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.TRA_TranslationState
                    .Select(MapperTranslation.MapTraToTranslation)
                    .ToList();
            }
            return Temp;
        }
        public IEnumerable<Translation> RetrieveByEntityName(string p_EntityName)
        {
            List<Translation> Temp = new List<Translation>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.TRA_TranslationState
                    .Where(x => x.NAME_ENT == p_EntityName)
                    .Select(MapperTranslation.MapTraToTranslation)
                    .ToList();
            }
            return Temp;
        }


        public Translation Add(object p_entity)
        {
            return null;
        }

        public void Add(Translation p_entity)
        {
            using (var db = new MES_DATABASE())
            {
                db.TRA_TranslationState.Add(MapperTranslation.MapTranslationToTra(p_entity));
                db.SaveChanges();
            }
        }

        public void Delete(Translation p_entity)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(Translation p_entity)
        {
            var Temp = MapperTranslation.MapTranslationToTra(p_entity);
            using (var db = new MES_DATABASE())
            {
                if (!db.TRA_TranslationState.Local.Any(c => c.ID_TRA == p_entity.ID_TRA))
                {
                    db.TRA_TranslationState.Attach(Temp);
                    db.Entry(Temp).State = EntityState.Modified;

                }
                db.SaveChanges();
            }
        }

        public void Edit(object p_entity)
        {
        }

        public bool Save()
        {
            return false;
        }
    }
}