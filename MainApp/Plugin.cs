using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    [Serializable]
    class Plugin
    {
        private LoadMode Mode { get; set; } = LoadMode.Auto;

        private string Name { get; set; }

        private string Author { get; set; }

       // private string version { get; set; }
    }
}
