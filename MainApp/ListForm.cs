using PluginInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp
{
    public partial class ListForm : Form
    {
        private Dictionary<string, IPlugin> plugins;

        public ListForm()
        {
           
        }

        public ListForm(Dictionary<string, IPlugin> plugins)
        {
            this.plugins = plugins;
            InitializeComponent();
            fillTree();
        }

        private void fillTree()
        {
            foreach(var plugin in plugins.Values)
            {
                TreeNode pluginNode = new TreeNode { Text = plugin.Name };
                pluginNode.Nodes.Add("Autor -" + plugin.Author);
                VersionAttribute versionAttribute = plugin.GetType().GetCustomAttribute<VersionAttribute>();
                string version = versionAttribute.Major.ToString() + "." + versionAttribute.Minor.ToString();
                pluginNode.Nodes.Add("Version - " + version);
                treeView1.Nodes.Add(pluginNode);
            }
        }

      
    }
}
