using PluginInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace MainApp
{
    [Serializable]
    class Controller
    {
        private ConfigLoader configLoader;

        public Dictionary<String, IPlugin> plugins = new Dictionary<string, IPlugin>();

        public static List<Plugin> listOfPlugins;

        public static LoadMode Mode { get; set; } = LoadMode.Auto;

        public void FindPlugins()
        {
            configLoader = new ConfigLoader();
            configLoader.Deserialize();

            listOfPlugins = new List<Plugin>();

            string folder = AppDomain.CurrentDomain.BaseDirectory;

            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);

                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("PluginInterface.IPlugin");

                        if (iface != null)
                        {
                            IPlugin iPlugin = (IPlugin)Activator.CreateInstance(type);

                            if (Mode == LoadMode.Auto)
                                plugins.Add(iPlugin.Name, iPlugin);
                            else addPlugins(iPlugin);

                            /*VersionAttribute versionAttribute = iPlugin.GetType().GetCustomAttribute<VersionAttribute>();
                            string version = versionAttribute.Major.ToString() + "." + versionAttribute.Minor.ToString();
                            plugins.Add(iPlugin.Name, iPlugin);
                            Plugin plugin = new Plugin(iPlugin.Name, iPlugin.Author, version);
                            listOfPlugins.Add(plugin); */
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }

        private void addPlugins(IPlugin iPlugin)
        {
            foreach (var plugin in listOfPlugins)
            {
                if (plugin.Name == iPlugin.Name)
                    plugins.Add(iPlugin.Name, iPlugin);
            }
        }

        /*public string getPluginsList()
        {
            string line = "";
            foreach(var plugin in plugins)
            {
                
            }
        }*/
    }
}
