using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MainApp
{
    public class ConfigLoader
    {
        private XmlSerializer serializer = new XmlSerializer(typeof(List<Plugin>));
        private static readonly string path = AppDomain.CurrentDomain.BaseDirectory;

        public bool Serialize()
        {
            using (FileStream fs = new FileStream("test.xml", FileMode.Create))
            {
                serializer.Serialize(fs, Controller.listOfPlugins);
            }
            return true;
        }

        public bool Deserialize()
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
               Controller.listOfPlugins = (List<Plugin>)serializer.Deserialize(fs);
            }
            return true;
        }
    }
}
