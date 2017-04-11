//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-05
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : ComObjectFullEditable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-05
//  Change History: 
// 
// ==================================

using System;
using WPF.Helpers;

namespace WPF.Modules.ComModule
{
    public class ComObjectFullEditable : ValidatableBindableBase
    {
        public Guid Id { get; set; }
        public int AreaOfMemory { get; set; }
        public int WorldLen { get; set; }
        public int StartOffset { get; set; }
        public int PeriodOfCheck { get; set; }
        public int DbNumber { get; set; }
    }
}