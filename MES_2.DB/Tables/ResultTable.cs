//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-03
//  ===============================
//  Namespace        : MES_2.DAL
//  Class                   : ResultTable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-03
//  Change History: 
// 
// ==================================
namespace MES_2.DB.Tables
{
    public class ResultTable
    {
        public long ID { get; set; }
        public System.DateTime PLCStamp { get; set; }
        public string IDComObject { get; set; }
        public int ResultData { get; set; }
    }
}