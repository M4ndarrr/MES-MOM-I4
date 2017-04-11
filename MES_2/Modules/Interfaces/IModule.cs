using System;

namespace MES_2.Modules.Interfaces
{
    /// <summary>
    /// Interaface pro moduly 
    /// </summary>
    public interface IModule
    {
        Guid Id { get; set; }
        void Configure();
        void Run();
        void Stop();
        void Restart();
        string Version();

    }
}
