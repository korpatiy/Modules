using PluginInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MainApp
{
    [Serializable]
    class Controller
    {
        public Dictionary<String, IPlugin> plugins = new Dictionary<string, IPlugin>();

        public static List<Plugin> listOfPlugins = new List<Plugin>();

        public void FindPlugins()
        {
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
                            plugins.Add(iPlugin.Name, iPlugin);

                            /*VersionAttribute versionAttribute = iPlugin.GetType().GetCustomAttribute<VersionAttribute>();
                            string version = versionAttribute.Major.ToString() + "." + versionAttribute.Minor.ToString();
                            plugins.Add(iPlugin.Name, iPlugin);
                            Plugin plugin = new Plugin(iPlugin.Name, iPlugin.Author, version);
                            listOfPlugins.Add(plugin);*/
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }

        public void test()
        {
            ConfigLoader configLoader = new ConfigLoader();
            configLoader.Serialize();
        }
    }
}
