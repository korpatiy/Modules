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
            // папка с плагинами
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            // dll-файлы в этой папке
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
                            Plugin plugin = new Plugin();
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
