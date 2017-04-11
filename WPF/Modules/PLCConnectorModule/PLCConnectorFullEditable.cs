//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-04-05
//  ===============================
//  Namespace        : MES_2.WPF
//  Class                   : PLCConnectorFullEditable.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-04-05
//  Change History: 
// 
// ==================================

using System;
using System.ComponentModel.DataAnnotations;
using WPF.Helpers;

namespace WPF.Modules.PLCConnectorModule
{
    public class PLCConnectorFullEditable : ValidatableBindableBase
    {
        public Guid Id { get; private set; }

        [Required]

        private int _rack;

        public int Rack
        {
            get { return _rack; }
            set { SetProperty(ref _rack, value); }
        }
        [Required]

        private int _slot;

        public int Slot
        {
            get { return _slot; }
            set { SetProperty(ref _slot, value); }
        }
        [Required]

        private string _ipString;

        public string IpString
        {
            get { return _ipString; }
            set { SetProperty(ref _ipString, value); }
        }

        public string PortString { get; set; }
    }
}