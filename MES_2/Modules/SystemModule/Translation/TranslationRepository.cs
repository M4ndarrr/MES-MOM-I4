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
    public class TranslationRepository : IRepository<TranslationModel, object>
    {

        // singleton - lazy learning
        private static TranslationRepository instance;

        public static TranslationRepository Instance
        {
            get
            {
                if (instance == null) instance = new TranslationRepository();
                return instance;
            }
        }

        public TranslationModel Retrieve(int p_id)
        {
            return null;
        }

        public TranslationDetailModel RetrieveDetail(int p_id)
        {
            var Temp = new TranslationDetailModel();
            using (var db = new MES_DATABASE())
            {
                Temp = db.TRA_TranslationState
                    .Where(id => id.ID_TRA == p_id)
                    .Select(MapperTranslation.MapTraToTranslationDetail)
                    .SingleOrDefault();
            }
            return Temp;
        }

        public IEnumerable<TranslationModel> Retrieve()
        {
            List<TranslationModel> Temp = new List<TranslationModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.TRA_TranslationState
                    .Select(MapperTranslation.MapTraToTranslation)
                    .ToList();
            }
            return Temp;
        }

        public IEnumerable<TranslationModel> RetrieveByEntityId(int p_entityID)
        {
            List<TranslationModel> Temp = new List<TranslationModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.TRA_TranslationState
                    .Where(id_ent => id_ent.ID_ENT == p_entityID)
                    .Select(MapperTranslation.MapTraToTranslation)
                    .ToList();
            }
            return Temp;
        }


        public IEnumerable<TranslationDetailModel> RetrieveDetail()
        {
            List<TranslationDetailModel> Temp = new List<TranslationDetailModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.TRA_TranslationState
                    .Select(MapperTranslation.MapTraToTranslationDetail)
                    .ToList();
            }
            return Temp;
        }

        public IEnumerable<TranslationDetailModel> RetrieveDetailByEntityId(int p_entityID)
        {
            List<TranslationDetailModel> Temp = new List<TranslationDetailModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.TRA_TranslationState
                    .Where(id_ent => id_ent.ID_ENT == p_entityID)
                    .Select(MapperTranslation.MapTraToTranslationDetail)
                    .ToList();
            }
            return Temp;
        }
        public TranslationModel Add(object p_entity)
        {
            return null;
        }

        public void Add(TranslationModel p_entity)
        {
            using (var db = new MES_DATABASE())
            {
                db.TRA_TranslationState.Add(MapperTranslation.MapTranslationToTra(p_entity));
                db.SaveChanges();
            }
        }

        public void Delete(TranslationModel p_entity)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(TranslationModel p_entity)
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


        public IEnumerable<TranslationModel> GetPossibleTranslations(int ID_ENT, int ID_STA)
        {
            List<TranslationModel> Temp = new List<TranslationModel>();

            using (var db = new MES_DATABASE())
            {
                Temp = db.TRA_TranslationState
                    .Where(id_ent => id_ent.ID_ENT == ID_ENT)
                    .Where(id_sta => id_sta.ID_STA_PICA_FROM == ID_STA)
                    .Select(MapperTranslation.MapTraToTranslation)
                    .ToList();
            }
            return Temp;
        }
    }
}