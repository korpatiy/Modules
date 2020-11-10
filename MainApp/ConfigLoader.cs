using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MainApp
{
    public class ConfigLoader
    {
        private XmlSerializer serializer = new XmlSerializer(typeof(List<Plugin>));
        private string path = "test.xml";

        /*public bool Serialize()
        {
            using (FileStream fs = new FileStream("test.xml", FileMode.Create))
            {
                serializer.Serialize(fs, Controller.listOfPlugins);
            }
            return true;
        }*/

        public void Deserialize()
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);

            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Файл конфигурации не найден");
                return;
            }
            XmlElement xRoot = xDoc.DocumentElement;
            string mode = "";

            if (xRoot.FirstChild.Name == "Mode")
                mode = xRoot.FirstChild.InnerText;
            else MessageBox.Show("Отсутствует конфигурация режима в файле", "Ошибка");

            //Controller.Mode = mode == "Auto" ? LoadMode.Auto : LoadMode.CFG;

            if (mode == LoadMode.CFG.ToString())
            {
                Controller.Mode = LoadMode.CFG;
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    Controller.listOfPlugins = (List<Plugin>)serializer.Deserialize(fs);
                }
            }
            else
                Controller.Mode = LoadMode.Auto;
        }
    }
}
