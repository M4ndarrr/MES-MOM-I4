//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-22
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : Repository.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-22
//  Change History: 
// 
// ==================================

using System.Collections.Generic;

namespace MES_application.Modules
{
    public class Repository <T> : IRepository<T> where T : BaseModule
    {
        public T Retrieve(int p_id)
        {
            return null;
        }

        public IEnumerable<T> Retrieve()
        {
            yield break;
        }

        public void Add()
        {
        }

        public void Add(T p_entity)
        {
        }

        public void Delete(T p_entity)
        {
        }

        public void Edit(T p_entity)
        {
        }

        public bool Save(T p_entity)
        {
            return false;
        }
    }
}