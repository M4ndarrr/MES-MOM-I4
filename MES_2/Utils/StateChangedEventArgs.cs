//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-13
//  ===============================
//  Namespace        : MES_application
//  Class                   : StateChangeDelegates.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-13
//  Change History: 
// 
// ==================================

using System;
using MES_2.Modules;

namespace MES_2.Utils
{
    //public delegate void ModuleStateChangedDelegat(object sender, ModuleStateChangedEventHandler args);
    public class ModuleStateChangedEventArgs : EventArgs
    {
        //v pozn. jeste basemodule this z jakeho modulu byl change event zavolan
        //public BaseModule ModuleType;
        public BaseModuleEState EStateNOW { get; set; }
        public BaseModuleEState EStatePrev { get; set; }

        public string StateDescription { get; set; }
    }

}