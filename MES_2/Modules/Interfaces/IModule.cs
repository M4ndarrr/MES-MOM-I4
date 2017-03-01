using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using Sharp7;

namespace MES_application.Modules
{
    /// <summary>
    /// Interaface pro moduly 
    /// </summary>
    public interface IModule
    {
        string Id { get; set; }
        void Configure();
        void Run();
        void Stop();
        void Restart();
        string Version();

    }
}
