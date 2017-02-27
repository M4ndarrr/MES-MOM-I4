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

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MES_application.Modules
{
    public interface IRepository<T>
    {
        T Retrieve(int p_id);
        IEnumerable<T> Retrieve();
        void Add();
        void Delete(T p_entity);
        void Edit(T p_entity);
        bool Save(T p_entity);
    }
}