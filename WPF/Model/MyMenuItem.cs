//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-03-10
//  ===============================
//  Namespace        : WPF
//  Class                   : MyMenuItem.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-03-10
//  Change History: 
// 
// ==================================

using System.Collections.Generic;
using WPF.Helpers;

namespace WPF.Model
{
        public class MyMenuItem
        {
            public string Header { get; set; }
            public List<MyMenuItem> Children { get; set; }
            public RelayCommand Command { get; set; }
            public string ImageUrl { get; set; }
        }

}