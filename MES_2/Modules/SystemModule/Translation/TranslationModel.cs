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
using MES_2.Modules.Interfaces;

namespace MES_2.Modules.SystemModule.Translation
{
    public class TranslationModel : IRepository<Translation, object>
    {
        public Translation Retrieve(int p_id)
        {
            return null;
        }

        public IEnumerable<Translation> Retrieve()
        {
            yield break;
        }

        public Translation Add(object p_entity)
        {
            return null;
        }

        public void Add(Translation p_entity)
        {
        }

        public void Delete(Translation p_entity)
        {
        }

        public void Delete(int p_id)
        {
        }

        public void Edit(Translation p_entity)
        {
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