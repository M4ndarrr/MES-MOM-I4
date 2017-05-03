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
// ==================================
using System;
using System.ComponentModel.DataAnnotations;
using WPF.Helpers;

namespace WPF.Modules.ComModule
{
    public class ComObjectFullEditable : ValidatableBindableBase
    {
        public Guid Id { get; set; }

        [Required]

        private int _areaOfMemory;

        public int AreaOfMemory
        {
            get { return _areaOfMemory; }
            set { SetProperty(ref _areaOfMemory, value); }
        }

        [Required]
        private int _worldLen;

        public int WorldLen
        {
            get { return _worldLen; }
            set { SetProperty(ref _worldLen, value); }
        }

        [Required]
        private int _startOffset;

        public int StartOffset
        {
            get { return _startOffset; }
            set { SetProperty(ref _startOffset, value); }
        }


        [Required]
            private int _periodOfCheck;

        public int PeriodOfCheck
        {
            get { return _periodOfCheck; }
            set { SetProperty(ref _periodOfCheck, value); }
        }

        [Required]
        private int _dbNumber;

        public int DbNumber
        {
            get { return _dbNumber; }
            set { SetProperty(ref _dbNumber, value); }
        }
    }
}