//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-20
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : IRepository.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-20
//  Change History: 
// 
// ==================================

using System.Collections.Generic;

namespace MES_2.Modules.Interfaces
{
    public interface IRepository<T,Y>
    {
        T Retrieve(int p_id);
        IEnumerable<T> Retrieve();
        T Add(Y p_entity);
        void Add(T p_entity);
        void Delete(T p_entity);
        void Delete(int p_id);
        void Edit(T p_entity);
        void Edit(Y p_entity);
        bool Save();
    }
}