//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-01-31
//  ===============================
//  Namespace        : MES_application
//  Class                   : BaseModule.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-01-31
//  Change History: 
// ==================================

using System;
using MES_2.Modules.Interfaces;

namespace MES_2.Modules
{
    public enum BaseModuleEState
    {
        Starting,
        Running,
        Stopped,
        Quit,
        Bussy,
        Problem
    }

    public abstract class BaseModule : IModule
    {
        //public Guid Id { get; set; }
        public BaseModuleEState EModuleState { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();
            
        public void Configure()
        {
        }

        public virtual void Run()
        {
        }

        public virtual void Stop()
        {
        }

        public virtual void Restart()
        {
        }

        public virtual string Version()
        {
            return null;
        }

        public bool HasChanges { get; set; }
        public bool IsNew { get; private set; }

        public bool IsValid
        {
            get { return Validate(); }
        }

        public abstract bool Validate();
        
    }
}