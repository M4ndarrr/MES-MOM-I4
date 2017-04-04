//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : BaseTable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-03
//  Change History: 
// 
// ==================================

using System.ComponentModel.DataAnnotations;
using MES_2.DB.Tables.Base.Interface;

namespace MES_2.DB.Tables.Base
{
    public class BaseTable : IBaseTable
    {
        [Key]
        public int ID { get; set; }
    }
}