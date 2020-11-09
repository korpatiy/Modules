using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MainApp
{
    public partial class MainForm : Form
    {
        private Controller controller;

        public MainForm()
        {
            InitializeComponent();
            controller = new Controller();
            CreatePluginsMenu();
        }

        private void CreatePluginsMenu()
        {
            controller.FindPlugins();
            foreach (var x in controller.plugins.Keys)
            {
                var pluginitem = new ToolStripMenuItem(x, null, OnPluginClick);
                filtersTool.DropDownItems.Add(pluginitem);
            }
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = controller.plugins[((ToolStripMenuItem)sender).Text];
            plugin.Transform((Bitmap)pictureBox1.Image);
            pictureBox1.Invalidate();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.test();
        }
    }
}
